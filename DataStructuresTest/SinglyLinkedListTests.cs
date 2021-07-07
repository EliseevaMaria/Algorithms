using DataStructures;
using NUnit.Framework;
using System;

namespace DataStructuresTest
{
    [TestFixture]
    public class SinglyLinkedListTests
    {
        private SinglyLinkedList<int> list;
        [SetUp]
        public void Init()
        {
            list = new SinglyLinkedList<int>();
        }
        
        [Test]
        public void CreateEmptyList_CorrectState()
        {
            Assert.IsTrue(list.IsEmpty);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [Test]
        public void AddFirst_AddLast_OneItem_CorrectState()
        {
            list.AddFirst(1);
            CheckStateSingleNode();

            list.RemoveFirst();
            list.AddLast(1);
            CheckStateSingleNode();
        }

        [Test]
        public void Add_Remove_OneItem_CorrectState()
        {
            list.AddFirst(1);
            list.AddFirst(2);
            list.RemoveFirst();
            CheckStateSingleNode();

            list.AddLast(1);
            list.RemoveLast();
            CheckStateSingleNode();
        }

        [Test]
        public void AddFirst_AddLast_CorrectItemsOrder()
        {
            list.AddFirst(1);
            list.AddFirst(2);

            Assert.AreEqual(2, list.Head.Value);
            Assert.AreEqual(1, list.Tail.Value);

            list.AddLast(3);

            Assert.AreEqual(3, list.Tail.Value);
        }

        [Test]
        public void RemoveFirst_EmptyList_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => list.RemoveFirst());
        }

        [Test]
        public void RemoveLast_EmptyList_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => list.RemoveLast());
        }

        [Test]
        public void RemoveFirst_RemoveLast_CorrectState()
        {
            list.AddFirst(1);
            list.AddFirst(2);
            list.AddLast(3);

            list.RemoveFirst();
            list.RemoveLast();

            CheckStateSingleNode();
            Assert.AreEqual(1, list.Head.Value);
        }

        private void CheckStateSingleNode()
        {
            Assert.AreEqual(1, list.Count);
            Assert.IsFalse(list.IsEmpty);
            Assert.AreSame(list.Head, list.Tail);
        }
    }
}
