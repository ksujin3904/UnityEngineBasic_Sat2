using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

namespace RhythmGame
{
    public class PopUpText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _content;
        [SerializeField] private Vector3 _startPos;
        [SerializeField] private Vector3 _dir = Vector3.up;
        [SerializeField] private float _moveSpeed = 0.5f;
        [SerializeField] private float _fadeSpeed = 0.5f;

        public void PopUp()
        {
            transform.position = _startPos;
            Color tmp = _content.color;
            tmp.a = 1.0f;
            _content.color = tmp;
            gameObject.SetActive(true);
        }

        public void PopUp(string content)
        {
            _content.text = content;
            PopUp();
        }

        private void Update()
        {
            transform.Translate(_dir*_moveSpeed * Time.deltaTime);

            float a = _content.color.a - _fadeSpeed * Time.deltaTime;

            if (a < 0.0f)
            {
                gameObject.SetActive(true);
            }
            else
            {
                Color tmp = _content.color;
                tmp.a = a;
                _content.color = tmp;

            }


        }


    }
}
