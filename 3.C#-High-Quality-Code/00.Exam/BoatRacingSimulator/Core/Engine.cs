namespace BoatRacingSimulator.Core
{
    using System;
    using System.Linq;
    using BoatRacingSimulator.Interfaces;

    public class Engine : IRunnable
    {
        public Engine(ICommandHandler commandHandler, IInputReader reader, IOutputWriter writer)
        {
            this.CommandHandler = commandHandler;
            this.Reader = reader;
            this.Writer = writer;
        }

        public ICommandHandler CommandHandler { get; }

        public IOutputWriter Writer { get; }

        public IInputReader Reader { get; }

        public void Run()
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }

                var tokens = line.Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0];
                var parameters = tokens.Skip(1).ToArray();

                try
                {
                    string commandResult = this.CommandHandler.ExecuteCommand(name, parameters);
                    Console.WriteLine(commandResult);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}