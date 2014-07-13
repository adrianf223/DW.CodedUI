using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests
{
    [TestClass]
    public class DoTests
    {
        [TestMethod]
        public void Action_ThreeTimes_AllGotCalledOnce()
        {
            var firstExecutionCount = 0;
            var secondExecutionCount = 0;
            var thirdExecutionCount = 0;

            Do.Action(() => { ++firstExecutionCount; })
              .And.Action(() => { ++secondExecutionCount; })
              .And.Action(() => { ++thirdExecutionCount; });

            Assert.AreEqual(1, firstExecutionCount);
            Assert.AreEqual(1, secondExecutionCount);
            Assert.AreEqual(1, thirdExecutionCount);
        }

        [TestMethod]
        public void Action_ThreeTimesAndOneRepeat_AllGotCalledTwice()
        {
            int firstExecutionCount = 0;
            int secondExecutionCount = 0;
            int thirdExecutionCount = 0;

            Do.Action(() => { ++firstExecutionCount; })
              .And.Action(() => { ++secondExecutionCount; })
              .And.Action(() => { ++thirdExecutionCount; })
              .Repeat(1);

            Assert.AreEqual(2, firstExecutionCount);
            Assert.AreEqual(2, secondExecutionCount);
            Assert.AreEqual(2, thirdExecutionCount);
        }

        [TestMethod]
        public void Action_ThreeTimesAndTwoRepeat_AllGotCalledThreeTimes()
        {
            int firstExecutionCount = 0;
            int secondExecutionCount = 0;
            int thirdExecutionCount = 0;

            Do.Action(() => { ++firstExecutionCount; })
              .And.Action(() => { ++secondExecutionCount; })
              .And.Action(() => { ++thirdExecutionCount; })
              .Repeat(2);

            Assert.AreEqual(3, firstExecutionCount);
            Assert.AreEqual(3, secondExecutionCount);
            Assert.AreEqual(3, thirdExecutionCount);
        }

        [TestMethod]
        public void Action_ThreeTimesWithTwoRepeatAndTwoWithFourRepeats_CallsActionsAccordingly()
        {
            int firstExecutionCount = 0;
            int secondExecutionCount = 0;
            int thirdExecutionCount = 0;
            int fourthExecutionCount = 0;
            int fifthExecutionCount = 0;

            Do.Action(() => { ++firstExecutionCount; })
              .And.Action(() => { ++secondExecutionCount; })
              .And.Action(() => { ++thirdExecutionCount; })
              .Repeat(2)
              .And.Action(() => { ++fourthExecutionCount; })
              .And.Action(() => { ++fifthExecutionCount; })
              .Repeat(4);

            Assert.AreEqual(3, firstExecutionCount);
            Assert.AreEqual(3, secondExecutionCount);
            Assert.AreEqual(3, thirdExecutionCount);
            Assert.AreEqual(5, fourthExecutionCount);
            Assert.AreEqual(5, fifthExecutionCount);
        }
    }
}