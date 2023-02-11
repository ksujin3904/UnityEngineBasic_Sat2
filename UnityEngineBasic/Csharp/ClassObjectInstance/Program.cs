// using 키워드: 특정 namespace를 이 cs파일에서 사용하겠다 
// ClassObjectInstance 프로젝트에 접근
using ClassObjectInstance;

// 값타입, 참조타입
// 값타입: 값을 직접 메모리에 쓰고 읽는 형태, 일반적으로 스택 영역에 할당
// 참조타입: 데이터가 있는 메모리의 주소로 간접 쓰기/읽기를 하는 형태

// new 키워드
// 동적할당 키워드. 런타임에서 메모리를 동적할당할 때 사용
SwordMan swordMan = new SwordMan();
SwordMan swordMan_ = new SwordMan();


// .연산자: 멤버접근연산자
swordMan.Name = "검사1";

swordMan.Attack();
swordMan.Jump();

Console.WriteLine(swordMan.Name);

//---------------예제----------

SwordMan swordMan2 = new SwordMan();
swordMan2.Name = "검사2";

swordMan = swordMan2;
swordMan.Attack();
//검사 1은 이제 호출 불가
Console.WriteLine();
Console.WriteLine("--------------예제1: 오크 클래스 만들기--------------");
Console.WriteLine();

Orc orc1 = new Orc();
Orc orc2 = new Orc();

orc1.Name = "상급오크";
orc1.Old = 210;
orc1.Height = 60.3f;
orc1.Weight = 80.2f;
orc1.Gender = '여';

orc2.Name = "하급오크";
orc2.Old = 140;
orc2.Height = 72.0f;
orc2.Weight = 24.4f;
orc2.Gender = '남';

orc1.SayMyName();
orc1.SayMyInfo();
orc2.SayMyName();
orc2.SayMyInfo();