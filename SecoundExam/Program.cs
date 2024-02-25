namespace SecoundExam;
class Program
{
    static void Main(string[] args)
    {

        int n = int.Parse(Console.ReadLine());
        char[,] matrix = new char[n, n];

        int startR = -1;
        int startC = -1;
        int enemy = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string data = Console.ReadLine();
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = data[col];
                if (matrix[row, col] == 'J')
                {
                    startR = row;
                    startC = col;
                }
                if (matrix[row, col] == 'E')
                {
                    enemy++;
                }
            }
        }

        int armor = 300;
        string commands;
        while ((commands = Console.ReadLine())!="")
        {
            string command = commands;
            matrix[startR, startC] = '-';
            if (command == "left")
            {
                startC--;
            }
            if (command == "right")
            {
                startC++;
            }
            if (command == "up")
            {
                startR--;
            }
            if (command == "down")
            {
                startR++;
            }
            if (matrix[startR, startC] != '-')
            {
                if (matrix[startR, startC] == 'E')
                {
                    matrix[startR, startC] = '-';
                    armor -= 100;
                    enemy--;//the last enemy??
                    if (enemy==0)
                    { Console.WriteLine($"Mission accomplished, you neutralized the aerial threat!");
                        break;
                    }
                    if (armor==0&&enemy>0)
                    {
                        Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{startR}, {startC}]!");
                        break;
                    }
                }
                if (matrix[startR, startC] == 'R')
                {
                    armor = 300;
                    matrix[startR, startC] = '-';
                }
            }
           
        }
        matrix[startR, startC] = 'J';
        
        Output(matrix);
    }

    private static void Output(char[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int e = 0; e < matrix.GetLength(1); e++)
            {
                Console.Write(matrix[i, e]);
            }
            Console.WriteLine();
        }
    }
}

/*
5
-R---
-J--E
-E---
--E-E
-R---
up
down
down
down
right
right
right
 
4
-R--
-JEE
-E-R
--E-
right
right
down
left
left
down
right

5
-J--E
-R--E
-E--R
--R-E
-R---
right
right
right
down
down
down
left
left
left
up
 
 
 */