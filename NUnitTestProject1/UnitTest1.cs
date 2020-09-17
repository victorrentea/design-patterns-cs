using Moq;
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
            var depMock = new Mock<IDep>();
            depMock.Setup(x => x.getSome()).Returns("tataie");
            depMock.Setup(x => x.call()).Verifiable();
            SUT sUT = new SUT(depMock.Object);
            string actual = sUT.stuff();
            Assert.AreEqual("TATAIE", actual);
            depMock.Verify();
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
    public class SUT
    {
        private readonly IDep dep;
        public SUT(IDep dep)
        {
            this.dep = dep;
        }
        public String stuff()
        {
            //dep.call();
            return dep.getSome().ToUpper();
        }

    }

    public interface IDep
    {
        string getSome();
        void call();
    }

    public class Dep : IDep
    {
        public void call()
        {
            throw new NotImplementedException();
        }

        public string getSome()
        {
            throw new NotImplementedException();
        }
    }
}