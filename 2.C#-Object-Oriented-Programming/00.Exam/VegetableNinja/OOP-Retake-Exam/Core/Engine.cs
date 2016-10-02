namespace OOP_Retake_Exam.Core
{
    using System;

    using Interfaces;

    public class Engine : IRunnable
    {
        private readonly INinjaFactory ninjaFactory;
        private readonly IVegetableFactory vegetableFactory;
        private readonly ITileFactory tileFactory;
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;

        private INinja ninjaOnTurn;
        private bool turnTaker;

        public Engine(INinjaFactory ninjaFactory, IVegetableFactory vegetableFactory, ITileFactory tileFactory, IInputReader reader, IOutputWriter writer)
        {
            this.ninjaFactory = ninjaFactory;
            this.vegetableFactory = vegetableFactory;
            this.tileFactory = tileFactory;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                var readFirstNinja = this.reader.ReadLine();
                INinja firstNinja = this.ninjaFactory.CreateNinja(readFirstNinja[0], true);

                var readSecondNinja = this.reader.ReadLine();
                INinja secondNinja = this.ninjaFactory.CreateNinja( readSecondNinja[0], false);

                this.ninjaOnTurn = firstNinja;

                ITile[,] matrix = this.CreatePlayGround(firstNinja, secondNinja);

                while (firstNinja.IsAlive && secondNinja.IsAlive)
                {
                    var commands = this.reader.ReadLine().ToCharArray();
                    try
                    {
                        foreach (var command in commands)
                        {

                            this.GetCurrentNinja(firstNinja, secondNinja).Move(matrix, command);
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        INinja attacker = this.ninjaOnTurn;
                        INinja target = null;
                        if (attacker == firstNinja)
                        {
                            target = secondNinja;
                        }
                        else
                        {
                            target = firstNinja;
                        }

                        INinja winner = null;
                        if (attacker.Power >= target.Power)
                        {
                            winner = attacker;
                        }
                        else
                        {
                            winner = target;
                        }
                        string winnerOutput;
                        if (winner.CharName.Equals(readFirstNinja[0]))
                        {
                            winnerOutput = readFirstNinja;
                        }
                        else
                        {
                            winnerOutput = readSecondNinja;
                        }
                        this.writer.WriteLine($"Winner: {winnerOutput}");
                        this.writer.WriteLine($"Power: {winner.Power}");
                        this.writer.WriteLine($"Stamina: {winner.Stamina}");
                        break;
                    }
                }
                break;
            }
        }

        private ITile[,] CreatePlayGround(INinja first, INinja second)
        {
            var dimensions = this.reader.ReadLine().Split();
            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            ITile[,] matrix = new ITile[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                char[] inputs = this.reader.ReadLine().ToCharArray();

                for (int j = 0; j < cols; j++)
                {
                    if (inputs[j] == first.CharName)
                    {
                        matrix[i, j] = this.tileFactory.CreateTile(
                            this.vegetableFactory.CreateVegetable('-'),
                            first,
                            first.CharName);
                        continue;
                    }
                    if (inputs[j] == second.CharName)
                    {
                        matrix[i, j] = this.tileFactory.CreateTile(
                            this.vegetableFactory.CreateVegetable('-'),
                            second,
                            second.CharName);
                        continue;
                    }
                    var currVegetable = this.vegetableFactory.CreateVegetable(inputs[j]);

                    matrix[i, j] = this.tileFactory.CreateTile(
                        currVegetable,
                        null,
                        currVegetable.CharName);
                }
            }
            return matrix;
        }

        public INinja GetCurrentNinja(INinja first, INinja second)
        {
            if (this.ninjaOnTurn.Stamina > 0 || this.turnTaker)
            {
                this.ninjaOnTurn.Stamina -= 1;
                this.turnTaker = false;
                return this.ninjaOnTurn;
            }
            if (this.ninjaOnTurn.Stamina < 1)
            {
                foreach (IVegetable vegetable in this.ninjaOnTurn.AllVegetables)
                {
                    this.ninjaOnTurn.Power += vegetable.Power;
                    this.ninjaOnTurn.Stamina += vegetable.Stamina;
                }
                this.ninjaOnTurn.AllVegetables.Clear();



                if (this.ninjaOnTurn == first)
                {
                    this.ninjaOnTurn = second;
                }
                else
                {
                    this.ninjaOnTurn = first;
                }
            }
            return this.ninjaOnTurn;
        }

        public Tuple<int, int> CoordinatesOf<T>(ITile[,] matrix, T value)
        {
            int w = matrix.GetLength(0);
            int h = matrix.GetLength(1);

            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    if (matrix[x, y].CurrentSymbol.Equals(value))
                        return Tuple.Create(x, y);
                }
            }

            return Tuple.Create(-1, -1);
        }
    }
}