namespace OOP_Retake_Exam
{
    using Core;
    using Core.Factories;
    using IO;

    public class VegetableNinjaApplication
    {
        public static void Main()
        {
            var ninjaFactory = new NinjaFactory();
            var vegetableFactory = new VegetableFactory();
            var tileFactory = new TileFactory();
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            var engine = new Engine(ninjaFactory, vegetableFactory, tileFactory, reader, writer);
            engine.Run();
        }
    }
}
