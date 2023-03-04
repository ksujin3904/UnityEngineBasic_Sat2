using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    internal class Character : Creature
    {
        // override(함수를 재정의)
        // 부모타입의 멤버 프로퍼티 / 함수를 재정의 할 때 사용하는 키워드
        public override void Breath()
        {
            throw new NotImplementedException();
        }

        public override int GetLv()
        {
            // base: 부모타입의 현재 객체
            return base.GetLv();
        }
    }
}
