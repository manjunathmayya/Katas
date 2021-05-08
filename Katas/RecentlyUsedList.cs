using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Katas
{
    [TestFixture]
    public class RecentlyUsedListTest
    {
        [Test]
        public void empty_list_should_return_0()
        {
            //A recently-used-list is initially empty.
            RecentlyUsedList list = new RecentlyUsedList();
            Assert.AreEqual(0, list.Count());
        }

        //The most recently added item is first
        [Test]
        public void test_recent_item_is_first_item()
        {
            RecentlyUsedList list = new RecentlyUsedList();
            list.Add("Hello");
            Assert.AreEqual("Hello", list[0]);
        }

        //the least recently added item is last
        [Test]
        public void test_first_added_item_is_last_item()
        {
            RecentlyUsedList list = new RecentlyUsedList();
            list.Add("Hello");
            list.Add("Hi");
            Assert.AreEqual("Hello", list[list.Count() - 1]);
        }

        //Items can be looked up by index, which counts from zero.
        [Test]
        public void test_indexing_from_zero()
        {
            RecentlyUsedList list = new RecentlyUsedList();
            list.Add("Hello");
            list.Add("John");
            list.Add("How");
            list.Add("Are");
            list.Add("You");

            Assert.AreEqual("You", list[0]);
            Assert.AreEqual("Are", list[1]);
            Assert.AreEqual("How", list[2]);
            Assert.AreEqual("John", list[3]);
            Assert.AreEqual("Hello", list[4]);
        }

        //Items in the list are unique
        [Test]
        public void test_duplicate_entry_should_be_moved()
        {
            RecentlyUsedList list = new RecentlyUsedList();
            list.Add("Hello");
            list.Add("Hi");
            list.Add("Hello");
            Assert.AreEqual("Hello", list[0]);
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual("Hi", list[1]);
        }

        public class RecentlyUsedList
        {
            List<string> list;

            public RecentlyUsedList()
            {
                list = new List<string>();
            }

            public int Count()
            {
                return list.Count;
            }

            public void Add(string item)
            {
                if (list.Contains(item))
                    list.Remove(item);
                list.Insert(0, item);
            }

            public string this[int key]
            {
                get { return list[key]; }
            }
        }
    }
}

