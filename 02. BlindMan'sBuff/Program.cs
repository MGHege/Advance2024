internal class Program
{
    private static void Main(string[] args)
    {
        int[] n = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        char[,] matrix = new char[n[0], n[1]];

        int startR = -1;
        int startC = -1;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            char[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = data[col];
                if (matrix[row, col] == 'B')
                {
                    startR = row;
                    startC = col;
                }
            }
        }
        int moves = 0;
        int opponents = 0;
        string command;

        while ((command = Console.ReadLine()) != "Finish")
        {
            if (command == "left" && startC - 1 < 0 ||
                command == "right" && startC + 1 == matrix.GetLength(1)  ||
                command == "up" && startR - 1 < 0 ||
                command == "down" && startR + 1 == matrix.GetLength(0)  ||
                command == "left" && matrix[startR, startC - 1] == 'O' ||
                command == "right" && matrix[startR, startC + 1] == 'O' ||
                command == "up" && matrix[startR - 1, startC] == 'O' ||
                command == "down" && matrix[startR + 1, startC] == 'O')
            {
                continue;
            }

            moves++;
            switch (command)
            {
                case "left":
                    startC--;
                    break;
                case "right":
                    startC++;
                    break;
                case "up":
                    startR--;
                    break;
                case "down":
                    startR++;
                    break;
                default:
                    break;
            }
            if (matrix[startR, startC] == 'P')
            {
                opponents++;
                matrix[startR, startC] = '-';
                if (opponents == 3)
                {
                    break;
                }

            }




        }
        Console.WriteLine("Game over!");
       Console.WriteLine($"Touched opponents: {opponents} Moves made: {moves}");
       
    }
}
/*
5 8
- - - O - P - O
- P - O O - - -
- - - - - - O -
- P B - O - - O
- - - O - - - -
up
up
left
Finish
**/