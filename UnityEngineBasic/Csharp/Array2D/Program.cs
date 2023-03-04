int x, y; // 플레이어 좌표

int[,] map = new int[5, 5]
{
    {0,0,0,0,1},
    {0,1,1,1,1},
    {0,0,0,1,1},
    {1,1,0,0,0},
    {0,1,1,0,0}
};

void DisplayMap()
{
    for (int i = 0; i < map.GetLength(0); i++) //getlength(0) -> 열 갯수
    {
        for (int j = 0; j < map.GetLength(1); j++) //getlength(1) -> 행 갯수
        {
            Console.Write(map[i, j] + " ");
        }
        Console.WriteLine();
    }
}



void MoveRight()
{
    if (x > map.GetLength(1) - 2)
    {
        Console.WriteLine("오른쪽 이동 실패. 맵 경계를 벗어남");
        return; //밑에 코드 실행 안하고 결과 값 반환
    }
    if (map[y, x + 1] == 1)
    {
        Console.WriteLine("오른쪽 이동 실패. 벽이 막고 있음");
        return;
    }
    map[y, x] = 0;
    x++;
    map[y, x] = 5;
    Console.WriteLine($"오른쪽으로 이동. 현재좌표: {x},{y}");
    DisplayMap();
}

void MoveLeft()
{
    if (x <= 0)
    {
        Console.WriteLine("왼쪽 이동 실패. 맵 경계를 벗어남");
        return;
    }

    if (map[y, x - 1] == 1)
    {
        Console.WriteLine("왼쪽 이동 실패. 벽이 막고 있음");
        return;
    }

    map[y, x] = 0;
    x--;
    map[y, x] = 5;
    Console.WriteLine($"왼쪽으로 이동. 현재좌표: {x},{y}");
    DisplayMap();
}

void MoveDown()
{
    if(y > map.GetLength(0)-2)
    {
        Console.WriteLine("아래쪽으로 이동 실패. 맵 경계를 벗어남");
        return ;
    }
    if (map[y + 1, x]==1)
    {
        Console.WriteLine("아래쪽 이동 실패. 벽이 막고 있음");
        return;
    }
    map[y, x] = 0;
    y++;
    map[y, x] = 5;
    Console.WriteLine($"아래쪽으로 이동. 현재좌표: {x},{y}");
    DisplayMap();
}

void MoveUp()
{
    if(y <= 0)
    {
        Console.WriteLine("위쪽으로 이동 실패. 맵 경계를 벗어남");
        return;
    }
    if(map[y-1, x] == 1)
    {
        Console.WriteLine("위쪽으로 이동 실패. 벽이 막고 있음");
        return;
    }
    map[y, x] = 0;
    y--;
    map[y, x] = 5;
    Console.WriteLine($"위쪽으로 이동. 현재좌표: {x},{y}");
    DisplayMap();

}

x = 0;
y = 0;
map[0, 0] = 5;
DisplayMap();

while(true)
{
    Console.WriteLine("플레이어 이동방향을 입력하세요: l / r / u / d");
    string input = Console.ReadLine();

    if (input.Equals("l")) MoveLeft();
    else if (input.Equals("r")) MoveRight();
    else if (input.Equals("u")) MoveUp();
    else if (input.Equals("d")) MoveDown();
    else Console.WriteLine("잘못된 입력입니다. l / r / u / d");

}

// 칸도 입력하기
    
