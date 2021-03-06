using System;
using System.Collections;
using MbUnit.Core.Exceptions;
using MbUnit.Framework;

namespace MbUnit.Framework.Tests.Asserts
{
    [TestFixture]
    public class CollectionAssert_Test
    {
        ArrayList arr;
        ArrayList arrSynced;
        ArrayList arr2;
        ArrayList arr2Synced;

        [TestFixtureSetUp]
        public void CreateArrayList()
        {
            arr = new ArrayList();
            arr.Add("One");
            arr.Add("Two");
            arr.Add("Three");
            arr.Add("Four");


            arr2 = new ArrayList();
            arr2.Add("One");
            arr2.Add("Two");
            arr2.Add("Three");
            arr2.Add("Four");

            arrSynced = ArrayList.Synchronized(arr);
            arr2Synced = ArrayList.Synchronized(arr2);
        }

        #region Synchronized
        [Test, Ignore("Failing")]
        public void AreSyncRootEqual()
        {
            CollectionAssert.AreSyncRootEqual(arrSynced, arr2Synced);
        }

        [Test]
        public void IsSynchronized()
        {
            CollectionAssert.IsSynchronized(arrSynced);
        }

        [Test]
        public void AreIsSynchronizedEqual()
        {
            CollectionAssert.AreIsSynchronizedEqual(arrSynced, arr2Synced);
        }

        [Test]
        public void AreIsSynchronizedEqualBool()
        {
            CollectionAssert.AreIsSynchronizedEqual(true, arrSynced);
            CollectionAssert.AreIsSynchronizedEqual(false, arr2);
        }
        #endregion

        #region Equal
        [Test]
        public void AreElementsEqual()
        {
            CollectionAssert.AreElementsEqual(arr, arr2);
        }

        [Test, ExpectedException(typeof(AssertionException))]
        public void AreElementsEqualExpectedNullFail()
        {
            CollectionAssert.AreElementsEqual(null, arr2);
        }

        [Test, ExpectedException(typeof(AssertionException))]
        public void AreElementsEqualActualNullFail()
        {
            CollectionAssert.AreElementsEqual(arr, null);
        }

        [Test]
        public void AreElementsEqualNull()
        {
            CollectionAssert.AreElementsEqual(null, null);
        }

        [Test, ExpectedException(typeof(AssertionException))]
        public void AreElementsEqualUnequalLengthFail()
        {
            ArrayList arr3 = new ArrayList();
            arr3.Add("One");
            arr3.Add("Two");
            arr3.Add("Three");
            arr3.Add("Four");
            arr3.Add("Five");

            CollectionAssert.AreElementsEqual(arr, arr3);
        }

        [Test]
        public void AreEqual()
        {
            CollectionAssert.AreEqual(arr, arr2);
        }

        [Test]
        public void AreEqualSwap()
        {
            CollectionAssert.AreEqual(arr2, arr);
        }

        [Test, ExpectedException(typeof(AssertionException))]
        public void AreEqualExpectedNullFail()
        {
            CollectionAssert.AreEqual(null, arr2);
        }

        [Test, ExpectedException(typeof(AssertionException))]
        public void AreEqualActualNullFail()
        {
            CollectionAssert.AreEqual(arr, null);
        }

        [Test]
        public void AreEqualNullFail()
        {
            CollectionAssert.AreEqual(null, null);
        }


        [Test, ExpectedException(typeof(AssertionException))]
        public void AreEqualFail()
        {
            ArrayList arr3 = new ArrayList();
            arr3.Add("One");

            CollectionAssert.AreEqual(arr, arr3);
        }

        [Test, ExpectedException(typeof(AssertionException))]
        public void AreEqualSameLengthFail()
        {
            ArrayList arr3 = new ArrayList();
            arr3.Add("One");
            arr3.Add("Two");
            arr3.Add("One");
            arr3.Add("Two");

            CollectionAssert.AreEqual(arr, arr3);
        }

        #endregion

        #region Count
        [Test]
        public void AreCountEqual()
        {
            CollectionAssert.AreCountEqual(4, arr);
        }

        [Test]
        public void AreCountEqualNull()
        {
            CollectionAssert.AreCountEqual(null, null);
        }

        [Test]
        public void IsCountCorrect()
        {
            CollectionAssert.IsCountCorrect(arr);
        }

        [Test, ExpectedArgumentNullException]
        public void IsCountCorrectNull()
        {
            CollectionAssert.IsCountCorrect(null);
        }

        #endregion

