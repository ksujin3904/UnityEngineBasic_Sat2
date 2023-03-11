using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    internal abstract class Enemy : Creature
    {
        public override void Breath()
        {
            Console.WriteLine("적이 숨을 쉰다."); ;
        }
    }
}
