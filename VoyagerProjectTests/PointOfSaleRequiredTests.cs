using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VoyagerProject.POS;

namespace VoyagerProjectTests
{
    [TestClass]
    public class PointOfSaleRequiredTests
    {
        PointOfSaleTerminal terminal;

        [TestInitialize]
        public void Setup()
        {
            terminal = new PointOfSaleTerminal();
            terminal.SetPricing('A', 1.25, Tuple.Create(3, 3.0));
            terminal.SetPricing('B', 4.25);
            terminal.SetPricing('C', 1.00, Tuple.Create(6, 5.0));
            terminal.SetPricing('D', 0.75);
        }

        [TestMethod]
        public void TestInput1()
        {
            terminal.BulkScan("ABCDABA");
            var expectedTotal = 13.25;
            var actualTotal = terminal.CalculateTotal();

            Assert.AreEqual(expectedTotal, actualTotal, delta: expectedTotal / 100);
        }

        [TestMethod]
        public void TestInput2()
        {
            terminal.BulkScan("CCCCCCC");
            var expectedTotal = 6.00;
            var actualTotal = terminal.CalculateTotal();

            Assert.AreEqual(expectedTotal, actualTotal, delta: expectedTotal / 100);
        }

        [TestMethod]
        public void TestInput3()
        {
            terminal.BulkScan("ABCD");
            var expectedTotal = 7.25;
            var actualTotal = terminal.CalculateTotal();

            Assert.AreEqual(expectedTotal, actualTotal, delta: expectedTotal / 100);
        }
    }
}