        #region AllItemsAreInstancesOfType
        [Test()]
        public void ItemsOfType()
        {
            ArrayList al = new ArrayList();
            al.Add("x");
            al.Add("y");
            al.Add("z");
            CollectionAssert.AllItemsAreInstancesOfType(al, typeof(string));
            CollectionAssert.AllItemsAreInstancesOfType(al, typeof(string), "test");
            CollectionAssert.AllItemsAreInstancesOfType(al, typeof(string), "test {0}", "1");

            al = new ArrayList();
            al.Add(new System.Data.DataSet());
            al.Add(new System.Data.DataSet());
            al.Add(new System.Data.DataSet());
            CollectionAssert.AllItemsAreInstancesOfType(al, typeof(System.Data.DataSet));
            CollectionAssert.AllItemsAreInstancesOfType(al, typeof(System.Data.DataSet), "test");
            CollectionAssert.AllItemsAreInstancesOfType(al, typeof(System.Data.DataSet), "test {0}", "1");
        }

        [Test()]
        [ExpectedException(typeof(AssertionException))]
        public void ItemsOfTypeFailMsg()
        {
            ArrayList al = new ArrayList();
            al.Add("x");
            al.Add("y");
            al.Add(new object());
            CollectionAssert.AllItemsAreInstancesOfType(al, typeof(string), "test");
        }

        [Test()]
        [ExpectedException(typeof(AssertionException))]
        public void ItemsOfTypeFailMsgParam()
        {
            ArrayList al = new ArrayList();
            al.Add("x");
            al.Add("y");
            al.Add(new object());
            CollectionAssert.AllItemsAreInstancesOfType(al, typeof(string), "test {0}", "1");
        }

        [Test()]
        [ExpectedException(typeof(AssertionException))]
        public void ItemsOfTypeFailNoMsg()
        {
            ArrayList al = new ArrayList();
            al.Add("x");
            al.Add("y");
            al.Add(new object());
            CollectionAssert.AllItemsAreInstancesOfType(al, typeof(string));
        }
        #endregion

        #region AllItemsAreNotNull
        [Test()]
        public void ItemsNotNull()
        {
            ArrayList al = new ArrayList();
            al.Add("x");
            al.Add("y");
            al.Add("z");

            CollectionAssert.AllItemsAreNotNull(al);
            CollectionAssert.AllItemsAreNotNull(al, "test");
            CollectionAssert.AllItemsAreNotNull(al, "test {0}", "1");

            al = new ArrayList();
            al.Add(new System.Data.DataSet());
            al.Add(new System.Data.DataSet());
            al.Add(new System.Data.DataSet());

            CollectionAssert.AllItemsAreNotNull(al);
            CollectionAssert.AllItemsAreNotNull(al, "test");
            CollectionAssert.AllItemsAreNotNull(al, "test {0}", "1");
        }

        [Test]
        [ExpectedException(typeof(AssertionException))]
        public void ItemsNotNullFail()
        {
            ArrayList al = new ArrayList();
            al.Add("x");
            al.Add(null);
            al.Add("z");

            CollectionAssert.AllItemsAreNotNull(al);
        }

        [Test]
        [ExpectedException(typeof(AssertionException))]
        public void ItemsNotNullFailMsgParam()
        {
            ArrayList al = new ArrayList();
            al.Add("x");
            al.Add(null);
            al.Add("z");

            CollectionAssert.AllItemsAreNotNull(al, "test {0}", "1");
        }

        [Test]
        [ExpectedException(typeof(AssertionException))]
        public void ItemsNotNullFailMsg()
        {
            ArrayList al = new ArrayList();
            al.Add("x");
            al.Add(null);
            al.Add("z");

            CollectionAssert.AllItemsAreNotNull(al, "test");
        }
        #endregion

        #region AllItemsAreUnique

        [Test]
        public void Unique()
        {
            ArrayList al = new ArrayList();
            al.Add(new object());
            al.Add(new object());
            al.Add(new object());

            CollectionAssert.AllItemsAreUnique(al);
            CollectionAssert.AllItemsAreUnique(al, "test");
            CollectionAssert.AllItemsAreUnique(al, "test {0}", "1");

            al = new ArrayList();
            al.Add("x");
            al.Add("y");
            al.Add("z");

            CollectionAssert.AllItemsAreUnique(al);
            CollectionAssert.AllItemsAreUnique(al, "test");
            CollectionAssert.AllItemsAreUnique(al, "test {0}", "1");
        }

        [Test]
        [ExpectedException(typeof(AssertionException))]
        public void UniqueFail()
        {
            object x = new object();
            ArrayList al = new ArrayList();
            al.Add(x);
            al.Add(new object());
            al.Add(x);

            CollectionAssert.AllItemsAreUnique(al);
        }

