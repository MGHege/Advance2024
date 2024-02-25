﻿int n = int.Parse(Console.ReadLine());
char[,] matrix = new char[n, n];
int startR = -1;
int startC = -1;
for (int row = 0; row < matrix.GetLength(0); row++)
{
    string data = Console.ReadLine();
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = data[col];
        if (matrix[row, col] == 'M')
        {
            startR = row;
            startC = col;
        }
    }
}
int points = 0;
string input;
while ((input = Console.ReadLine()) != "End")
{
    string command = input;
    matrix[startR, startC] = '-';
    if (command == "up" && startR == 0 ||
        command == "down" && startR == matrix.GetLength(0) - 1 ||
        command == "left" && startC == 0 ||
        command == "right" && startC == matrix.GetLength(1) - 1)
    {
        Console.WriteLine($"Don't try to escape the playing field!");
        continue;
    }

    switch (command)
    {
        case "up":
            startR--;
            break;
        case "down":
            startR++;
            break;
        case "left":
            startC--;
            break;
        case "right":
            startC++;
            break;
        default:
            break;
    }
    if (matrix[startR, startC] != '-')
    {
        if (matrix[startR, startC] == 'S')
        {
            matrix[startR, startC] = '-';
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        startR = row;
                        startC = col;
                    }
                }
            }
            points -= 3;
        }
        else
        {
            points += int.Parse(matrix[startR, startC].ToString());
        }
    }


    matrix[startR, startC] = 'M';
    if (points >= 25)
    {
        Console.WriteLine($"Yay! The Mole survived another game!");
        Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
        break;
    }

}
if (points < 25)
{
    Console.WriteLine($"Too bad! The Mole lost this battle!");
    Console.WriteLine($"The Mole lost the game with a total of {points} points.");
}
for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        Console.Write(matrix[row, col]);
    }
    Console.WriteLine();
}
/*
 
5
----S
--M9-
-S-73
--4-4
-----
right
down
left
left
right
down
down
down
End
 
 
 
 
 
 
 
 
 */
