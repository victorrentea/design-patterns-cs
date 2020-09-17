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
            var math = new ExpensiveMathCached(new ExpensiveMathImpl());
            //var math = new ExpensiveMathCached(new ExpensiveMathWithLogging(new ExpensiveMath()));

            bizMethod(math);

            bizMethod(new ExpensiveMathImpl());
        }

        private static void bizMethod(ExpensiveMath math)
        {
            math.IsPrime(10000169);
            math.IsPrime(10000169);
        }
    }
    interface ExpensiveMath
    {
        bool IsPrime(int n);
    }
    class ExpensiveMathCached : ExpensiveMath
    {
        private readonly ExpensiveMath wrappedTarget;
        private readonly Dictionary<int, bool> cache = new Dictionary<int, bool>();
        public ExpensiveMathCached(ExpensiveMath wrappedTarget)
        {
            this.wrappedTarget = wrappedTarget;
        }
        public bool IsPrime(int n)
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

    class ExpensiveMathImpl: ExpensiveMath
    {
        public bool IsPrime(int n)
        {
            //for /2 %i
            return true; // 2 sec
        }
    }
}
