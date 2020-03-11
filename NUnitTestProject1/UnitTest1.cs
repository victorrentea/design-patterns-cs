using NUnit.Framework;
using System;

namespace NUnitTestProject1
{
    public class Tests
    {
        public Tests()
        {
            Console.WriteLine("New");

        }
        [SetUp]
        public void Setup()

        {
            Console.WriteLine("Halo before");


        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            TestDelegate action = () => DoThr();
            Assert.Throws<System.Exception>(action);


            
        }
        

        public void DoThr()
        {
            throw new System.Exception();
        }
    }
}