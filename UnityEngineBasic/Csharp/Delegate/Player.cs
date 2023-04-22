using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    internal class Player
    {
        public int hp
        {
            get
            {
                return _hp;
            }
            set
            {
                _hp = value;
                // _hp를 할경우 멀티쓰레드 때문에 value값이 아닌 연산 전 _hp가 출력될 수 있음
                // onHpchanged(value); // 대리자 호출
                // onHpchanged.Invoke(value); // 인자로 넘겨받은 값의 레이스 컨디션 해결
                onHpchanged?.Invoke(value); // ?: Null check 연산자. Null 이 아닐겨우 대리자 호출
            }
        }
        private int _hp;
        public int hpMin = 0;
        public int hpMax = 100;
        // 대리자 타입 선언 (함수의 입력/반환 값(타입) 설정)
        public delegate void HpChangedHandeler(int hp);
        public event HpChangedHandeler onHpchanged;
        // 현재 선언한 onHpchanged는 값이 변경되면 호출되는 것으로 외부에서 호출 해 수정하게 하면 안됨 but, private으로 하면 구독자체가 불가능
        // 외부 호출을 막기 위해 event 한정자 사용
        // event : 해당 대리자를 += 과 -=의 L-Value(왼쪽에 위치하는 값(대입하기 위해)) 로써만 사용할 수 있도록 제한하는 한정자. (외부 직접 호출을 막는 제한자)
        
        // public Func<int, bool> func;
        // int a;
        // bool b = false;
        // 
        // 
        // private bool Dummy(int dummy)
        // {
        //     bool dm = false;
        //     if (dummy == 0)
        //         dm = true;
        //     return dm;
        // }

        public Player()
        {
            hp = hpMax;
        }
    }
}
