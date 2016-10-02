namespace OOP_Retake_Exam.Interfaces
{
    public interface ITileFactory
    {
        ITile CreateTile(IVegetable vegetable, INinja steppedBy, char currSymbol);
    }
}