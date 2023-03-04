using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    internal class Human
    {
        // 클래스의 멤버 구조체변수는
        // 힙영역의 클래스타입 객체에 같이 할당된다.
        public Stats stats; //<< 구조체 크기만큼 클래스처럼 스택영역이 아닌 힙영역에 할당
    }
}
