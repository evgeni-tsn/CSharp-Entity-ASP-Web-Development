namespace OOP_Retake_Exam.Interfaces
{
    public interface IVegetable : ICollectable
    {
        char CharName { get; }

        int Power { get; }

        int Stamina { get; }

        int RegrowTurns { get; }

        void Pick();
    }
}