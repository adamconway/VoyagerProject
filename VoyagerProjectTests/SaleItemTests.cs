using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VoyagerProject.POS;

namespace VoyagerProjectTests
{
    [TestClass]
    public class SaleItemTests
    {
        [TestMethod]
        public void TestUnitPriceNoBulk()
        {
            var item = new SaleItem('A', 1.00);
            var quantity = 5;

            var expectedPrice = 5.00;
            var actualPrice = item.PriceAtQuantity(quantity);                           

            Assert.AreEqual(expectedPrice, actualPrice, delta: expectedPrice / 100);
        }

        [TestMethod]
        public void TestUnitPriceNoBulkZeroQuantity()
        {
            var item = new SaleItem('A', 1.00);
            var quantity = 0;

            var expectedPrice = 0.00;
            var actualPrice = item.PriceAtQuantity(quantity);

            Assert.AreEqual(expectedPrice, actualPrice, delta: expectedPrice / 100);
        }

        [TestMethod]
        public void TestUnitPriceWithBulkButLessThanRequired()
        {
            var item = new SaleItem('A', 1.00, Tuple.Create(6, 3.00));
            var quantity = 5;

            var expectedPrice = 5.00;
            var actualPrice = item.PriceAtQuantity(quantity);

            Assert.AreEqual(expectedPrice, actualPrice, delta: expectedPrice / 100);
        }

        [TestMethod]
        public void TestUnitPriceWithBulkEqualRequired()
        {
            var item = new SaleItem('A', 1.00, Tuple.Create(6, 3.00));
            var quantity = 6;

            var expectedPrice = 3.00;
            var actualPrice = item.PriceAtQuantity(quantity);

            Assert.AreEqual(expectedPrice, actualPrice, delta: expectedPrice / 100);
        }

        [TestMethod]
        public void TestUnitPriceWithBulkMoreThanRequired()
        {
            var item = new SaleItem('A', 1.00, Tuple.Create(6, 3.00));
            var quantity = 7;

            var expectedPrice = 4.00;
            var actualPrice = item.PriceAtQuantity(quantity);

            Assert.AreEqual(expectedPrice, actualPrice, delta: expectedPrice / 100);
        }

        [TestMethod]
        public void TestPriceUpdateNoBulk()
        {
            var item = new SaleItem('A', 1.00, Tuple.Create(6, 3.00));
            item.UpdatePrice(1.00);
            var quantity = 7;

            var expectedPrice = 7.00;
            var actualPrice = item.PriceAtQuantity(quantity);

            Assert.AreEqual(expectedPrice, actualPrice, delta: expectedPrice / 100);
        }

        [TestMethod]
        public void TestPriceUpdateWithBulk()
        {
            var item = new SaleItem('A', 1.00, Tuple.Create(6, 3.00));
            item.UpdatePrice(1.00, Tuple.Create(3, 1.00));
            var quantity = 7;

            var expectedPrice = 3.00;
            var actualPrice = item.PriceAtQuantity(quantity);

            Assert.AreEqual(expectedPrice, actualPrice, delta: expectedPrice / 100);
        }
    }
}
