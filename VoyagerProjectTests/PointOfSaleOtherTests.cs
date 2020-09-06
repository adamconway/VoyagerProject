using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VoyagerProject.POS;

namespace VoyagerProjectTests
{
    [TestClass]
    public class PointOfSaleOtherTests
    {
        PointOfSaleTerminal terminal;

        [TestInitialize]
        public void Setup()
        {
            terminal = new PointOfSaleTerminal();
        }

        [TestMethod]
        public void TestSetPricing()
        {
            terminal.SetPricing('A', 1.25, Tuple.Create(3, 3.0));
            terminal.ScanProduct('A');

            var expectedTotal = 1.25;
            var actualTotal = terminal.CalculateTotal();

            Assert.AreEqual(expectedTotal, actualTotal, delta: expectedTotal / 100);
        }

        [TestMethod]
        public void TestSetPricingFree()
        {
            terminal.SetPricing('A', 0.00, Tuple.Create(3, 3.0));
            terminal.ScanProduct('A');

            var expectedTotal = 0.00;
            var actualTotal = terminal.CalculateTotal();

            Assert.AreEqual(expectedTotal, actualTotal, delta: expectedTotal / 100);
        }

        [TestMethod]
        public void TestSetPricingUpdate()
        {
            terminal.SetPricing('A', 1.25, Tuple.Create(3, 3.0));
            terminal.SetPricing('A', 1.00, Tuple.Create(3, 3.0));
            terminal.ScanProduct('A');

            var expectedTotal = 1.00;
            var actualTotal = terminal.CalculateTotal();

            Assert.AreEqual(expectedTotal, actualTotal, delta: expectedTotal / 100);
        }

        [TestMethod]
        public void TestDiscount()
        {
            terminal.SetPricing('A', 1.00, Tuple.Create(3, 3.0));
            terminal.ScanProduct('A');
            terminal.ApplyDiscount(0.2);

            var expectedTotal = 0.8;
            var actualTotal = terminal.CalculateTotal();

            Assert.AreEqual(expectedTotal, actualTotal, delta: expectedTotal / 100);
        }

        [TestMethod]
        public void TestClearCart()
        {
            terminal.SetPricing('A', 1.00, Tuple.Create(3, 3.0));
            terminal.ScanProduct('A');
            terminal.ClearCurrentOrder();
            terminal.ScanProduct('A');

            var expectedTotal = 1.00;
            var actualTotal = terminal.CalculateTotal();

            Assert.AreEqual(expectedTotal, actualTotal, delta: expectedTotal / 100);
        }
    }
}
