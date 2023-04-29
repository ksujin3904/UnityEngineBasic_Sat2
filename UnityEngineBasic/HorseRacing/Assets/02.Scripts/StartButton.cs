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
        _start.onClick.AddListener(() => Debug.Log("Start Clicked")); // ���ٽ� ǥ��
        // ��ư�� Ŭ���Ǿ��� �� Debug.Log ȣ��
        
    }

    private void StartClickedLog()
    {
        Debug.Log("Start Clicked");
    }
}
