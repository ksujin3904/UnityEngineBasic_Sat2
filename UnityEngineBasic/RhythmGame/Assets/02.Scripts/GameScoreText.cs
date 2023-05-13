using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RhythmGame
{
    public class GameScoreText : ScoreingText
    {
        protected override void Awake()
        {
            base.Awake();
            GameStatus.instance.onScoreChanged += (value) =>
            {
                score = value;
            };
        }
    }
}
