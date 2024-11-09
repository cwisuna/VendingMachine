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
                product = new Chip(productName, price, 5, slotNumber);
            }
            else if (productType == "Candy")
            {
                product = new Candy(productName, price, 5, slotNumber);
            }
            else if (productType == "Drink")
            {
                product = new Drink(productName, price, 5, slotNumber);
            }
            else
            {
                product = new Gum(productName, price, 5, slotNumber);
            }

            products.Add(product);
        }

        while (true)
        {
            Product.DisplayProducts(products);

            Console.WriteLine("Enter a slot number or 'exit' to end:");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "exit" || userInput == null)
            {
                break;
            }

            Product productChosen = products.Find(prd => prd.SlotNumber.Equals(userInput, StringComparison.OrdinalIgnoreCase));

            if (productChosen == null)
            {
                Console.WriteLine("Invalid Slot Number. Try again.");
                Console.WriteLine();
                continue;
            }
            if (productChosen.Quantity <= 0)
            {
                Console.WriteLine("This item is out of stock. Try again.");
                Console.WriteLine();
                continue;
            }

            Console.WriteLine($"You chose {productChosen.GetProductName()} - Price: {productChosen.GetPrice():C}");
            Console.WriteLine("Enter your money. (Maximum amount of $10)");
            string moneyString = Console.ReadLine();
            decimal money = decimal.Parse(moneyString);

            if (money > 10 || money <= 0)
            {
                Console.WriteLine("Invalid amount. Try again.");
                continue;
            }

            productChosen.Quantity -= 1;
            decimal remainingTotal = money - productChosen.Price;
            Console.WriteLine($"Enjoy your {productChosen.ProductName}!");
            Console.WriteLine($"Here is your change: {remainingTotal:C}");
            Console.WriteLine();

            Product.Logger(productChosen, money);

            Console.WriteLine("Would you like to choose another product? (yes or no):");
            string continueInput = Console.ReadLine().ToLower();

            if (continueInput == "no")
            {
                break;
            }
            else if (continueInput != "yes")
            {
                Console.WriteLine("Invalid input. Exiting.");
                break;
            }
        }
    }
}