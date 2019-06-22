using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task12;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Program.length = Program.rnd.Next(9, 21);

            Program.CreateArrayRnd();
            Program.CreateOrderedAsc();
            Program.CreateOrderedDesc();

            Program.PrintMessage("Исходные массивы: ");
            Program.PrintArr(Program.array);
            Program.PrintArr(Program.descOrder);
            Program.PrintArr(Program.ascOrder);
            
            Program.ShellSort(Program.array);
            Assert.AreNotEqual(Program.removes, 0);
            for (int i=1; i < Program.array.Length; i++)
            {
                bool okay = Program.array[i] >= Program.array[i - 1];
                Assert.AreEqual(okay, true);
            }
            Program.PrintInfo();
            Program.ShellSort(Program.descOrder);
            for (int i = 1; i < Program.descOrder.Length; i++)
            {
                bool okay = Program.descOrder[i] >= Program.descOrder[i - 1];
                Assert.AreEqual(okay, true);
            }
            Assert.AreNotEqual(Program.removes, 0);
            Program.ShellSort(Program.ascOrder);
            for (int i = 1; i < Program.ascOrder.Length; i++)
            {
                bool okay = Program.ascOrder[i] >= Program.ascOrder[i - 1];
                Assert.AreEqual(okay, true);
            }
            Assert.AreEqual(Program.removes, 0);

            Program.compares = 0;
            Program.removes = 0;
            Program.QuickSort(Program.array2, 0, Program.array.Length - 1);
            Program.compares = 0;
            Program.removes = 0;
            Program.QuickSort(Program.descOrder2, 0, Program.array.Length - 1);
            Program.compares = 0;
            Program.removes = 0;
            Program.QuickSort(Program.ascOrder2, 0, Program.array.Length - 1);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Program.length = Program.rnd.Next(9, 21);

            Program.CreateArrayRnd();
            Program.CreateOrderedAsc();
            Program.CreateOrderedDesc();       

            Program.compares = 0;
            Program.removes = 0;
            Program.QuickSort(Program.array2, 0, Program.array.Length - 1);
            Assert.AreNotEqual(Program.removes, 0);
            for (int i = 1; i < Program.array2.Length; i++)
            {
                bool okay = Program.array2[i] >= Program.array2[i - 1];
                Assert.AreEqual(okay, true);
            }
            Program.compares = 0;
            Program.removes = 0;
            Program.QuickSort(Program.descOrder2, 0, Program.array.Length - 1);
            for (int i = 1; i < Program.descOrder2.Length; i++)
            {
                bool okay = Program.descOrder2[i] >= Program.descOrder2[i - 1];
                Assert.AreEqual(okay, true);
            }
            Assert.AreNotEqual(Program.removes, 0);
            Program.compares = 0;
            Program.removes = 0;
            Program.QuickSort(Program.ascOrder2, 0, Program.array.Length - 1);
            for (int i = 1; i < Program.ascOrder2.Length; i++)
            {
                bool okay = Program.ascOrder2[i] >= Program.ascOrder2[i - 1];
                Assert.AreEqual(okay, true);
            }
            Assert.AreEqual(Program.removes, 0);
        }
    }
}
