namespace OOP_Retake_Exam.Interfaces
{
    using System.Collections.Generic;

    public interface INinja : IDieable
    {
        char CharName { get; }

        int Stamina { get; set; }

        int Power { get; set; }

        bool IsFirst { get; set; }

        List<IVegetable> AllVegetables { get; set; }

        void Move(ITile[,] matrix, char direction);
    }
}