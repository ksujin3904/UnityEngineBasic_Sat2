using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    // public 만 인스턴스 창에 표시됨 private을 사용하면서 인스턴스 창에 표시되게 하려면 앞에 [Serialize Field]를 붙여주면 됨
    // SerializeField Attribute: 해당 필드를 인스펙터창에 노출시키는 속성


    /// <summary>
    /// 스크립트 인스턴스가 처음 로드될 때 호출.
    /// 스크립트를 컴포넌트로 가지는 GameObject가 활성화 되어야 호출.
    /// MonoBehaviour는 생성자를 통해서 생성할 수 없기 때문에, Awake()에서 멤버들을 초기화 함.
    /// </summary>
    private void Awake()
    {
        Debug.Log("Awake");
    }

    /// <summary>
    /// 이 스크립트 인스턴스가 활성화될 때마다 호출.
    /// + 이 스크립트를 컴포넌트로 가지는 GameObject가 활성화 될 때마다 호출.
    /// </summary>
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    /// <summary>
    /// 모든 멤버변수를 초기값으로 설정. Editor에서만 동작
    /// 스크립트 인스턴스를 Editor에서 GameObject에 AddComponent 했을 때 호출
    /// </summary>
    private void Reset()
    {
        Debug.Log("Reset");

    }

    /// <summary>
    /// 프레임 시작 전에 한번만 호출됨.
    /// Awake로 초기화를 완료한 다른 객체들의 참조를 통해서 초기화해야하는 값들이 있는 경우
    /// 또는 처음에 객체들을 한번 생성해야 하는 경우 등에 사용할 수 있다.
    /// </summary>
    private void Start()
    {
        Debug.Log("Start");
    }

    /// <summary>
    /// 고정 프레임속도로 매프레임 호출
    /// 물리연산 관련 로직은 이 이벤트에서 수행해야 함.
    /// </summary>
    private void FixedUpdate()
    {
        //Debug.Log("FixedUpdate");
    }

    /// <summary>
    /// trigger가 다른 Collider와 겹치는 순간에 호출 (Rigidbody: 질량이 있는 물체 / Collider: 물체의 부피)
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.name}이(가) 트리거 됨.");
    }

    /// <summary>
    /// trigger가 다른 Collider와 겹쳐있으면 계속 호출됨.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"{other.name}이(가) 트리거 되는 중.");
    }

    /// <summary>
    /// trigger가 다른 Collider와 겹쳐 있다가 벗어나는 순간 호출됨
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"{other.name}이(가) 트리거 해제 됨.");
    }


    /// <summary>
    /// Collider/RigidBody가 다른 Rigidbody/Collider와 충돌하는 순간 호출.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name}이(가) 충돌함.");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name}이(가) 충돌중.");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name}이(가) 충돌 끝남.");
    }


    private void OnMouseOver()
    {
        Debug.Log("마우스가 가리키는중...");
    }

    /// <summary>
    /// 매 프레임마다 호출
    /// 기기 성능마다 프레임 주기는 달라짐
    /// </summary>
    private void Update()
    {
        // Debug.Log("Update");
        // Input class: 사용자 입력을 게임 로직에서 처리하기 위한 클래스
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");
        // 앞뒤로 이동: Z값이 증감, Vertical
        // 양옆으로 이동: X값이 증감, Horizontal

        // 거리 = 속력 * 시간
        // 거리변화량 = 속력 * 시간변화량 (업데이트와 다음 업데이트 사이 시간(Time.deltaTime;)
        // 벡터의 크기 = 각축의 제곱의 합에 루트

        // transform.position += new Vector3(h, 0, v).normalized * _moveSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up*r*_rotateSpeed*Time.deltaTime,Space.World);
        transform.Translate(new Vector3(h, 0, v).normalized * _moveSpeed * Time.deltaTime,Space.World);
    }

    /// <summary>
    /// 매 프레임마다 호출
    /// Update 및 Coroutine(Yield)등의 모든 로직연산 후 마지막에 호출 됨.
    /// </summary>
    private void LateUpdate()
    {
        //Debug.Log("LateUpdate");
    }

    /// <summary>
    /// Editor에서 Gizmos를 랜더링 하기위한 연산을 할 때 호출하는 함수
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(Vector3.up * 2.0f, Vector3.one*2.0f);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Vector3.up * 1.0f + Vector3.right*1.0f,1.0f); //<DrawWireSphere: 선으로만 구성 된 스피어
    }


    private void OnApplicationPause(bool pause)
    {
        
    }

    /// <summary>
    /// 스크립트 인스턴스가 비활성화 될 때마다 호출
    /// </summary>
    private void OnDisable()
    {
        Debug.Log("Disabled");
    }

    /// <summary>
    /// 스크립트 인스턴스가 파괴될 때 호출
    /// </summary>
    private void OnDestroy()
    {
        Debug.Log("Destory");
    }



}
