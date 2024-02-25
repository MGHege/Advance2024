namespace FirstExam;
class Program
{
    static void Main(string[] args)
    {
        Stack<int> money = new Stack<int>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        Queue<int> prices = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        int countFood = 0;
        while (money.Any()&&prices.Any())
        {
            if (prices.Peek()>money.Peek())
            {
                prices.Dequeue();
                money.Pop();
            }
            else if (prices.Peek() == money.Peek())
            {
                prices.Dequeue();
                money.Pop();
                countFood++;
            }
            else
            { int change = money.Peek() - prices.Peek();
                if (money.Count==1)
                {
                    money.Pop();
                }
                else
                {
                    money.Push(money.Pop() + change);
                }
                
                prices.Dequeue();
                countFood++;
            }
        }
        if (countFood>0)
        {
            if (countFood<4)
            {
                if (countFood ==1)
                {
                    Console.WriteLine($"Henry ate: {countFood} food.");
                }
                else
                {
                    Console.WriteLine($"Henry ate: {countFood} foods.");
                }
                
            }
            else
            {
                Console.WriteLine($"Gluttony of the day! Henry ate {countFood} foods.");
                
            }
        }
        else
        {
            Console.WriteLine($"Henry remained hungry. He will try next weekend again.");
        }
    }
}
/*
9 5 8 18
18 12 10 5
 
 
18 10 8 9
5 10 12 18

1 1 4 5 9 9 9
9 15 18 13 10

1 1 4 5 6 2 3 2
17 8 18 19 20

 */
