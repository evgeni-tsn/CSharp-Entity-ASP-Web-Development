namespace OOP_Retake_Exam.Interfaces
{
    public interface ITile
    {
        IVegetable Vegetable { get; set; }

        INinja SteppedBy { get; set; }

        char CurrentSymbol { get; set; }
    }
}