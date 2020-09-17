using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class DecoratorPlay
    {
        public static void Main()
        {
            var math = new ExpensiveMath();

            math.IsPrimeWithCache(10000169);
            math.IsPrimeWithCache(10000169);
        }
    }

    class ExpensiveMath
    {
        private Dictionary<int, bool> cache = new Dictionary<int, bool>();

        public bool IsPrimeWithCache(int n)
        {
            if (cache.ContainsKey(n))
            {
                return cache[n];
            }

            var result = IsPrime(n);

            cache[n] = result;
            return result;
        }
        private bool IsPrime(int n)
        {
            //for /2 %i
            return true; // 2 sec
        }
    }
}
