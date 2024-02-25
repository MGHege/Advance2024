internal class Program
{
    private static void Main(string[] args)
    {
        Queue<int> coffee = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        Stack<int> milk = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        Dictionary<int, string> drinks = new Dictionary<int, string>
        {{50,"Cortado" },
            {75,"Espresso"},
            {100,  "Capuccino" },
            {150,"Americano" },
            {200, "Latte"},
        };

        Dictionary<string, int> coctel = new Dictionary<string, int>();
        while (coffee.Count > 0 && milk.Count > 0)
        {
            int count = coffee.Peek() + milk.Peek();
            foreach (var kvp in drinks)
            {
                if (kvp.Key == count)
                {
                    if (!coctel.ContainsKey(kvp.Value))
                    {
                        coctel.Add(kvp.Value, 0);
                    }
                    coctel[kvp.Value] += 1;
                    milk.Pop();
                }
                
            }
            if (!drinks.ContainsKey(count))
            {
                milk.Push(milk.Pop() - 5);
            }
            coffee.Dequeue();
        }

        if (coffee.Count == 0 && milk.Count == 0)
        {
            Console.WriteLine($"Nina is going to win! She used all the coffee and milk!");
            Console.WriteLine($"Coffee left: none");
            Console.WriteLine($"Milk left: none");
        }
        else
        {
            Console.WriteLine($"Nina needs to exercise more! She didn't use all the coffee and milk!");
            if (coffee.Any())
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffee)}");
            }
            else
            {
                Console.WriteLine($"Coffee left: none");
            }
            if (milk.Any())
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
            }
            else
            {
                Console.WriteLine($"Milk left: none");

            }

        }
        var coDrinks = coctel.OrderBy(x => x.Value).ThenByDescending(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        foreach (var keyValue in coDrinks)
        {
            Console.WriteLine($"{keyValue.Key}: {keyValue.Value}");
        }
    }
}
/*
20, 35, 100, 27, 56, 30, 30
45, 20, 144, 173, 100, 40, 30

20, 1, 10, 16, 1, 5
205, 70, 30



25, 50, 30
50, 25



**/