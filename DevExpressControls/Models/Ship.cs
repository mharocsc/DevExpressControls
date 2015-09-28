using System.Collections;
using System.Collections.Generic;

namespace DevExpressControls.Models
{
    public class Ship
    {
        public string Description { get; set; }
        public uint Quantity { get; set; }
        public double? Discount { get; set; }
        public double Price { get; set; }
    }

    public static class InvoicesProvider
    {
        public static IList GetInvoices()
        {
            return new List<Ship>() {
                new Ship() { Description = "Chai", Quantity = 12, Discount = 0.1, Price = 18 },
                new Ship { Description = "Konbu", Quantity = 4, Price = 6 },
                new Ship { Description = "Sir Rodney's Scones", Quantity = 19, Price = 10 },
                new Ship { Description = "Guaraná Fantástica", Quantity = 16, Discount = 0.15, Price = 4.5 },
                new Ship { Description = "Gnocchi di nonna Alice", Quantity = 12, Price = 38 },
                new Ship { Description = "Röd Kaviar", Quantity = 19, Price = 34.80 },
                new Ship { Description = "Konbu", Quantity = 8, Discount = 0.2, Price = 15 },
                new Ship { Description = "Original Frankfurter grüne Soße", Quantity = 2, Price = 13 }
            };
        }
    }
}