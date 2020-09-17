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
            var math = new ExpensiveMathCached(new ExpensiveMath());
            //var math = new ExpensiveMathCached(new ExpensiveMathWithLogging(new ExpensiveMath()));

            bizMethod(math);

            bizMethod(new ExpensiveMath());
        }

        private static void bizMethod(IExpensiveMath math)
        {
            math.IsPrime(10000169);
            math.IsPrime(10000169);
        }
    }
    interface IExpensiveMath
    {
        bool IsPrime(int n);
    }
    class ExpensiveMathCached : IExpensiveMath
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

    class ExpensiveMath: IExpensiveMath
    {
        public bool IsPrime(int n)
        {
            //for /2 %i
            return true; // 2 sec
        }
    }
}
