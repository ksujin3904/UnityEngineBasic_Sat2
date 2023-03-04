using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    // 구조체 (structure)
    // 멤버 변수와 멤버 함수를 가지며, 값타입이다.
    // < 구조체 선정 조건 >
    // 1. 16byte 이하, 넘어가면 클래스 쓰는 것을 권장 [레지스터가 한번에 읽는 최대 크기]
    // 2. 함수의 인자 전달 혹은 값 연산이 빈번 할 경우
    internal struct Stats
    {
        // 멤버변수 생성
        public int STR;
        public int DEX;
        public int INT;
        public int LUK;

        // 구조체는 생성자에서 모든 멤버변수를 초기화 해야함
        // 클래스와 다르게 구조체는 비슷하게 생겼지만 값타입이고, 생성자로 동적 할당할 때 힙 영역이 아니라 스택영역에 저장되며, 
        // 생성자를 호출할 때 원본데이터를 가지고 할당하는 것이 아니라 그 크기만큼 스택공간에만 할당하기 때문에 쓰레기값이 들어있다.

        public Stats()
        {
            STR = 0;
            DEX = 0;
            INT = 0;
            LUK = 0;
        }

        // 함수(생성자) 오버로드
        // 동일한 이름의 다른 함수를 정의하는 기능
        // 함수를 원본의 주소에 접근할 때, 함수의 이름만을 가지고 접근하지 않고 파라미터타입들도 함께 접근하기 때문에

        public Stats(int STR, int DEX, int INT, int LUK)
        {
            this.STR = STR;
            this.DEX = DEX;
            this.INT = INT;
            this.LUK = LUK;
        }

        // 멤버함수 생성
        public int GetCombatScore()
        {
            return STR + DEX + INT + LUK;
        }
    }   
    
       
}
