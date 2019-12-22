using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeInterview;
namespace PracticeInterview.Tests
{
    [TestClass]
    public class ArrayTests
    {
        public DynamicArray strArray;
        [TestMethod]
        public void DynamicArray_Insert()
        {
            //strArray
        }

        [TestInitialize]
        public void InitializeTest()
        {
            strArray = new DynamicArray(10);
        }

        [TestMethod]
        public void Insert()
        {
            strArray.add("a");
            strArray.add("b");
            strArray.add("c");
            strArray.add("d");
        }
    }
}
