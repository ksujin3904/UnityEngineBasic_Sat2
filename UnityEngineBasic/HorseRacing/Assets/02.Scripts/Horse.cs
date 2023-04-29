using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    public bool doMove;
    [SerializeField]private float _speed;
    [Range(0.0f,1.0f)] //unity�������� ��밡���� ���� ����
    [SerializeField]private float _stability; // �������� ô��: ���� �󸶳� ���������� �޸�����
    [Range (0.0f,1.0f)]
    [SerializeField] private float _stamina;
    private float _speedRefreshTimeMark;
    private float _staminaRefreshTimeMark;
    private float _speedModified;
    private float _staminaModified;
    private Rigidbody _rb;

    private void Awake()
    {
        _speedModified = _speed;
        _staminaModified = _stamina;
        _rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        if (doMove)
        {
            RefreshSpeed();
            RefreshStamina();
            Move(); // doMove�� ture�� �� Move �Լ� ����
        }
    }

    private void Move()
    {
        // RigidBody�� ������ GameObject�� Transform�� ��Ÿ�ӿ� ���� �����ϸ� speed�� ���� ������ �ٽ� �����ؾ��ϱ� ������
        // RigidBody.Move.Position ���� �̿��ؼ� �����ؾ� ��.
        // (�д� ���� RigidBody.position �̳� Transform.position�̳� �� ���� ����)
                                                                    // ��������
        _rb.MovePosition(transform.position + Vector3.forward * Random.Range(_stability, 1.0f) * _speed * Time.fixedDeltaTime); // �������� 1.0 ����;
    }

    private void RefreshSpeed()
    {
        if(Time.time - _speedRefreshTimeMark > (0.1f / (_staminaModified + 0.001f)))
        {
            _speedModified = Random.Range(_stability, 1.0f) * _speed * (_staminaModified / _stamina);
        }
    }


    private void RefreshStamina()
    {
        if(Time.time - _staminaRefreshTimeMark>((_staminaModified + 0.1f) / (1.0f + 0.1f)))
        {
            if (_staminaModified > 0.1f)
                _staminaModified -= 0.01f;
            _staminaRefreshTimeMark = Time.time;
        }
    }
}
