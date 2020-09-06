using System;
using System.Collections.Generic;
using System.Text;

namespace VoyagerProject.POS
{
    public class SaleItem
    {
        public char Name { get; }
        private double UnitPrice;
        private Tuple<int, double> BulkPrice;

        public SaleItem(char name, double price, Tuple<int, double> bulkPrice = null)
        {
            this.Name = name;
            this.UnitPrice = price;
            this.BulkPrice = bulkPrice;
        }

        public void UpdatePrice(double price, Tuple<int, double> bulkPrice = null)
        {
            this.UnitPrice = price;
            this.BulkPrice = bulkPrice;
        }

        public double PriceAtQuantity(int quantity)
        {
            var totalPrice = 0.0;

            while (BulkPrice != null && BulkPrice.Item1 <= quantity)
            {
                totalPrice += BulkPrice.Item2;
                quantity -= BulkPrice.Item1;
            };

            totalPrice += quantity * UnitPrice;
            return totalPrice;
        }
    }
}
