namespace OOP_Retake_Exam.Models
{
    using Interfaces;

    public class Tile : ITile
    {
        public Tile(IVegetable vegetable, INinja steppedBy, char currentSymbol)
        {
            this.Vegetable = vegetable;
            this.SteppedBy = steppedBy;
            this.CurrentSymbol = currentSymbol;
        }

        public IVegetable Vegetable { get; set; }

        public INinja SteppedBy { get; set; }

        public char CurrentSymbol { get; set; }
    }
}