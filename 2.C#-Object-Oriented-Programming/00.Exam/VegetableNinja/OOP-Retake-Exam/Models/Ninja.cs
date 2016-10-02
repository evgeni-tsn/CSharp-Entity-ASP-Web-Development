namespace OOP_Retake_Exam.Models
{
    using System;
    using System.Collections.Generic;

    using Interfaces;

    public class Ninja : INinja
    {
        private const int DefaultStamina = 1;
        private const int DefaultPower = 1;

        private int power;
        private int stamina;

        public Ninja(char charName, bool isFirst)
        {
            this.CharName = charName;
            this.IsFirst = isFirst;
            this.Stamina = DefaultStamina;
            this.Power = DefaultPower;
            this.IsAlive = true;
            this.AllVegetables = new List<IVegetable>();
        }

        public char CharName { get; }

        public bool IsFirst { get; set; }

        public List<IVegetable> AllVegetables { get; set; }

        public int Stamina
        {
            get
            {
                return this.stamina;
            }

            set
            {
                this.stamina = value;
            }
        }

        public int Power
        {
            get
            {
                return this.power;
            }

            set
            {
                this.power = value;
            }
        }

        public bool IsAlive { get; set; }

        public void Move(ITile[,] matrix, char direction)
        {
            int currentRow = 0;
            int currentCol = 0;
            int initRow = 0;
            int initCol = 0;
            bool shouldBreak = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == this)
                    {
                        currentRow = i;
                        currentCol = j;
                        initRow = i;
                        initCol = j;
                        shouldBreak = true;
                        break;
                    }

                    if (shouldBreak)
                    {
                        break;
                    }
                }
            }

            if (direction == 'L')
            {
                if (currentCol - 1 >= 0)
                {
                    currentCol -= 1;
                }
            }
            else if (direction == 'U')
            {
                if (currentRow - 1 >= 0)
                {
                    currentRow -= 1;
                }
            }
            else if (direction == 'D')
            {
                if (currentRow + 1 < matrix.GetLength(0))
                {
                    currentRow += 1;
                }
            }
            else if (direction == 'R')
            {
                if (currentCol + 1 < matrix.GetLength(1))
                {
                    currentCol += 1;
                }
            }

            if (currentCol != initCol || currentRow != initRow)
            {
                matrix[initRow, initCol].SteppedBy = null;
                if (matrix[currentRow, currentCol].SteppedBy != null)
                {
                    throw new InvalidOperationException();
                }

                matrix[currentRow, currentCol].SteppedBy = this;
                if (matrix[currentRow, currentCol].Vegetable.CanCollect())
                {
                    this.AllVegetables.Add(matrix[currentRow, currentCol].Vegetable);
                    matrix[currentRow, currentCol].Vegetable.Pick();
                }
            }

        }
    }
}