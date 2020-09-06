using System;
using VoyagerProject.POS;

namespace VoyagerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var terminal = new PointOfSaleTerminal();

            terminal.SetPricing('A', 1.25, Tuple.Create(3, 3.0));
            terminal.SetPricing('B', 4.25);
            terminal.SetPricing('C', 1.00, Tuple.Create(6, 5.0));
            terminal.SetPricing('D', 0.75);

            terminal.BulkScan("ABC");
            Console.WriteLine(terminal.CalculateTotal());
        }
    }
}
