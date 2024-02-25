namespace _01._Monster;
class Program
{
    static void Main(string[] args)
    {
        Queue<int> armorMonster = new Queue<int>(Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
        Stack<int> strenghtSoldeir = new Stack<int>(Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
        int monsterKill = 0;
        while (armorMonster.Count > 0 && strenghtSoldeir.Count > 0)
        {
            int soldeir = strenghtSoldeir.Pop();
            int monster = armorMonster.Dequeue();
            if (soldeir >= monster)
            {
                monsterKill++;
                if (soldeir - monster > 0)
                {
                    strenghtSoldeir.Push(soldeir - monster);
                }

            }
            else
            {
                if (monster - soldeir > 0)
                {
                    armorMonster.Enqueue(monster - soldeir);
                }
            }

        }
        if (armorMonster.Count == 0)
        {
            Console.WriteLine($"All monsters have been killed!");
        }
        if (strenghtSoldeir.Count == 0)
        {
            Console.WriteLine($"The soldier has been defeated.");
        }
        Console.WriteLine($"Total monsters killed: {monsterKill}");
    }
}