        [Test]
        [ExpectedException(typeof(AssertionException))]
        public void UniqueFailMsg()
        {
            object x = new object();
            ArrayList al = new ArrayList();
            al.Add(x);
            al.Add(new object());
            al.Add(x);

            CollectionAssert.AllItemsAreUnique(al, "test");
        }

        [Test]
        [ExpectedException(typeof(AssertionException))]
        public void UniqueFailMsgParam()
        {
            object x = new object();
            ArrayList al = new ArrayList();
            al.Add(x);
            al.Add(new object());
            al.Add(x);

            CollectionAssert.AllItemsAreUnique(al, "test {0}", "1");
        }

        #endregion

        #region AreEquivalent

        [Test]
        public void Equivalent()
        {
            System.Data.DataSet x = new System.Data.DataSet();
            System.Data.DataSet y = new System.Data.DataSet();
            System.Data.DataSet z = new System.Data.DataSet();

            ArrayList set1 = new ArrayList();
            ArrayList set2 = new ArrayList();

            set1.Add(x);
            set1.Add(y);
            set1.Add(z);

            set2.Add(z);
            set2.Add(y);
            set2.Add(x);

            CollectionAssert.AreEquivalent(set1, set2);
            CollectionAssert.AreEquivalent(set1, set2, "test");
            CollectionAssert.AreEquivalent(set1, set2, "test {0}", "1");
        }

        [Test]
        [ExpectedException(typeof(AssertionException))]
        public void EquivalentFailOne()
        {
            System.Data.DataSet x = new System.Data.DataSet();
            System.Data.DataSet y = new System.Data.DataSet();
            System.Data.DataSet z = new System.Data.DataSet();

            ArrayList set1 = new ArrayList();
            ArrayList set2 = new ArrayList();

            set1.Add(x);
            set1.Add(y);
            set1.Add(z);

            set2.Add(x);
            set2.Add(y);
            set2.Add(x);

            CollectionAssert.AreEquivalent(set1, set2, "test {0}", "1");
        }

        [Test]
        [ExpectedException(typeof(AssertionException))]
        public void EquivalentFailTwo()
        {
            System.Data.DataSet x = new System.Data.DataSet();
            System.Data.DataSet y = new System.Data.DataSet();
            System.Data.DataSet z = new System.Data.DataSet();

            ArrayList set1 = new ArrayList();
            ArrayList set2 = new ArrayList();

            set1.Add(x);
            set1.Add(y);
            set1.Add(x);

            set2.Add(x);
            set2.Add(y);
            set2.Add(z);

            CollectionAssert.AreEquivalent(set1, set2, "test {0}", "1");
        }

        [Test]
        public void AreEquivalent_UsesValueEqualityForStrings()
        {
            string[] stringArray1 = { "ab", "bc", "cd" };
            string[] stringArray2 = { "cd", string.Format("b{0}", "c"), "ab" };
            CollectionAssert.AreEquivalent(stringArray1, stringArray2);
        }

        [Test, ExpectedException(typeof(AssertionException))]
        public void AreEquivalent_DifferentSizeAreNotEquivalent()
        {
            string[] stringArray1 = { "a", "b" };
            string[] stringArray2 = { "a", "b", "c" };
            CollectionAssert.AreEquivalent(stringArray1, stringArray2);
        }

        [Test, ExpectedException(typeof(AssertionException))]
        public void AreEquivalent_DifferentItemsAreNotEquivalent()
        {
            string[] stringArray1 = { "a", "b", "c" };
            string[] stringArray2 = { "a", "b", "d" };
            CollectionAssert.AreEquivalent(stringArray1, stringArray2);
        }
        #endregion

        #region AreNotEqual

        [Test]
        public void AreNotEqual()
        {
            ArrayList set1 = new ArrayList();
            ArrayList set2 = new ArrayList();
            set1.Add("x");
            set1.Add("y");
            set1.Add("z");
            set2.Add("x");
            set2.Add("y");
            set2.Add("x");

            CollectionAssert.AreNotEqual(set1, set2);
            CollectionAssert.AreNotEqual(set1, set2, "test");
            CollectionAssert.AreNotEqual(set1, set2, "test {0}", "1");
        }

        #endregion

        #region AreNotEquivalent

        [Test]
        public void NotEquivalent()
        {
            System.Data.DataSet x = new System.Data.DataSet();
            System.Data.DataSet y = new System.Data.DataSet();
            System.Data.DataSet z = new System.Data.DataSet();

            ArrayList set1 = new ArrayList();
            ArrayList set2 = new ArrayList();

            set1.Add(x);
            set1.Add(y);
            set1.Add(z);

            set2.Add(x);
            set2.Add(y);
            set2.Add(x);

            CollectionAssert.AreNotEquivalent(set1, set2);
            CollectionAssert.AreNotEquivalent(set1, set2, "test");
            CollectionAssert.AreNotEquivalent(set1, set2, "test {0}", "1");
        }

