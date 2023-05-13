using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Video;

namespace RhythmGame
{
    public static class SongDataLoader
    {
        public static bool isLoaded => songData != null && videoClip != null;
        public static SongData songData;
        public static VideoClip videoClip;

        public static void Load(string songName)
        {
            try
            {

                songData = JsonUtility.FromJson<SongData>(Resources.Load<TextAsset>($"SongDatum/{songName}").ToString());
                videoClip = Resources.Load<VideoClip>($"SongClips/{songName}");
                Debug.Log($"[SongDataLoader]: {songName}의 노래 데이터가 로드되었습니다.");

            }
            catch
            {
                throw new System.Exception($"[SongDataLoader]: {songName}의 노래 데이터 로드 실패. 경로를 정확하게 확인하세요...");
            }
        }

    }
}
