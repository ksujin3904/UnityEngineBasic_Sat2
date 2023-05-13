using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RhythmGame
{
    public class SongPlayButton : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            // 1. 곡 선택 전에는 버튼 비활성화하여 안눌리도록
            // 2. 노래를 선택하는 순간 버튼 활성화
            Button button = GetComponent<Button>();
            button.onClick.AddListener(GameManager.instance.PlayGame);
            GameManager.instance.onSongSelectedChanged += (songName) =>
            {
                button.interactable = string.IsNullOrEmpty(songName) == false;
            };
            button.interactable = false;
        }
    }
}