        #endregion

        #region Contains
        [Test]
        public void Contains()
        {
            System.Data.DataSet x = new System.Data.DataSet();
            System.Data.DataSet y = new System.Data.DataSet();
            System.Data.DataSet z = new System.Data.DataSet();
            System.Data.DataSet a = new System.Data.DataSet();

            ArrayList al = new ArrayList();
            al.Add(x);
            al.Add(y);
            al.Add(z);

            CollectionAssert.Contains(al, x);
            CollectionAssert.Contains(al, x, "test");
            CollectionAssert.Contains(al, x, "test {0}", "1");
        }

        [Test]
        public void Contains_UsesValueTypeEqualityForStringTypes()
        {
            string[] stringArray = { string.Format("a{0}", "c"), "b" };
            CollectionAssert.Contains(stringArray, "ac");
        }

        [Test]
        public void Contains_NullItemSearchSupported()
        {
            string[] stringArray = { "a", "b", null };
            CollectionAssert.Contains(stringArray, null);
        }

        [Test, ExpectedException(typeof(AssertionException))]
        public void Contains_RaisesAssertionExceptionIfItemNotFound()
        {
            string[] stringArray = { "a", "b", "c" };
            CollectionAssert.Contains(stringArray, "d");
        }
        #endregion

        #region DoesNotContain
        [Test]
        public void DoesNotContain()
        {
            System.Data.DataSet x = new System.Data.DataSet();
            System.Data.DataSet y = new System.Data.DataSet();
            System.Data.DataSet z = new System.Data.DataSet();
            System.Data.DataSet a = new System.Data.DataSet();

            ArrayList al = new ArrayList();
            al.Add(x);
            al.Add(y);
            al.Add(z);

            CollectionAssert.DoesNotContain(al, a);
            CollectionAssert.DoesNotContain(al, a, "test");
            CollectionAssert.DoesNotContain(al, a, "test {0}", "1");
        }
        #endregion

        #region IsSubsetOf

        [Test]
        public void IsSubsetOf_UsesValueEqualityForStrings()
        {
            string[] superset = { "ab", "bc", "cd" };
            string[] subset = { "cd", string.Format("b{0}", "c") };
            CollectionAssert.IsSubsetOf(subset, superset);
        }

        [Test, ExpectedException(typeof(AssertionException))]
        public void IsSubsetOf_AssertExceptionWhenSupersetIsSmallerThanSubset()
        {
            string[] superset = { "a", "b" };
            string[] subset = { "a", "b", "c" };
            CollectionAssert.IsSubsetOf(subset, superset);
        }

        [Test, ExpectedException(typeof(AssertionException))]
        public void IsSubsetOf_DifferentItemInSubsetRaisesAssertException()
        {
            string[] superset = { "a", "b", "c" };
            string[] subset = { "a", "d" };
            CollectionAssert.IsSubsetOf(subset, superset);
        }

        //[Test]
        //public void IsSubsetOf()
        //{
        //    System.Data.DataSet x = new System.Data.DataSet();
        //    System.Data.DataSet y = new System.Data.DataSet();
        //    System.Data.DataSet z = new System.Data.DataSet();
        //    System.Data.DataSet a = new System.Data.DataSet();

        //    ArrayList set1 = new ArrayList();
        //    set1.Add(x);
        //    set1.Add(y);
        //    set1.Add(z);

        //    ArrayList set2 = new ArrayList();
        //    set2.Add(y);
        //    set2.Add(z);

        //    CollectionAssert.IsSubsetOf(set1, set2);
        //    CollectionAssert.IsSubsetOf(set1, set2, "test");
        //    CollectionAssert.IsSubsetOf(set1, set2, "test {0}", "1");
        //}
        #endregion

        #region IsNotSubsetOf
        [Test]
        public void IsNotSubsetOf()
        {
            System.Data.DataSet x = new System.Data.DataSet();
            System.Data.DataSet y = new System.Data.DataSet();
            System.Data.DataSet z = new System.Data.DataSet();
            System.Data.DataSet a = new System.Data.DataSet();

            ArrayList set1 = new ArrayList();
            set1.Add(x);
            set1.Add(y);
            set1.Add(z);

            ArrayList set2 = new ArrayList();
            set1.Add(y);
            set1.Add(z);
            set2.Add(a);

            CollectionAssert.IsNotSubsetOf(set1, set2);
            CollectionAssert.IsNotSubsetOf(set1, set2, "test");
            CollectionAssert.IsNotSubsetOf(set1, set2, "test {0}", "1");
        }
        #endregion
    }
}
