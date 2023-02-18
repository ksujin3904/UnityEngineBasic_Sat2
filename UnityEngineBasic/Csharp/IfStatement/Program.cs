bool condition1 = false;
bool condition2 = true;

if (condition1)
{
    //조건 1이 참일때 실행할 내용
    Console.WriteLine("조건 1은 참이다.");
}
else if (condition2)
{
    //조건 1이 거짓이고 조건 2가 참일 떄 실행할 내용
    Console.WriteLine("조건 1이 거짓이고 조건 2가 참이다.");
}
else
{
    // 위 조건들이 모두 거짓일 때 실행할 내용
    Console.WriteLine("조건1, 조건2 모두 거짓이다.");
}