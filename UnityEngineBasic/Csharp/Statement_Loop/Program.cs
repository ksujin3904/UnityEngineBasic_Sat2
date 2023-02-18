
int count = 0;

while (count <= 5)
{
    Console.WriteLine(count++);
    count++;
}

do
{
    Console.WriteLine(count);
    count++;
}
while(count <= 5);


// for문의 구조
// for(처음 할 연산내용; 반복시작 전 체크할 논리값; 반복후에 할 연산 내용)
// {반복내용}


for (int i = 0; i < 5; i++)
{
    Console.WriteLine(i);
}