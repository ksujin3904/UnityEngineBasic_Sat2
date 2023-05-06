using System;
using UnityEngine;

namespace RhythmGame
{
    /// <summary>
    /// System.Serializable 속성 (System namespace안에 존재)
    /// Serialize는 기본 자료형에 대해서만 가능 (사용자 정의 자료형은 불가)
    /// 사용자정의 자료형도 Serialization 되도록 해주는 속성
    /// </summary>
    [Serializable]
    public struct NoteData
    {
        public KeyCode key;
        public float time;
    }
}