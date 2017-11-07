using System;

namespace Example.Data.Full
{
    public class SybaseASE
    {
        public SybaseASE()
        {
            Console.WriteLine("Creating Sybase.Data.AseClient.AseConnectionObject");
            try
            {
                var obj = new Sybase.Data.AseClient.AseConnection();
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
