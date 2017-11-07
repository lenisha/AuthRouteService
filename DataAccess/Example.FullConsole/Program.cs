using System;

namespace Example.FullConsole
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
                Console.WriteLine("Creating Example.Data.Full.DB2wrapper Object");
                try
                {
                    var wrapper = new Example.Data.Full.DB2Wrapper();
                    Console.WriteLine("SUCCESS!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("FAILED");
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Creating Example.Data.Full.SybaseASE Object");
                try
                {
                    var db2core = new Example.Data.Full.SybaseASE();
                    Console.WriteLine("SUCCESS!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("FAILED");
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Creating Example.Data.Full.OracleManaged Object");
                try
                {
                    var db2core = new Example.Data.Full.OracleManaged();
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
