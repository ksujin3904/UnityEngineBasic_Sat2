using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace RhythmGame
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<GameManager>();
                    DontDestroyOnLoad(_instance.gameObject);
                }
                return _instance;
            }
        }
        private static GameManager _instance;
        public enum State
        {
            Idle,
            LoadSongData,
            WaitUntilSongDataLoaded,
            StartGame,
            WaitUntilGameFinished,
            DisplayResult,
            WaitForUser
        }
        public State current;
        public string songSelected
        {
            get
            {
                return _songSelected;
            }
            set
            {
                _songSelected = value;
                onSongSelectedChanged?.Invoke(value);
            }
        }
        private string _songSelected;
        public float speed = 4.0f;
        public event Action<string> onSongSelectedChanged;

        public void PlayGame()
        {
            if (current != State.Idle)
                return;
            current++;
        }


        private void Awake()
        {
            if(_instance != null)
            {

                Destroy(gameObject);
            }

            // this를 하게되면 gamemanager의 객체의 파괴를 막음 (gamemanager의 인스턴스인 스크립트의 파괴 막음)
            // gameoObject는 hierachy의 gamemanager의 파괴를 막음
        }

        private void Update()
        {
            switch (current)
            {
                case State.Idle:
                    break;
                case State.LoadSongData:
                    {
                        current++;
                        SongDataLoader.Load(_songSelected);
                    }
                    break;
                case State.WaitUntilSongDataLoaded:
                    {
                        if (SongDataLoader.isLoaded)
                        {
                            SceneManager.LoadScene("Play");
                            current++;
                        }

                    }
                    break;
                case State.StartGame:
                    {
                        NoteSpawnManager.instance.StartSpawn();
                        current++;
                    }
                    break;
                case State.WaitUntilGameFinished:
                    break;
                case State.DisplayResult:
                    break;
                case State.WaitForUser:
                    break;
                default:
                    break;
            }
        }
    }
}