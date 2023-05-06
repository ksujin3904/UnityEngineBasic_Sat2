using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    public bool doMove;
    [SerializeField]private float _speed;
    [Range(0.0f,1.0f)] //unity엔진에서 사용가능한 범위 정의
    [SerializeField]private float _stability; // 안정성의 척도: 말이 얼마나 안정적으로 달리는지
    [Range (0.0f,1.0f)]
    [SerializeField] private float _stamina;
    private float _speedRefreshTimeMark;
    private float _staminaRefreshTimeMark;
    private float _speedModified;
    private float _staminaModified;
    private Rigidbody _rb;

    private void Awake()
    {
        _speedModified = _speed;
        _staminaModified = _stamina;
        _rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        if (doMove)
        {
            RefreshSpeed();
            RefreshStamina();
            Move(); // doMove가 ture일 때 Move 함수 실행
        }
    }

    private void Move()
    {
        // RigidBody를 가지는 GameObject의 Transform을 런타임에 직접 수정하면 speed에 대해 연산을 다시 수행해야하기 때문에
        // RigidBody.Move.Position 등을 이용해서 수정해야 함.
        // (읽는 것은 RigidBody.position 이나 Transform.position이나 별 차이 없음)
                                                                    // 난수생성
        _rb.MovePosition(transform.position + Vector3.forward * Random.Range(_stability, 1.0f) * _speed * Time.fixedDeltaTime); // 안정성과 1.0 사이;
    }

    private void RefreshSpeed()
    {
        if(Time.time - _speedRefreshTimeMark > (0.1f / (_staminaModified + 0.001f)))
        {
            _speedModified = Random.Range(_stability, 1.0f) * _speed * (_staminaModified / _stamina);
        }
    }
    

    private void RefreshStamina()
    {
        if(Time.time - _staminaRefreshTimeMark>((_staminaModified + 0.1f) / (1.0f + 0.1f)))
        {
            if (_staminaModified > 0.1f)
                _staminaModified -= 0.01f;
            _staminaRefreshTimeMark = Time.time;
        }
    }
}
