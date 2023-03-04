using HorseRacing;
using System.Threading;
// 진행 방식
//
// 말 클래스 필요
// 말 클래스는 달린거리, 이동하기(달리기) 라는 함수를 가집니다.
// 
// 프로그램 시작시
// 말 다섯마리 만들고
// 각 말은 초당 10 ~ 20 (정수형) 범위의 거리를 랜덤하게 전진.
// 각각의 말은 거리 200에 도달하면 도착해서 더이상 전진하지 않고 
// 매초 각 말들이 아직 달리고 있다면 달린 거리를, 도착했다면 도착 상태를 콘솔창에 출력 해줍니다.
// 모든 말이 도착했다면 경주를 끝내고 등수 순서대로 말들의 이름을 콘솔창에 출력 해줍니다.

Random random;
int minSpeed = 10; // 초당 최소 이동 거리
int maxSpeed = 20; // 초당 최대 이동 거리
int goalPosition = 200; //도착지점
bool gameFinished = false; // 게임 종료 여부
int rank = 1;
// 배열로 순위 지정 변수 생성
int currentGrade = 1;

// 말 5마리를 배열로 생성, 말 이름 지정
Horse[] horses = new Horse[5]; 

// 순위용 배열 생성
Horse[] horsesFinished = new Horse[5];

for (int i=0; i<horses.Length; i++)
{
    horses[i] = new Horse();
    horsesFinished[i] = new Horse();
    horses[i].Name = $"{i + 1}번말";
}

int count = 1;
int sec = 0;
while (gameFinished == false) // 게임이 돌아가는 내용
{
    Console.WriteLine($"=================달리는 중...{sec}초 째...================");
    sec++;

    for (int i = 0; i < horses.Length; i++)
    {
        if (horses[i].IsFinished == false)
        {
            random = new Random(); // 거리 랜덤 생성
            int tmpSpeed = random.Next(minSpeed, maxSpeed + 1);
            horses[i].Run(tmpSpeed);
            // horses[i].Run(random.Next(minSpeed, maxSpeed + 1)); << 한줄에 작성 가능
            if (horses[i].TotalDistance >= goalPosition)
            {
                horses[i].IsFinished = true;
                horses[i].Rank = rank;
                rank++;
                // 배열로 순위 지정
                horsesFinished[currentGrade++] = horses[i];

                
            }
            Console.WriteLine($"{horses[i].Name}이 달린거리: {horses[i].TotalDistance}");
        }
        else
        {
            Console.WriteLine($"{horses[i].Name}이 {horses[i].Rank}번째로 도착");
            if (rank > 5)
            {
                gameFinished = true;
            }
        }

    }
    

    Console.WriteLine($"{count}초 째 달리기 완료");
    count++;
    Console.WriteLine();
    Thread.Sleep(1000);
}

Console.WriteLine("===================경주 종료===================");

// for(int j=1; j < rank; j++)
// {
//     for (int i = 0; i < horses.Length; i++)
//     {
//         if (horses[i].Rank == j)
//         {
//             Console.WriteLine($"{j}등은 {horses[i].Name}");
//             break;
//         }
//     }
// 
// }
// 

for(int i=0; i < horsesFinished.Length; i++)
    Console.WriteLine($"{i+1}등은 {horsesFinished[i].Name}");