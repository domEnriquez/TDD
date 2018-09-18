using NUnit.Framework;

namespace Queue.Tests
{
    [TestFixture]
    public class QueueTests
    {
        private Queue q;

        [SetUp]
        public void Setup()
        {
            q = new Queue(5);
        }

        [Test]
        public void  zeroSizeForEmptyQueue()
        {
            Assert.AreEqual(0, q.GetSize());
        }

        [Test]
        public void increaseSizeDuringEnqueue()
        {
            q.Enqueue(1);
            Assert.AreEqual(1, q.GetSize());
        }

        [Test]
        public void decreaseSizeDuringDequeue()
        {
            q.Enqueue(1);
            q.Dequeue();

            Assert.AreEqual(0, q.GetSize());
        }

        [Test]
        public void enqueueOneDequeueOne()
        {
            q.Enqueue(1);
            int el = q.Dequeue();

            Assert.AreEqual(1, el);
            Assert.AreEqual(0, q.GetSize());
        }

        [Test]
        public void enqueueOne_EnqueueTwo_DequeueOne_DequeueTwo()
        {
            q.Enqueue(1);
            q.Enqueue(2);
            int num1 = q.Dequeue();
            int num2 = q.Dequeue();

            Assert.AreEqual(1, num1);
            Assert.AreEqual(2, num2);
            Assert.AreEqual(0, q.GetSize());
        }

        [Test]
        public void enqueueOne_dequeueOne_enqueueTwo_dequeueTwo()
        {
            q.Enqueue(1);
            int num1 = q.Dequeue();
            q.Enqueue(2);
            int num2 = q.Dequeue();

            Assert.AreEqual(1, num1);
            Assert.AreEqual(2, num2);
            Assert.AreEqual(0, q.GetSize());
        }

        [Test]
        public void enqueueOne_enqueueTwo_dequeueOne_enqueueThree_dequeueTwo()
        {
            q.Enqueue(1);
            q.Enqueue(2);
            int num1 = q.Dequeue();
            q.Enqueue(3);
            int num2 = q.Dequeue();

            Assert.AreEqual(1, num1);
            Assert.AreEqual(2, num2);
            Assert.AreEqual(1, q.GetSize());
        }

        [Test]
        public void throwInvalidCapacityExceptionWhenCapacityIsNegative()
        {
            Assert.That(() => new Queue(-1), Throws.TypeOf<Queue.QueueIllegalCapacityException>());
        }

        [Test]
        public void throwOverflowExceptionWhenEnqueuedPastCapacity()
        {
            Assert.That(() => enqueueMany(6), Throws.TypeOf<Queue.QueueOverflowException>());
        }

        [Test]
        public void throwUnderflowExceptionWhenDequeuedWithZeroSize()
        {
            Assert.That(() => q.Dequeue(), Throws.TypeOf<Queue.QueueUnderflowException>());
        }

        [Test]
        public void throwUnderflowExceptionWhenPeekWithZeroSize()
        {
            Assert.That(() => q.peek(), Throws.TypeOf<Queue.QueueUnderflowException>());
        }

        [Test]
        public void throwUnderflowExceptionWhenFindWithZeroSize()
        {
            Assert.That(() => q.find(1), Throws.TypeOf<Queue.QueueUnderflowException>());
        }

        [Test]
        public void peekInQueue()
        {
            q.Enqueue(1);
            q.Enqueue(2);
            q.Dequeue();
            q.Enqueue(3);

            Assert.AreEqual(2, q.peek());
            Assert.AreEqual(2, q.GetSize());
        }

        [Test]
        public void findTheIndexOfTheFirstOccurrenceOfANumInQueue()
        {
            q.Enqueue(1);
            q.Enqueue(2);

            Assert.AreEqual(0, q.find(1));
            Assert.AreEqual(1, q.find(2));
        }

        private void enqueueMany(int num)
        {
            for(int i = 0; i < num; i++)
            {
                q.Enqueue(i);
            }
        }
    }
}
