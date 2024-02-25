﻿namespace _02._TheSquirrel;
class Program
{
    static void Main(string[] args)
    {
        int range = int.Parse(Console.ReadLine());
        char[,] matrix = new char[range,range];
        int startRow = -1;
        int startCol = -1;
        string[] command = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            string value = Console.ReadLine();
            for (int r = 0; r < matrix.GetLength(1); r++)
            {
                matrix[i, r] = value[r];
                if (matrix[i, r]=='s')
                {
                    startRow = i;
                    startCol = r;
                }
                if (true)
                {

                }
            }
        }
        int hazelnuts = 0;
        for (int a = 0; a < command.Length; a++)
        {
            if ((command[a] == "left" && startCol == 0) ||
                    (command[a] == "right" && startCol == matrix.GetLength(1) - 1) ||
                    (command[a] == "up" && startRow == 0) ||
                    (command[a] == "down" && startRow == matrix.GetLength(0) - 1))
            {
                Console.WriteLine("The squirrel is out of the field.");
                Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
                break;
            }
            else
            {
                if (command[a] == "left")
                {
                    startCol--;
                }
                else if (command[a] == "right")
                {
                    startCol++;
                }
                else if (command[a] == "up")
                {
                    startRow--;
                }
                else if (command[a] == "down")
                {
                    startRow++;
                }

                if (matrix[startRow, startCol] == 'h')
                {
                    hazelnuts++;
                    matrix[startRow, startCol] = '*';
                    if (hazelnuts == 3)
                    {
                        
                        Console.WriteLine("Good job! You have collected all hazelnuts!");
                        Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
                        break;
                    }
                    continue;
                }
                if (matrix[startRow, startCol] == 't')
                {
                    Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                    Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
                    break;
                }
            }
           

        }
        if (command.Length==0)
        {
            Console.WriteLine($"There are more hazelnuts to collect.");
        }

    }


    
}//87-100

