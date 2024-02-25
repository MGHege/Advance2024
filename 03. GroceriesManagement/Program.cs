namespace GroceriesManagement
{

    public class Product
    {
        public string Name { get; }
        public double Price { get; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name}: {Price:F2}$";
        }
    }

    public class GroceriesStore
    {
        private List<Product> stall;

        public int Capacity { get; }
        public double Turnover { get; set; }

        public GroceriesStore(int capacity)
        {
            Capacity = capacity;
            Turnover = 0;
            stall = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            if (stall.Count < Capacity && !stall.Any(p => p.Name == product.Name))
            {
                stall.Add(product);
            }
        }

        public bool RemoveProduct(string name)
        {
            Product product = stall.FirstOrDefault(p => p.Name == name);

            if (product != null)
            {
                stall.Remove(product);
                return true;
            }

            return false;
        }

        public string SellProduct(string name, double quantity)
        {
            Product product = stall.FirstOrDefault(p => p.Name == name);

            if (product != null)
            {
                double totalPrice = product.Price * quantity;
                Turnover += totalPrice;
                return $"{product.Name} - {totalPrice:F2}$";
            }

            return "Product not found";
        }

        public string GetMostExpensive()
        {
            Product mostExpensiveProduct = stall.OrderByDescending(p => p.Price).FirstOrDefault();

            return mostExpensiveProduct?.ToString();
        }

        public string CashReport()
        {
            return $"Total Turnover: {Turnover:F2}$";
        }

        public string PriceList()
        {
            return $"Groceries Price List:{Environment.NewLine}{string.Join(Environment.NewLine, stall)}";
        }
    }

    public class StartUp
    {
        static void Main()
        {
            // Sample code usage
            GroceriesStore store = new GroceriesStore(5);

            Product apples = new Product("Apples", 1.20);
            Product oranges = new Product("Oranges", 2.80);
            Product bananas = new Product("Bananas", 1.50);
            Product grapes = new Product("Grapes", 2.20);
            Product watermelon = new Product("Watermelon", 1.90);

            store.AddProduct(apples);
            store.AddProduct(oranges);
            store.AddProduct(bananas);
            store.AddProduct(grapes);
            store.AddProduct(watermelon);

            Product cherries = new Product("Cherries", 5.70);
            store.AddProduct(cherries);

            Console.WriteLine(store.RemoveProduct("Grapes")); // True
            Console.WriteLine(store.RemoveProduct("Pears")); // False

            store.AddProduct(cherries);

            Console.WriteLine(store.SellProduct("Apples", 1.5)); // "Apples - 1.80$"
            Console.WriteLine(store.SellProduct("Bananas", 2.4)); // "Bananas - 3.60$"
            Console.WriteLine(store.SellProduct("Grapes", 2)); // "Product not found"
            Console.WriteLine(store.SellProduct("Apples", 2.5)); // "Apples - 3.00$"
            Console.WriteLine(store.SellProduct("Watermelon", 15)); // "Watermelon - 28.50$"
            Console.WriteLine(store.SellProduct("Cherries", 0.5)); // "Cherries - 2.85$"

            Console.WriteLine(store.GetMostExpensive()); // "Cherries: 5.70$"

            Console.WriteLine(store.CashReport()); // "Total Turnover: 39.75$"

            Console.WriteLine(store.PriceList());
            // "Groceries Price List:
            // Apples: 1.20$
            // Oranges: 2.80$
            // Bananas: 1.50$
            // Watermelon: 1.90$
            // Cherries: 5.70$"
        }
    }
}