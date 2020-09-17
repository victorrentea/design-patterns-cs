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
            var math = new ExpensiveMathCached();

            math.IsPrimeWithCache(10000169);
            math.IsPrimeWithCache(10000169);
        }
    }
    class ExpensiveMathCached 
    {
        private readonly ExpensiveMath wrappedTarget;
        private readonly Dictionary<int, bool> cache = new Dictionary<int, bool>();
        public ExpensiveMathCached(ExpensiveMath wrappedTarget)
        {
            this.wrappedTarget = wrappedTarget;
        }
        public bool IsPrimeWithCache(int n)
        {
            if (cache.ContainsKey(n))
            {
                return cache[n];
            }

            var result = wrappedTarget.IsPrime(n);

            cache[n] = result;
            return result;
        }
    }

    class ExpensiveMath
    {
        public bool IsPrime(int n)
        {
            //for /2 %i
            return true; // 2 sec
        }
    }
}
