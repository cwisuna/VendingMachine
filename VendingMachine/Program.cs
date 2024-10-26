using VendingMachine;

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
       Console.WriteLine();

        while (true)
        {
            Console.WriteLine("Enter a slot number or exit to end");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "exit" || userInput == null)
            {
                break;
            };

            Product productChosen = products.Find(prd => prd.SlotNumber.Equals(userInput, StringComparison.OrdinalIgnoreCase));

            if (productChosen == null)
            {
                Console.WriteLine("Invalid Slot Number. Try again");
                continue;
            }
            if (productChosen.Quantity <= 0)
            {
                Console.WriteLine("This item is out of stock. Try again");
                continue ;
            }

            Console.WriteLine($"You chose {productChosen.GetProductName()} - Price: {productChosen.GetPrice():C}");
            Console.WriteLine("Enter your money. (Maximum amount of $10)");
            string moneyString = Console.ReadLine();
            decimal money = decimal.Parse(moneyString);

            if(money > 10 || money <= 0)
            {
                Console.WriteLine("Try Again");
            }
            
            
        }
    }
}