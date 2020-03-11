using System;
using TechTalk.SpecFlow;

namespace NUnitTestProject1
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            System.Console.WriteLine(p0);

        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            System.Console.WriteLine("add");

        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            System.Console.WriteLine("display");

        }
    }
}
