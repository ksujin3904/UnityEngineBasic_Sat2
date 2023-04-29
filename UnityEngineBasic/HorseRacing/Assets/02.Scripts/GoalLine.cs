using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLine : MonoBehaviour
{
    /// <summary>
    /// Mask: Ư�� �κ��� ���߰� Ư�� �κ��� �����Ŵ
    /// </summary>

    [SerializeField] private LayerMask _targetMask; // .. 00000010 00000000
    [SerializeField] private RaceManager _raceManager; //RaceManager ����
    private void OnTriggerEnter(Collider other)
    {
        // *����ó�� �ϱ�*
        if((1<<other.gameObject.layer & _targetMask) > 0)
        {
            _raceManager.RegisterFinishedHorse(other.GetComponent<Horse>());
            // goalline�� ��� horse�� rigidbody�̰�, ��� ���ؼ��� ���Ǹ� ������ �ϹǷ�, ���Ǹ� �ǹ��ϴ� capsuleColider�� ȣ��
        }
    }
}
