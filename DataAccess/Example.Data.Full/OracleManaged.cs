using System;

namespace Example.Data.Full
{
    public class OracleManaged
    {
        public OracleManaged()
        {
            Console.WriteLine("Creating Oracle.ManagedDataAccess.Client.OracleConnection Object");
            try
            {
                var obj = new Oracle.ManagedDataAccess.Client.OracleConnection();
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
