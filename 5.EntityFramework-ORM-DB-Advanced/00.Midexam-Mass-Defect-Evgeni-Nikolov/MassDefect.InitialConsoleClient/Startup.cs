namespace MassDefect.InitialConsoleClient
{
    using Data;

    class Startup
    {
        static void Main()
        {
            var db = new MassDefectContext();
            db.Database.Initialize(true);
        }
    }
}
