using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Stack.BoundedStack;

namespace Stack.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IStack stack;

        [TestInitialize]
        public void initialize()
        {
            stack = BoundedStack.Make(2);
        }

        [TestMethod]
        public void whenPushOne_ShouldIncreaseStackSize()
        {
            stack.push(1);
            Assert.AreEqual(stack.getSize(), 1);
        }

        [TestMethod]
        public void whenPopOne_ShouldDecreaseSize()
        {
            stack.push(1);
            stack.pop();
            Assert.AreEqual(stack.IsEmpty(), true);
        }

        [TestMethod]
        [ExpectedException(typeof(BoundedStack.OverflowException))]
        public void whenPushedPastLimit_ShouldThrowOverflowException()
        {
            stack.push(1);
            stack.push(1);
            stack.push(1);
        }

        [TestMethod]
        [ExpectedException(typeof(UnderflowException))]
        public void whenPoppedWithZeroSize_ShouldThrowUnderflowException()
        {
            stack.pop();
        }

        [TestMethod]
        [ExpectedException(typeof(IllegalCapacityException))]
        public void whenCreatingStackWithIllegalCapacity_ShouldThrowIllegalCapacityException()
        {
            IStack stack = BoundedStack.Make(-1);
        }

        [TestMethod]
        public void whenPushedOne_ShouldPopOne()
        {
            stack.push(1);
            Assert.AreEqual(stack.pop(), 1);
        }

        [TestMethod]
        public void whenPushedOneAndTwo_ShouldPopTwoAndPopOne()
        {
            stack.push(1);
            stack.push(2);
            Assert.AreEqual(stack.pop(), 2);
            Assert.AreEqual(stack.pop(), 1);
        }

        [TestMethod]
        public void whenCreatingZeroCapacityStack_ShouldReturnEmptySize()
        {
            IStack stack = BoundedStack.Make(0);
            Assert.AreEqual(stack.getSize(), 0);
        }

        [TestMethod]
        public void whenOneIsPushed_TopShouldBeOne()
        {
            stack.push(1);
            Assert.AreEqual(stack.top(), 1);
        }

        [TestMethod]
        public void whenOneAndTwoArePushed_TopShouldBeTwo()
        {
            stack.push(1);
            stack.push(2);
            Assert.AreEqual(stack.top(), 2);
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyStackException))]
        public void whenStackIsEmpty_TopShouldRetunEmptyException()
        {
            stack.top();
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyStackException))]
        public void withZeroCapacityStack_TopShouldThrowEmptyException()
        {
            IStack stack = BoundedStack.Make(0);
            stack.top();
        }

        [TestMethod]
        public void whenOneAndTwoArePushed_ShouldFindOneAndTwo()
        {
            stack.push(1);
            stack.push(2);
            Assert.AreEqual(stack.find(1), 1);
            Assert.AreEqual(stack.find(2), 0);
        }


    }
}
