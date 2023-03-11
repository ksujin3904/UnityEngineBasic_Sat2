using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    internal class Slime : Enemy, IAttackable
    {
        public void Attack()
        {
            Console.WriteLine("슬라임이 공격했다.");
        }
    }
}
