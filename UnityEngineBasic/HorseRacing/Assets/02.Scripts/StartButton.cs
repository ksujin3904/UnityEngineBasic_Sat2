using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] private Button _start;

    private void Awake()
    {
        _start.onClick.AddListener(StartClickedLog);
        _start.onClick.AddListener(() => Debug.Log("Start Clicked")); // 람다식 표현
        // 버튼이 클릭되었을 때 Debug.Log 호출
        
    }

    private void StartClickedLog()
    {
        Debug.Log("Start Clicked");
    }
}
