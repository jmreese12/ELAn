using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ELAn;

namespace ELAnTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMatrixAddition()
        {
            Matrix m1 = new int[,] 
            { 
             { 0, 1 },
             { 2, 3 } 
            };

            Matrix m2 = new int[,] 
            { 
             { 0, 3 },
             { 4, 5 } 
            };

            Assert.AreEqual((m1 + m2), new int[,]
            { 
              { 0, 4 },
              { 6, 8 }
            });
        }
    }
}
