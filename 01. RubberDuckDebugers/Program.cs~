namespace _01._RubberDuckDebugers;
class Program
{
    static void Main(string[] args)
    {
        Queue<int> programmer = new Queue<int>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        Stack<int> tasks=new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

        int darth = 0;
        int thor = 0;
        int bigBlue = 0;
        int smallYellow = 0;
        while (programmer.Any()&&tasks.Any())
        {
            int count = programmer.Peek() * tasks.Peek();
            if (count<241)
            {
                programmer.Dequeue(); tasks.Pop();
                if (count <= 60)
                {
                    darth++;
                }
                else if (count > 60 && count <= 120)
                {
                    thor++;
                }
                else if (count > 120 && count <= 180)
                {
                    bigBlue++;
                }
                else if (count > 180 && count <= 240)
                {
                    smallYellow++;
                }
            }
              
            else
            {
                programmer.Enqueue(programmer.Dequeue());
                tasks.Push(tasks.Pop()-2);
            }
        }
        Console.WriteLine($"Congratulations, all tasks have been completed! Rubber ducks rewarded: ");
        Console.WriteLine($"Darth Vader Ducky: {darth}");
        Console.WriteLine($"Thor Ducky: {thor}");
        Console.WriteLine($"Big Blue Rubber Ducky: {bigBlue}");
        Console.WriteLine($"Small Yellow Rubber Ducky: {smallYellow}");

    }
}

