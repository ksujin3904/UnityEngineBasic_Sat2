using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    //interface
    // 함수, 프로퍼티, 이벤트를 추상화 해서 다중상속을 하기 위한 용도로 사용
    // 접근제한자가 기본적으로 public

    internal interface IAttackable
    {
        void Attack();
    }
}
