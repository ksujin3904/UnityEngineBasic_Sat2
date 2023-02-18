int a = 14;
int b = 6;
int c = 0;

c = a + b;
Console.WriteLine(c);
c = a - b;
Console.WriteLine(c);
c = a * b;
Console.WriteLine(c);
c = a / b;
Console.WriteLine(c);
c = a % b;
Console.WriteLine(c);

Console.WriteLine(++c);
Console.WriteLine(c++);
Console.WriteLine(c);

// 관계 연산자
// 같음, 다름, 크기 등 비교 연산자
// 관계연산자의 연산결과가 참이면 true, 거짓이면 false 반환

// 논리 연산자 (bool 연산용 연산자로 연산결과도 bool)
// or, and, xor, not
bool A = true;
bool B = false;

// OR: 둘 중 하나라도 참이면 true, 나머지 false 반환
Console.WriteLine(A | B);

// AND: 둘 다 참일때만 true, 나머지 false
Console.WriteLine(A & B);

// XOR: 둘 중 하나만 참일 때 true, 나머지 false
Console.WriteLine(A ^ B);

// not: bool 값을 반전시키는 연산수행 (true -> false, false-> true)
Console.WriteLine(!A);


// 조건부 OR: 첫번째 피연산자가 true면 B를 읽지 않고 true 반환
Console.WriteLine(A || B);
// 조건부 AND: 첫번째 피연산자가 true면 B를 읽지 않고 false 반환
Console.WriteLine(A && B);

// 비트연산자
// or 연산
Console.WriteLine(a | b);
// and 연산
Console.WriteLine(a & b);
// xor 연산
Console.WriteLine(a ^ b);
// result 연산
Console.WriteLine(~a);
//* 2의 보수
//  2진수로 표현했을 때 모든 자리 수 반전 후 +1
//  컴퓨터가 - 부호를 처리하는 방법
//  ~a + 1 == -a
//  -a + 1 == a

Console.WriteLine(a << 2);
Console.WriteLine(a >> 2);
