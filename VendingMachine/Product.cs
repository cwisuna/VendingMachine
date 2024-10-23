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

        public override string ToString()
        {
            return $"{SlotNumber} | {ProductName} - Price: {Price:C}, Quanitity: {Quantity}";
        }
    }
}
