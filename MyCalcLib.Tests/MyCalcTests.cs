using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCalcLib.Tests
{
    [TestClass]
    public class MyCalcTests
    {
        [TestMethod]
        public void Sum_10and20_30returned()
        {
            // arrange - настроить все что необходимо
            int x = 10;
            int y = 20;
            int expected = 30;

            // act действие, кторое нужно выполнить
            MyCalc c = new MyCalc();
            int actual = c.Sum(x, y);

            // assert правильно ли закончился код
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sub_30and20_10returned()
        {
            int x = 30;
            int y = 20;
            int expected = 10;

            MyCalc c = new MyCalc();
            int actual = c.Sub(x, y);

            Assert.AreEqual(expected, actual);
        }
    }
}
