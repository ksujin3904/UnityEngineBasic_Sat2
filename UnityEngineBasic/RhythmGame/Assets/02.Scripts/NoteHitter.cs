using RhythmGame.Assets._02.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace RhythmGame
{
    public class NoteHitter : MonoBehaviour
    {
        [SerializeField] private KeyCode _key;
        private SpriteRenderer _spriteRenderer;
        private Color _colorOrigin;
        private Color _colorPressed;
        [SerializeField] private LayerMask _targetMask;
        public event Action<HitJudge> onHit;



        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _colorOrigin = _spriteRenderer.color;
            _colorOrigin.a = 0.5f;
            _colorPressed = _colorOrigin;
            _colorPressed.a = 1.0f;
        }

        private void Update()
        {
            // 키가 눌리면...
            if(Input.GetKeyDown(_key))
            {
                _spriteRenderer.color = _colorPressed;
                Hit();
            }

            else if(Input.GetKeyUp(_key))
            {
                _spriteRenderer.color = _colorOrigin;
            }
        }

        private void Hit()
        {
            HitJudge judge = HitJudge.None;
            Collider2D[] cols = Physics2D.OverlapBoxAll(point: transform.position,
                                                        size: new Vector2(transform.lossyScale.x * 0.5f, Globals.HIT_JUDGE_RANGE_MISS),
                                                        angle: 0.0f,
                                                        layerMask: _targetMask);

            if (cols.Length > 0)
            {
                // 질의(Query): 특정 자료에서 원하는 자료를 탐색 또는 취합하거나, 특정 조건에 따른 새로운 자료를 만드는 등의 행위
                // OrderBy: 정렬기능
                IOrderedEnumerable<Collider2D> colsFiltered = cols.OrderBy(x => Mathf.Abs(transform.position.y - x.transform.position.y));

                float distance = Mathf.Abs(colsFiltered.First().transform.position.y - transform.position.y);

                if (distance < Globals.HIT_JUDGE_RANGE_COOL / 2.0f)
                {
                    judge = HitJudge.Cool;
                    GameStatus.instance.coolCount++;
                }
                else if (distance < Globals.HIT_JUDGE_RANGE_GREAT / 2.0f)
                {
                    judge = HitJudge.Great;
                    GameStatus.instance.greatCount++;
                }
                else if (distance < Globals.HIT_JUDGE_RANGE_GOOD / 2.0f)
                {
                    judge = HitJudge.Good;
                    GameStatus.instance.goodCount++;
                }
                else
                {
                    judge = HitJudge.Miss;
                    GameStatus.instance.missCount++;
                }
                Destroy(colsFiltered.First().gameObject);
                onHit?.Invoke(judge);
            }
        }
    }
}
