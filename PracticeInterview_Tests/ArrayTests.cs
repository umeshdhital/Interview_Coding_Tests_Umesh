using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeInterview;
namespace PracticeInterview.Tests
{
    [TestClass]
    public class ArrayTests
    {
        DynamicArray<int> intArray;
        DynamicArray<string> strArray;

        [TestInitialize]
        public void InitializeTest()
        {
            strArray = new DynamicArray<string>(10);
            intArray = new DynamicArray<int>(10);

            strArray.Add("a");
            strArray.Add("b");
            strArray.Add("c");

            intArray.Add(1);
            intArray.Add(2);
            intArray.Add(3);
        }



        [TestMethod]
        public void DynamicArray_Insert()
        {
          
        }

       



        [TestMethod]
        public void Add_String_ShouldAddStringElementIntoArray()
        {
          
           

            Assert.AreEqual("b", strArray.Get(1));
            Assert.AreEqual("a", strArray.Get(0));
            Assert.AreEqual("c", strArray.Get(2));
        }


        [TestMethod]
        public void Add_Integer_ShouldAddIntElementIntoArray()
        {   
           

            Assert.AreEqual(1, intArray.Get(0));
            Assert.AreEqual(2, intArray.Get(1));
            Assert.AreEqual(3, intArray.Get(2));
        }

        [TestMethod]
        public void Contains_ShouldReturnTrurOrFalse()
        {  

            Assert.AreEqual(true, strArray.Contains("a"));
            Assert.AreEqual(false, strArray.Contains("x"));
           // Assert.AreEqual(true, intArray.Contains(3));
        }


    }
}
