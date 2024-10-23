using VendingMachine;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    public static void Main()
    {
        string filePath = @"C:\Users\alitt\source\repos\VendingMachine\VendingMachine\vmitems.txt";
        List<Product> products = new List<Product>();   

        foreach (var item in File.ReadLines(filePath))
        {
            var splits = item.Split("|");
            string slotNumber = splits[0];
            string productName = splits[1];
            decimal price = decimal.Parse(splits[2]);
            string productType = splits[3];

            Product product;

            if (productType == "Chip")
            {
                product = new Chip(productName, price, 10, slotNumber);
            }
            else if (productType == "Candy")
            {
                product = new Candy(productName, price, 10, slotNumber);
            }
            else if (productType == "Drink")
            {
                product = new Drink(productName, price, 10, slotNumber);
            }
            else
            {
                product = new Gum(productName, price, 10, slotNumber);
            }

            products.Add(product);
        }

        foreach (var item in products)
        {
            Console.WriteLine(item.ToString());
        }
    }
}