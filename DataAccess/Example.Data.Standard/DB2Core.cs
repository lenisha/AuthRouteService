using System;

namespace Example.Data.Standard
{
    public class DB2Core
    {
        public DB2Core()
        {
            Console.WriteLine("Creating IBM.Data.Core.DB2Connection Connection Object");
            try
            {
                var db2core = new IBM.Data.DB2.Core.DB2Connection();
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
