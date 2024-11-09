using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Product
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string SlotNumber { get; set; }

        public Product(string productName, decimal price, int quantity, string slotNumber)
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            SlotNumber = slotNumber;
        }

        public string GetProductName()
        {
            return ProductName;
        }
        public decimal GetPrice()
        {
            return Price;
        }

        public int GetQuantity() 
        {
            return Quantity;
        }

        public string GetSlotNumber() 
        {
            return SlotNumber;
        }

        public static void DisplayProducts(List<Product> products)
        {
            Console.WriteLine();
            Console.WriteLine("Available products:");
            foreach (var item in products)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }

        public static void Logger(Product product, decimal amountGiven)
        {
            string logFilePath = @"C:\Users\alitt\source\repos\VendingMachine\VendingMachine\TransactionFile.txt";
            string log = $"{product.ProductName} | {product.Price} | {DateTime.Now}";
            File.AppendAllText(logFilePath, log);

        }
        public override string ToString()
        {
            return $"{SlotNumber} | {ProductName} - Price: {Price:C}, Quanitity: {Quantity}";
        }
    }
}
