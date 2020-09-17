using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Parent
    {
        public int Wallet()
        {
            if (MamaAgrees())
            {
                return 1;
            } else
            {
                return 0;
            }
        }

        public virtual bool MamaAgrees()
        {
            return false;
        }
    }
    class Parent90 : Parent { }
    class Parent00 : Parent { }
    class Parent80 : Parent { }

    class Neighbour80 : Parent80 { }
    class Neighbour90 : Parent90 { }
    class Neighbour00 : Parent00 { }
    class Child80 : Parent80 { }
    class Child90 : Parent90 { }
    class Child00 : Parent00
    {
        public int GoToBar()
        {
            return Wallet();
        }
        public override bool MamaAgrees()
        {
            return true;
        }
    }
}
