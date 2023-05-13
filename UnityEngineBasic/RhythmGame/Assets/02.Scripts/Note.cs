using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RhythmGame
{
    public class Note : MonoBehaviour
    {
        private float _speed;

        private void Awake()
        {
            _speed = GameManager.instance.speed;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(Vector3.down* _speed * Time.fixedDeltaTime);
        }
    }
}
