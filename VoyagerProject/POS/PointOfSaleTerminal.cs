using System;
using System.Collections.Generic;

namespace VoyagerProject.POS
{
    public class PointOfSaleTerminal
    {
        readonly Dictionary<SaleItem, int> CurrentOrder = new Dictionary<SaleItem, int>();
        readonly List<SaleItem> Stockroom = new List<SaleItem>();
        private double Discount = 0.0;

        public void SetPricing(char name, double price, Tuple<int, double> bulkPrice = null)
        {
            var item = FindItemByName(name);

            if (item != null)
            {
                item.UpdatePrice(price, bulkPrice);
            } 
            else
            {
                Stockroom.Add(new SaleItem(name, price, bulkPrice));
            }           
        }

        public void ScanProduct(char productChar)
        {
            var item = FindItemByName(productChar);

            if (item == null)
            {
                Console.WriteLine($"Error: Item '{productChar}' was not found in stockroom");
                return;
                
            }

            CurrentOrder.TryGetValue(item, out var currentQuantity);
            CurrentOrder[item] = currentQuantity + 1;
        }

        public void BulkScan(string products)
        {
            foreach (char c in products)
            {
                ScanProduct(c);
            }
        }

        public double CalculateTotal()
        {
            var total = 0.0;

            foreach(var item in CurrentOrder)
            {
                total += item.Key.PriceAtQuantity(item.Value);
            }

            return total * (1 - Discount);
        }

        private SaleItem FindItemByName(char c)
        {
            return Stockroom.Find(x => x.Name == c);
        }

        // Other Potential Methods (not required)
        public void ClearCurrentOrder()
        {
            CurrentOrder.Clear();
        }

        public void ApplyDiscount(double discount)
        {
            Discount = discount;
        }
    }
}
