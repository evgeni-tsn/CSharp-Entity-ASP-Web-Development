namespace OOP_Retake_Exam.Core.Factories
{
    using Interfaces;
    using Models;

    public class TileFactory : ITileFactory
    {
        public ITile CreateTile(IVegetable vegetable, INinja steppedBy, char currSymbol)
        {
            var tile = new Tile(vegetable, steppedBy, currSymbol);

            return tile;
        }
    }
}