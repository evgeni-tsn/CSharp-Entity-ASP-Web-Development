namespace BoatRacingSimulator
{
    using BoatRacingSimulator.Core;
    using BoatRacingSimulator.IO;

    public class BoatRacingSimulatorApplication
    {
        public static void Main()
        {
            var commandHandler = new CommandHandler();
            var writer = new ConsoleWriter();
            var reader = new ConsoleReader();

            var engine = new Engine(commandHandler, reader, writer);
            engine.Run();
        }
    }
}