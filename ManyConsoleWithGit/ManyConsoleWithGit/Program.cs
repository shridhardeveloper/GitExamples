using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyConsoleWithGit
{
    class Program
    {
        static void Main(string[] args)
        {
            var lists = new List<String> { "Shridhar", "Pasodi" };
            var collections = new { Name = "Shridhar", Address = "Mumbai", Mobile = 155 };
            var c1 = new[] { new { Name = "Shridhar", Age = 21 }, new { Name = "Rock", Age = 23 } };
            Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole()
                .WriteTo.Elasticsearch()
                .CreateLogger();
            try
            {
                var a = 0;
                var b = 1;
                var c = b / a;
            }
            catch (Exception ex)
            {
                Log.Error("Error occured: {0}", ex.Message);

                Log.Error("This is an Error on FirstDemo");

                var contextLogger = Log.Logger.ForContext<Program>();

                contextLogger.Information("This is the Context Info for FirstDemo");

                contextLogger.Information("Include a collection {data}", lists);
                contextLogger.Information("Include complex data {data1}", collections);

                Log.Information("This is the Context Info for FirstDemo");

                Log.Debug("Include a collection {data}", lists);
                Log.Fatal("Include complex data {data1}", collections);

                Log.Warning("Include complex data {data1}", c1);

                Console.ReadLine();
            }
            finally
            {
                Log.Information("Finally is called...");
                Console.ReadLine();
            }
        }
    }
}
