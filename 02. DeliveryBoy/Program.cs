using System;

class PizzaDeliverySimulation
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int rows = int.Parse(input[0]);
        int cols = int.Parse(input[1]);

        char[,] matrix = new char[rows, cols];

        int boyRow = -1, boyCol = -1;

        for (int i = 0; i < rows; i++)
        {
            string row = Console.ReadLine();
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = row[j];
                if (row[j] == 'B')
                {
                    boyRow = i;
                    boyCol = j;
                }
            }
        }
        int newRow = boyRow, newCol = boyCol;
        bool pizzaCollected = false;
        bool deliverySuccessful = false;
        string commands;
        while ((commands = Console.ReadLine()) != "")
        {
            string command = commands;

            switch (command)
            {
                case "up":
                    newRow--;
                    break;
                case "down":
                    newRow++;
                    break;
                case "right":
                    newCol++;
                    break;
                case "left":
                    newCol--;
                    break;
            }

            if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols)
            {
                if (matrix[newRow, newCol] == '-')
                {
                    matrix[newRow, newCol] = '.';

                }
                if (matrix[newRow, newCol] == 'P')
                {
                    matrix[newRow, newCol] = 'R';
                    pizzaCollected = true;
                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                }
                else if (matrix[newRow, newCol] == 'A')
                {
                    matrix[newRow, newCol] = 'P';
                    deliverySuccessful = true;
                    Console.WriteLine("Pizza is delivered on time! Next order...");
                    matrix[boyRow, boyCol] = 'B';
                    break;
                }
            }
            else
            {
                matrix[boyRow, boyCol] = ' ';
                Console.WriteLine("The delivery is late. Order is canceled.");
                break;
            }
        }

        PrintMatrix(matrix, rows, cols);
        static void PrintMatrix(char[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
/* /50-100
5 6
*----A
*B***-
*-***-
*----P
******
down
down
left
right
right
right
right
right
up
 
5 6
*----A
*B***-
*-***-
*----P
******
down
down
right
right
right
right
up
up
up
 
 
 */