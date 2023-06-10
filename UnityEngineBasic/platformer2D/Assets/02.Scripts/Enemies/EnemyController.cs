using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    private CapsuleCollider2D _col;

    public int direction
    {
        get => _direction;
        set
        {
            if (value > 0)
            {
                direction = DIRECTION_RIGHT;
                transform.eulerAngles = Vector3.zero;
            }
            else if (value < 0)
            {
                direction = DIRECTION_LEFT;
                transform.eulerAngles = new Vector3(0.0f,180.0f,0.0f);
            }

        }
    }
    private int _direction = DIRECTION_RIGHT;
    public const int DIRECTION_RIGHT = 1;
    public const int DIRECTION_LEFT = -1;

    // 움직일수 있는 Enemy와 못움직이는 Enemy 구분
    [SerializeField] private bool _moveEnable = true; // 움직이는 기능 활성화 여부
    [SerializeField] private float _moveSpeed;
    private bool _movable; // 현재 움직일 수 있는 상태인지

    public enum StateType
    {
        Idle,
        Move,
        Attack,
        Hurt,
        Die
    }
    public StateType current;

    // 상태별 로직: 어떤 상태일 때 어떤 로직을 수행해야 하는지
    private Dictionary<StateType, IEnumerator<int>> _workflows = new Dictionary<StateType, IEnumerator<int>>();

    #region Workflows
    /// <summary> +α : 
    /// IEnumerator 인터페이스 대신, 새로운 인터페이스를 만들어서 좀 더 효율적으로 추상화 가능
    /// </summary>
    // Idle, Move는 애니메이션 무한루프
    public struct IdleWorkflow : IEnumerator<int>
    {
        public int Current => _current;

        object IEnumerator.Current => _current;
        private int _current;
        private EnemyController _controller;

        public IdleWorkflow(EnemyController controller)
        {
            _current = 0;
            _controller = controller;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            switch (_current)
            {
                case 0:
                    {
                        _controller._movable = false;
                        _controller._animator.Play("Idle");
                        _current++;
                    }
                    break;
                default:
                    break;
            }
            return true;
        }

        public void Reset()
        {
            _current = 0;
        }
    }
    public struct MoveWorkflow : IEnumerator<int>
    {
        public int Current => _current;

        object IEnumerator.Current => _current;
        private int _current;
        private EnemyController _controller;

        public MoveWorkflow(EnemyController controller)
        {
            _current = 0;
            _controller = controller;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            switch (_current)
            {
                case 0:
                    {
                        _controller._movable = true;
                        _controller._animator.Play("Move");
                        _current++;
                    }
                    break;
                default:
                    break;
            }
            return true;
        }

        public void Reset()
        {
            _current = 0;
        }
    }
    // Attack, Hurt, Die는 애니메이션 한 번 실행
    public struct AttackWorkflow : IEnumerator<int>
    {
        public int Current => _current;

        object IEnumerator.Current => _current;
        private int _current;
        private EnemyController _controller;

        public AttackWorkflow(EnemyController controller)
        {
            _current = 0;
            _controller = controller;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            switch (_current)
            {
                case 0:
                    {
                        _controller._movable = false;
                        _controller._animator.Play("Attack");
                        _current++;
                        
                    }
                    return true;
                case 1:
                    {
                        // 현재 실행중인 애니메이션의 정보 추출
                        // normalizedTime: 애니메이션이 실행된 정도(%))
                        if(_controller._animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                        {
                            if (_controller.ChangeState(StateType.Idle))
                            {
                                _current++;
                            }
                        }
                    }
                    return true;
                default:
                    return false;
            }
        }

        public void Reset()
        {
            _current = 0;
        }
    }
    public struct HurtWorkflow : IEnumerator<int>
    {
        public int Current => _current;

        object IEnumerator.Current => _current;
        private int _current;
        private EnemyController _controller;

        public HurtWorkflow(EnemyController controller)
        {
            _current = 0;
            _controller = controller;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            switch (_current)
            {
                case 0:
                    {
                        _controller._movable = false;
                        _controller._animator.Play("Hurt");
                        _current++;
                    }
                    return true;
                case 1:
                    {
                        if (_controller._animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                        {
                            if (_controller.ChangeState(StateType.Idle))
                            {
                                _current++;
                            }
                        }
                    }
                    return true;
                default:
                    return false;
            }
        }

        public void Reset()
        {
            _current = 0;
        }
    }
    public struct DieWorkflow : IEnumerator<int>
    {
        public int Current => _current;

        object IEnumerator.Current => _current;
        private int _current;
        private EnemyController _controller;

        public DieWorkflow(EnemyController controller)
        {
            _current = 0;
            _controller = controller;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            switch (_current)
            {
                case 0:
                    {
                        _controller._movable = false;
                        _controller._animator.Play("Die");
                        _current++;
                    }
                    return true;
                case 1:
                    {
                        if (_controller._animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                        {
                            _current++;
                            Destroy(_controller.gameObject);
                        }
                    }
                    return true;
                default:
                    return false;
            }
        }

        public void Reset()
        {
            _current = 0;
        }
    }
    #endregion

    #region AI
    private enum AI
    {
        Idle,
        Think,
        TakeARest,
        MoveLeft,
        MoveRight,
        StartFollow,
        Follow,
        StartAttack,
        Attack
    }
    [SerializeField] private AI _ai;
    // 근처에 다가가면 따라가는지의 여부
    [SerializeField] private bool _aiAutoFollow;
    [SerializeField] private LayerMask _aiDetectMask;
    [SerializeField] private float _aiDetectRange = 2.0f;
    [SerializeField] private bool _aiAttackEnable = false;
    [SerializeField] private float _aiAttackRange = 0.5f;
    [SerializeField] private float _aiThinkTimeMin = 0.1f;
    [SerializeField] private float _aiThinkTimeMax = 2.0f;
    [SerializeField] private float _aiThinkTimer;

    #endregion

    // 상태별 조건: 어떤 상태를 실행하기 위해 어떤 조건이 선행되어야 하는지
    private Dictionary<StateType, Func<bool>> _conditions = new Dictionary<StateType, Func<bool>>();

    public bool ChangeState(StateType newState)
    {
        // 현재상태 == 바꾸려는 상태 -> 바꾸지 않음
        if (current == newState)
            return false;

        // 선행 조건을 만족한다면
        if (_conditions[newState].Invoke())
        {
            current = newState;
            // 실행중일 수도 있으므로(초기화가 안되어 있을 수도 있으므로)
            _workflows[newState].Reset();
            return true;
        }

        return false;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<CapsuleCollider2D>();
        InitializeWorkflows();
    }

    private void Update()
    {
        UpdateAI();
        if (_workflows[current].MoveNext() == false)
            _workflows[current].Reset();
    }

    private void FixedUpdate()
    {
        if (_moveEnable && _movable)
            _rb.MovePosition(_rb.position + _direction * Vector2.right * _moveSpeed * Time.fixedDeltaTime);
    }

    private void InitializeWorkflows()
    {
        _workflows.Add(StateType.Idle, new IdleWorkflow(this));
        _workflows.Add(StateType.Move, new MoveWorkflow(this));
        _workflows.Add(StateType.Attack, new AttackWorkflow(this));
        _workflows.Add(StateType.Hurt, new HurtWorkflow(this));
        _workflows.Add(StateType.Die, new DieWorkflow(this));

        _conditions.Add(StateType.Idle, () => true);
        _conditions.Add(StateType.Move, () => true);
        _conditions.Add(StateType.Attack, () => current == StateType.Idle || current == StateType.Move);
        _conditions.Add(StateType.Hurt, () => true);
        _conditions.Add(StateType.Die, () => true);
    }

    private void UpdateAI()
    {
        switch (_ai)
        {
            case AI.Idle:
                break;
            case AI.Think:
                {
                    _ai = (AI)Random.Range((int)AI.TakeARest, (int)AI.MoveRight + 1);
                    _aiThinkTimer = Random.Range(_aiThinkTimeMin, _aiThinkTimeMax);

                    if (_ai == AI.TakeARest)
                        ChangeState(StateType.Idle);
                    else
                        ChangeState(StateType.Move);
                }
                break;
            case AI.TakeARest:
                {
                }
                break;
            case AI.MoveLeft:
                {
                    direction = DIRECTION_LEFT;
                }
                break;
            case AI.MoveRight:
                {
                    direction = DIRECTION_RIGHT;
                }
                break;
            case AI.StartFollow:
                break;
            case AI.Follow:
                break;
            case AI.StartAttack:
                break;
            case AI.Attack:
                break;
            default:
                break;
        }

        if (_aiThinkTimer > 0)
            _aiThinkTimer -= Time.deltaTime;
        else
            _ai = AI.Think;
    }
}
