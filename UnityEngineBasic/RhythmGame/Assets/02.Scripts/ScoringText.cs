using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RhythmGame
{
    public class ScoreingText : MonoBehaviour
    {
        private TMP_Text _score;
        
        public int score
        {
            get => _after;
            set
            {
                _after = value;
                _delta = (int)((_after - _before) / _duration);
            }
        }
        private int _before;
        private int _after;
        private float _duration = 0.1f;
        private int _delta;

        protected virtual void Awake()
        {
            _score = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            if(_before < _after)
            {
                _before += (int)(_delta * Time.deltaTime);

                if(_before>_after)
                    _before = _after;

                _score.text = _before.ToString();
            }
        }
    }
}
