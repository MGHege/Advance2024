using System;
using System.Collections.Generic;
using System.Linq;

class TempleChallenge
{
    static void Main()
    {
        // Read input sequences
        Queue<int> tools = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
        Stack<int> substances = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
        List<int> challenges = Console.ReadLine().Split().Select(int.Parse).ToList();

        while (true)
        {
            // Take the first tool and the last substance
            int currentTool = tools.Peek();
            int currentSubstance = substances.Peek();
            int result = currentTool * currentSubstance;

            // Check if the result is in the challenges sequence
            if (challenges.Contains(result))
            {
                // If yes, remove the tool, substance, and challenge
                challenges.Remove(result);
                tools.Dequeue();
                substances.Pop();
                if (challenges.Count==0)
                {
                    Console.WriteLine($"Harry found an ostracon, which is dated to the 6th century BCE.");
                    break;
                }
            }
            else
            {
                // If no match, increase the tool, decrease the substance, and handle removal if necessary

                tools.Enqueue(tools.Dequeue() + 1);

                substances.Push(substances.Pop() - 1);
                if (substances.Peek() == 0)
                {
                    substances.Pop();
                }
                if (substances.Count != 0 && tools.Count != 0) continue;
                
                if (challenges.Count <= 0) continue;
                
                Console.WriteLine($"Harry is lost in the temple. Oblivion awaits him.");
                break;
            }
        }

        if (tools.Any())
        {
           
            Console.WriteLine($"Tools: {string.Join(", ", tools)}");
            
          
        }
        if (substances.Any())
        {
            Console.WriteLine($"Substances: {string.Join(", ", substances)}");
        }


        if (challenges.Any())
        {
            Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
        }
    }
}