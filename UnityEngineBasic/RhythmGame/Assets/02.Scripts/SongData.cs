using System;
using System.Collections.Generic;

namespace RhythmGame
{
    /// <summary>
    /// 어떤 노래가 어떤 노트들로 이루어져있는지에 대한 데이터
    /// </summary>
    [Serializable]
    public class SongData
    {
        public string name;
        public List<NoteData> noteList;

        public SongData(string name)
        {
            this.name = name;
            noteList = new List<NoteData>();
        }
    }
}
