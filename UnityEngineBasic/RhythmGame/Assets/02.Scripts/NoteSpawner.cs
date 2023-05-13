using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RhythmGame
{
    public class NoteSpawner : MonoBehaviour
    {
        public KeyCode key;
        [SerializeField] private Note _notePrefab;
        private Color _color;

        // 스포너 생성함수
        public void Spawn()
        {
            Note note = Instantiate(_notePrefab, transform.position, Quaternion.identity);
            note.GetComponent<SpriteRenderer>().color = _color;
            note.transform.localScale = transform.lossyScale; // <-> localScale
        }

        private void Awake()
        {
            _color = GetComponent<SpriteRenderer>().color;
        }

        private void Start()
        {
            NoteSpawnManager.instance.Register(this);
        }
    }
}
