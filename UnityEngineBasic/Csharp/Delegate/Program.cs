using System.Threading.Tasks;
using Delegate;

Player player = new Player();
PlayerUI playerUI = new PlayerUI();
player.onHpchanged += playerUI.Refresh; //observer, listner, subscriber
// player.onHpchanged -= playerUI.Refresh; // 구독 취소

// 람다식 표현: 함수를 선언하지 않고 컴파일러가 인식할 수 있는 키워드들을 생략하고 표현하는 방법
player.onHpchanged += (a) => { Console.WriteLine("UI가 갱신되었습니다!"); };
// action 함수는 int를 받고 void를 반환하므로 void 생략, 함수명 사용 않으니 생략, int type을 받으므로 int 생략 가능

void UIRefreshedAlert_ex(int a)
{
    Console.WriteLine("UI가 갱신되었습니다!");
}

int count = 0;
while (true)
{
    if (count % 4 == 0)
        player.hp -= 2;

    // get접근자로 _hp 반환
    
    // playerUI.Refresh(player.hp);
    // set 접근자로 _hp 사용
    
    Thread.Sleep(1000); // 1초에 한번씩 while문이 돌아감
    count++;

}

