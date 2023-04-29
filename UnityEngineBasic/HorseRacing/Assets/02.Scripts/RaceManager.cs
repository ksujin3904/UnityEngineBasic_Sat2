using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RaceManager : MonoBehaviour
{
    [SerializeField] private Horse[] _horses;
    private Horse[] _horsesFinished;
    private int _grade; // Ŭ���� ���� �� �ʱⰪ�� ���������� ������ BSS�������� ����Ǵµ�, �� ������ ��� ��Ʈ�� 0���� �ʱ�ȭ ��

    /// <summary>
    /// ���ֽ���, ������ ��߽�Ŵ.
    /// </summary>
    public void StartRace()
    {
        // horseŬ������ domove�� true��
        
        for (int i= 0; i<_horses.Length; i++)
        {
            _horses[i].doMove = true;
        }
    }

    /// <summary>
    /// ���� ����. => 1��, 2��, 3���� UI�� ǥ��.
    /// </summary>
    public void FinishRace()
    {
        
    }

    /// <summary>
    /// ���ְ� ���� ���� ����ϴ� �Լ�
    /// </summary>
    public void RegisterFinishedHorse(Horse horse)
    {
        horse.doMove = false;
        _horsesFinished[_grade] = horse;


        if(_grade < _horses.Length - 1) // ������ �������̸� [���� ���� ��: 4<4]
            _grade++;
        else
            FinishRace();
        

    }

    private void Awake()
    {
        _horsesFinished = new Horse[_horses.Length];
    }


}
