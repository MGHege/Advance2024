Stack<int> worms = new Stack<int>(Array.ConvertAll(Console.ReadLine().Split(), int.Parse));
Queue<int> holes = new Queue<int>(Array.ConvertAll(Console.ReadLine().Split(), int.Parse));

int matchesCount = 0;
int allFitt = worms.Count;

while (worms.Count > 0 && holes.Count > 0)
{
    int currentWorm = worms.Pop();
    int currentHole = holes.Dequeue();

    if (currentWorm == currentHole)
    {
        // Worm fits the hole
        matchesCount++;
    }
    else
    {
        // Decrease worm value by 3
        currentWorm -= 3;

        if (currentWorm > 0)
        {
            // Add the modified worm back to the stack
            worms.Push(currentWorm);
        }
    }
}

// Print matches count
Console.WriteLine(matchesCount > 0 ? $"Matches: {matchesCount}" : "There are no matches.");

// Print worms left
if (worms.Count > 0)
{

    Console.WriteLine($"Worms left: {string.Join(", ", worms)}");
}
else
{
    if (matchesCount == allFitt)
    {
        Console.WriteLine($"Every worm found a suitable hole!");
    }
    else
    {
        Console.WriteLine($"Worms left: none");

    }

}

// Print holes left
Console.WriteLine(holes.Count == 0 ? "Holes left: none" : $"Holes left: {string.Join(", ", holes)}");
    
