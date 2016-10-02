namespace FlyweightGame.Contracts
{
    using FlyweightGame.UI;

    public interface IRenderable
    {
        int X { get; }

        int Y { get; }

        AssetType Type { get; }
    }
}
