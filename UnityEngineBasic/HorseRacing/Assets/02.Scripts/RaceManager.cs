using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RaceManager : MonoBehaviour
{
    [SerializeField] private Horse[] _horses;
    private Horse[] _horsesFinished;
    private int _grade; // 클래스 선언 시 초기값을 설정해주지 않으면 BSS영역으로 저장되는데, 이 영역은 모든 비트가 0으로 초기화 됨

    /// <summary>
    /// 경주시작, 말들을 출발시킴.
    /// </summary>
    public void StartRace()
    {
        // horse클래스의 domove를 true로
        
        for (int i= 0; i<_horses.Length; i++)
        {
            _horses[i].doMove = true;
        }
    }

    /// <summary>
    /// 경주 종료. => 1등, 2등, 3등을 UI에 표시.
    /// </summary>
    public void FinishRace()
    {
        
    }

    /// <summary>
    /// 경주가 끝난 말을 등록하는 함수
    /// </summary>
    public void RegisterFinishedHorse(Horse horse)
    {
        horse.doMove = false;
        _horsesFinished[_grade] = horse;


        if(_grade < _horses.Length - 1) // 게임이 진행중이면 [경주 종료 시: 4<4]
            _grade++;
        else
            FinishRace();
        

    }

    private void Awake()
    {
        _horsesFinished = new Horse[_horses.Length];
    }


}
