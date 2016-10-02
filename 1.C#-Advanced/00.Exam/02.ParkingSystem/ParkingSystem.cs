namespace Problem2
{
    using System;

    public class ParkingSystem
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine().Split();
            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);
            int[,] parkingLot = new int[rows, cols];

            var details = Console.ReadLine();

            while (details != "stop")
            {
                var splitted = details.Split();
                int entryRow = int.Parse(splitted[0]);

                int desireRow = int.Parse(splitted[1]);
                int desireCol = int.Parse(splitted[2]);


                int stepsCounter = 1 + Math.Abs(desireRow - entryRow);

                if (parkingLot[desireRow, desireCol] == 0)
                {
                    FreeSpot(parkingLot, desireRow, desireCol, stepsCounter);
                }
                else
                {
                    bool isParked = false;
                    var freeCol = FindFreeSpot(desireCol, parkingLot, desireRow, ref isParked);

                    PrintResult(isParked, stepsCounter, freeCol, desireRow);
                }

                details = Console.ReadLine();
            }
        }

        private static int FindFreeSpot(int desireCol, int[,] parkingLot, int desireRow, ref bool isParked)
        {
            int freeCol = 0;

            for (int i = Math.Max(desireCol - 1, 1); i >= 1; i--)
            {
                if (desireCol - 1 >= 1 && parkingLot[desireRow, i] == 0 && isParked == false)
                {
                    parkingLot[desireRow, i] = 1;
                    freeCol = i;
                    isParked = true;
                    break;
                }
            }

            for (int i = Math.Min(desireCol + 1, parkingLot.GetLength(1) - 1); i < parkingLot.GetLength(1); i++)
            {
                if (desireCol + 1 < parkingLot.GetLength(1) && parkingLot[desireRow, i] == 0 && isParked == false)
                {
                    parkingLot[desireRow, i] = 1;
                    freeCol = i;
                    isParked = true;
                    break;
                }
            }
            return freeCol;
        }

        private static void FreeSpot(int[,] parkingLot, int desireRow, int desireCol, int stepsCounter)
        {
            parkingLot[desireRow, desireCol] = 1;
            stepsCounter += desireCol;
            Console.WriteLine(stepsCounter);
        }

        private static void PrintResult(bool isParked, int stepsCounter, int availableColumn, int desireRow)
        {
            if (isParked)
            {
                stepsCounter += availableColumn;
                Console.WriteLine(stepsCounter);
            }
            else
            {
                Console.WriteLine("Row {0} full", desireRow);
            }
        }
    }
}
