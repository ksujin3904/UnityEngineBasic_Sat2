using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    internal class PlayerUI
    {
        private string _hpText;

        // 현재 체력을 문자열로 갱신
        public void Refresh(int hp)
        {
            _hpText = hp.ToString();
            Console.WriteLine(_hpText);
        }
    }
}
