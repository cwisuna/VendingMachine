using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Chip : Product
    {
        public Chip(string productName, decimal price, int quantity, string slotNumber) : base(productName, price, quantity, slotNumber)
        {
        }


    }
}
