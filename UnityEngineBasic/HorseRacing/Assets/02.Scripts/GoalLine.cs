using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLine : MonoBehaviour
{
    /// <summary>
    /// Mask: 특정 부분은 감추고 특정 부분은 노출시킴
    /// </summary>

    [SerializeField] private LayerMask _targetMask; // .. 00000010 00000000
    [SerializeField] private RaceManager _raceManager; //RaceManager 참조
    private void OnTriggerEnter(Collider other)
    {
        // *공식처럼 암기*
        if((1<<other.gameObject.layer & _targetMask) > 0)
        {
            _raceManager.RegisterFinishedHorse(other.GetComponent<Horse>());
            // goalline에 닿는 horse는 rigidbody이고, 닿기 위해서는 부피를 가져야 하므로, 부피를 의미하는 capsuleColider를 호출
        }
    }
}
