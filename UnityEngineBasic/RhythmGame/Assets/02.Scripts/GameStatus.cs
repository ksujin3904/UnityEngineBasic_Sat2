using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using RhythmGame.Assets._02.Scripts;

namespace RhythmGame
{
    public class GameStatus
    {
        /// <summary>
        /// 일반적인 싱글톤패턴
        /// static instance 참조변수 접근 시 해당 변수가 null이면
        /// 인스턴스를 새로 생성해서라도 참조를 반환해줌.
        /// </summary>


        public static GameStatus instance
        {
            // 싱글톤패턴 instance 초기화 (GameManager.cs에서 MonBehaviour의 Awake()를 사용한 instance 초기화와 동일)
            get
            {
                if(_instance == null)
                    _instance = new GameStatus();
                return _instance;
            }
        }

        private static GameStatus _instance;

        public int currentCombo
        {
            get => _currentCombo;
            set
            {
                _currentCombo = value;
                onCurrentComboChanged?.Invoke(value); // 구독-호출
            }
        }

        private int _currentCombo;
        public event Action<int> onCurrentComboChanged;

        public int score
        {
            get => _socre;
            set
            {
                _socre = value;
                onScoreChanged?.Invoke(value);
            }
        }
        private int _socre;
        public event Action<int> onScoreChanged;

        // score를 증가시켜야 함
        public int coolCount
        {
            get => _coolCount;
            set
            {
                int diff = value - _coolCount;
                value = _coolCount;

                if(diff>0)
                    currentCombo += diff;

                score += diff * Globals.SCORE_COOL;
            }
        }
        private int _coolCount;

        public int greatCount
        {
            get => _greatCount;
            set
            {
                int diff = value - _greatCount;
                value = _greatCount;

                if (diff > 0)
                    currentCombo += diff;

                score += diff * Globals.SCORE_GREAT;
            }
        }
        private int _greatCount;

        public int goodCount
        {
            get => _goodCount;
            set
            {
                int diff = value - _goodCount;
                value = _goodCount;

                if (diff > 0)
                    currentCombo += diff;

                score += diff * Globals.SCORE_GOOD;
            }
        }
        private int _goodCount;

        public int missCount
        {
            get => _missCount;
            set
            {
                int diff = value - _missCount;
                value = _missCount;

                if (diff > 0)
                    currentCombo = 0;

                score += diff * Globals.SCORE_MISS;
            }
        }
        private int _missCount;

        public int badCount
        {
            get => _badCount;
            set
            {
                int diff = value - _badCount;
                value = _badCount;

                if (diff > 0)
                    currentCombo = 0;

                score += diff * Globals.SCORE_BAD;
            }
        }
        private int _badCount;

    }

}
