

// 함수
// 함수 선언 => C#에서는 추상화할때만 사용

// 함수 정의
// 반환타입 함수이름 (매개변수1타입 매개변수1이름, 매개변수2타입 매개변수2이름)
// {
//  return 반환값
// }

 int Sum(int op1,int op2)
{
    //return: 이 함수가 할당된 스택 영역의 메모리 제어권을 반환 + 함수의 연산 결과값을 반환
    return op1 + op2;
}

// void: 정해진 타입이 없음
void SayHello()
{
    Console.WriteLine("Hello");
    return; // void 반환 하는 함수의 가장 마지막 라인의 return은 생략 가능.
}

int result = 0;
// 함수 호출
// 함수이름(인자1, 인자2...)
result = Sum(1, 1);
Console.WriteLine($"1 + 1 = { result}");

// [함수 생성 예제]
// 3가지 실수를 더하고 결과 콘솔창에 출력 후 연산결과를 반환하는 함수 작성

double SumByThreeDouble(double op1, double op2, double op3)
{
    // 지역변수: { } 영억 안에서 선언되고 해당 여역을 벗어나면 메모리 해제되는 변수 <-> 전역변수
    double result = op1 + op2 + op3;
    Console.WriteLine($"double 형태 연산: {op1} + {op2} + {op3} = {result}");
    return result;
}

SumByThreeDouble(1.1, 2.2, 3.3);

float SumByThreeFloat(float op1, float op2, float op3)
{
    float result = op1 + op2 + op3;
    Console.WriteLine($"float 형태 연산: {op1} + {op2} + {op3} = {result}");
    return result;
}

SumByThreeFloat(1.1f, 2.2f, 3.3f);
