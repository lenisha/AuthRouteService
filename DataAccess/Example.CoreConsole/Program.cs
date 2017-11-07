using System;

namespace Example.CoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Creating Example.Data.Standard.DB2Core Object");
                try
                {
                    var db2core = new Example.Data.Standard.DB2Core();
                    Console.WriteLine("SUCCESS!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("FAILED");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
