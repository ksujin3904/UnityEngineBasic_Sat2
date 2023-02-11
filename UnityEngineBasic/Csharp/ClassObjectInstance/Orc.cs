using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassObjectInstance
{
    internal class Orc
    {
        /*
         * Orc 클래스 만들기
         * Orc는 문자열 이름, 정수 나이, 실수 키, 실수 몸무게, 문자 성별
         * 자신의 이름을 출력하는 SayMyName 기능 (이름만 출렦)
         * 자신의 정보를 출력하는 SayMyInfo 기능 (모든 멤버 출력)
         * 
         * 두 객체를 생성하는 데
         * 1. 이름 상급오크, 나이 210세, 키 60.3, 몸무게 80.2, 성별 여 이고, 
         * 2. 이름 하급오크, 나이 140세, 키 72.0, 몸무게 24.4, 성별 남 이다.
         * 둘 다 자기 이름 및 정보를 출력하는 코드 작성
         */

        public string Name;
        public int Old;
        public float Height;
        public float Weight;
        public char Gender;

        public void SayMyName()
        {
            Console.WriteLine($"나는 {Name}...");
        }

        public void SayMyInfo()
        {
            Console.WriteLine($"{Name}인 내 나이는 {Old}세, 키는 {Height}, 몸무게는 {Weight}, 성별은 {Gender}자다.");
        }

    }
}
