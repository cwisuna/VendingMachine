using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Gum : Product
    {
        public Gum(string productName, decimal price, int quantity, string slotNumber) : base(productName, price, quantity, slotNumber)
        {
        }
    }
}
