using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace RhythmGame
{
    public class SongDataMaker : MonoBehaviour
    {

        // 사용할 키
        private KeyCode[] _keys = { KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.J, KeyCode.K, KeyCode.L,KeyCode.Space };


        private SongData _songData;
        [SerializeField] private VideoPlayer _videoPlayer;
        private bool _doRecord; // BSS 영역에서 false로 저장

        public void StartRecord()
        {
            // 녹화중일때는 호출 안됨
            if (_doRecord)
                return;

            // 새로운 노트데이터 리스트 생성
            _songData = new SongData(_videoPlayer.clip.name);
            _videoPlayer.Play();
            // startRecode() 호출 시 _doRecode true
            _doRecord = true;
        }

        public void StopRecord()
        {
            if(_doRecord==false)
                return;

            _videoPlayer.Stop();
            // 패널을 띄우고 선택한 저장 경로(디렉토리) 반환
            string dir = UnityEditor.EditorUtility.SaveFilePanelInProject("노래 데이터 저장", _songData.name, "json", string.Empty);
            // (패널 상단 이름, 기본이름, 확장자, 메모)
            System.IO.File.WriteAllText(dir, JsonUtility.ToJson(_songData));
            // IO: 읽고 쓰는

            _songData = null;
            // 멤버변수 비우기
        }

        private void Update()
        {
            if(_doRecord)
                Recording();
        }

        private void Recording()
        {
            //createnotedata를 list에 저장
            for (int i = 0; i < _keys.Length; i++)
            {
                if (Input.GetKeyDown(_keys[i]))
                {
                    _songData.noteList.Add(CreateNoteData(_keys[i]));
                }
            }
        }

        private NoteData CreateNoteData(KeyCode key)
        {
            NoteData noteData = new NoteData()
            {
                key = key,
                time = (float)Math.Round(_videoPlayer.time, 2)
            };
            return noteData;
        }
    }
}
