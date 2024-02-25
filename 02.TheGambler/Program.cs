using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char[,] matrix = new char[n, n];
        int initialAmount = 100;
        int totalAmount = initialAmount;
        int gamblerRow = -1;
        int gamblerCol = -1;

        // Initialize the matrix and find the initial gambler position
        for (int i = 0; i < n; i++)
        {
            string row = Console.ReadLine();
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = row[j];
                if (row[j] == 'G')
                {
                    gamblerRow = i;
                    gamblerCol = j;
                }
            }
        }

        while (true)
        {
            string command = Console.ReadLine();

            if (command == "end")
            {
                break;
            }

            matrix[gamblerRow, gamblerCol] = '-'; // Remove the gambler from the current position

            // Update gambler position based on the command
            switch (command)
            {
                case "up":
                    gamblerRow = Math.Max(0, gamblerRow - 1);
                    break;
                case "down":
                    gamblerRow = Math.Min(n - 1, gamblerRow + 1);
                    break;
                case "left":
                    gamblerCol = Math.Max(0, gamblerCol - 1);
                    break;
                case "right":
                    gamblerCol = Math.Min(n - 1, gamblerCol + 1);
                    break;
            }

            char currentCell = matrix[gamblerRow, gamblerCol];

            // Process the current cell
            if (currentCell == 'W')
            {
                totalAmount += 100;
            }
            else if (currentCell == 'P')
            {
                totalAmount -= 200;
                if (totalAmount <= 0)
                {
                    Console.WriteLine("Game over! You lost everything!");
                    return;
                }
            }
            else if (currentCell == 'J')
            {
                totalAmount += 100000;
                Console.WriteLine("You win the Jackpot!");
                Console.WriteLine($"End of the game. Total amount: {totalAmount}$");
                return;
            }

            matrix[gamblerRow, gamblerCol] = 'G'; // Place the gambler in the new position
        }

        Console.WriteLine($"End of the game. Total amount: {totalAmount}$");

        // Print the final matrix
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}