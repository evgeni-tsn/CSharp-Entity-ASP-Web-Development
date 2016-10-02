using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Minesweeper
{
    class Minesweeper
    {
        public const int Max = 35;

        private static void Main()
        {
            string command;
            char[,] playGround = CreatePlayGround();
            char[,] bombs = SetBombs();
            int counter = 0;
            bool exploded = false;
            List<Ranking> champions = new List<Ranking>(6);
            int row = 0;
            int column = 0;
            bool flag = true;
            bool flag2 = false;

            do
            {
                if (flag)
                {
                    Console.WriteLine("Let's play Minesweeper. Try to find all empty fields.");
                    Console.WriteLine("Commands:{0}'top' shows the ranking{0}'restart' starts new game{0}'exit' close the game!", Environment.NewLine);
                    PrintPlayGround(playGround);
                    flag = false;
                }

                Console.Write("Enter row and column: ");
                command = Console.ReadLine()?.Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out column)
                        && (row <= playGround.GetLength(0)) && (column <= playGround.GetLength(1)))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Ranking(champions);
                        break;
                    case "restart":
                        playGround = CreatePlayGround();
                        bombs = SetBombs();
                        PrintPlayGround(playGround);
                        break;
                    case "exit":
                        Console.WriteLine("Bye!");
                        break;
                    case "turn":
                        if (bombs[row, column] != '*')
                        {
                            if (bombs[row, column] == '-')
                            {
                                YourTurn(playGround, bombs, row, column);
                                counter++;
                            }

                            if (Max == counter)
                            {
                                flag2 = true;
                            }
                            else
                            {
                                PrintPlayGround(playGround);
                            }
                        }
                        else
                        {
                            exploded = true;
                        }

                        break;
                    default:
                        Console.WriteLine("Error! Unsupported command.");
                        break;
                }

                if (exploded)
                {
                    PrintPlayGround(bombs);
                    Console.WriteLine("Boom! You died with {0} points. Enter your username: ", counter);
                    string nickname = Console.ReadLine();
                    Ranking t = new Ranking(nickname, counter);
                    if (champions.Count < 5)
                    {
                        champions.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < t.Points)
                            {
                                champions.Insert(i, t);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((r1, r2) => String.Compare(r2.Player, r1.Player, StringComparison.Ordinal));
                    champions.Sort((r1, r2) => r2.Points.CompareTo(r1.Points));
                    Ranking(champions);

                    playGround = CreatePlayGround();
                    bombs = SetBombs();
                    counter = 0;
                    exploded = false;
                    flag = true;
                }

                if (flag2)
                {
                    Console.WriteLine("Congrats! You successfully open all empty spaces.");
                    PrintPlayGround(bombs);
                    Console.WriteLine("Enter nickname: ");
                    string nickname = Console.ReadLine();
                    Ranking points = new Ranking(nickname, counter);
                    champions.Add(points);
                    Ranking(champions);
                    playGround = CreatePlayGround();
                    bombs = SetBombs();
                    counter = 0;
                    flag2 = false;
                    flag = true;
                }
            }
            while (command != "exit");
        }

        private static void Ranking(IReadOnlyList<Ranking> points)
        {
            Console.WriteLine("\nPoints:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes", i + 1, points[i].Player, points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Ranking is empty!\n");
            }
        }

        private static void YourTurn(char[,] playGround, char[,] bombs, int row, int col)
        {
            var bombsQuantity = CountMines(bombs, row, col);
            bombs[row, col] = bombsQuantity;
            playGround[row, col] = bombsQuantity;
        }

        private static void PrintPlayGround(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine();
            Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("{0} ", board[i, j]);
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayGround()
        {
            const int BoardRows = 5;
            const int BoardColumns = 10;
            var board = new char[BoardRows, BoardColumns];
            for (int i = 0; i < BoardRows; i++)
            {
                for (int j = 0; j < BoardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] SetBombs()
        {
            int rows = 5;
            int columns = 10;
            char[,] playGround = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    playGround[i, j] = '-';
                }
            }

            List<int> randomGenerator = new List<int>();
            while (randomGenerator.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!randomGenerator.Contains(randomNumber))
                {
                    randomGenerator.Add(randomNumber);
                }
            }

            foreach (int i2 in randomGenerator)
            {
                int kol = i2 / columns;
                int red = i2 % columns;
                if ((red == 0) && (i2 != 0))
                {
                    kol--;
                    red = columns;
                }
                else
                {
                    red++;
                }

                playGround[kol, red - 1] = '*';
            }

            return playGround;
        }

        private static char CountMines(char[,] playGround, int currentRow, int currentCol)
        {
            int counter = 0;
            int rows = playGround.GetLength(0);
            int cols = playGround.GetLength(1);

            if (currentRow - 1 >= 0)
            {
                if (playGround[currentRow - 1, currentCol] == '*')
                {
                    counter++;
                }
            }

            if (currentRow + 1 < rows)
            {
                if (playGround[currentRow + 1, currentCol] == '*')
                {
                    counter++;
                }
            }

            if (currentCol - 1 >= 0)
            {
                if (playGround[currentRow, currentCol - 1] == '*')
                {
                    counter++;
                }
            }

            if (currentCol + 1 < cols)
            {
                if (playGround[currentRow, currentCol + 1] == '*')
                {
                    counter++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol - 1 >= 0))
            {
                if (playGround[currentRow - 1, currentCol - 1] == '*')
                {
                    counter++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol + 1 < cols))
            {
                if (playGround[currentRow - 1, currentCol + 1] == '*')
                {
                    counter++;
                }
            }

            if ((currentRow + 1 < rows) && (currentCol - 1 >= 0))
            {
                if (playGround[currentRow + 1, currentCol - 1] == '*')
                {
                    counter++;
                }
            }

            if ((currentRow + 1 < rows) && (currentCol + 1 < cols))
            {
                if (playGround[currentRow + 1, currentCol + 1] == '*')
                {
                    counter++;
                }
            }

            return char.Parse(counter.ToString());
        }
    }
}
