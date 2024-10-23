using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Drink : Product
    {
        public Drink(string productName, decimal price, int quantity, string slotNumber) : base(productName, price, quantity, slotNumber)
        {
        }
    }
}
