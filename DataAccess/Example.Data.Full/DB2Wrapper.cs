using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Data.Full
{
    public class DB2Wrapper
    {
        public DB2Wrapper()
        {
            Console.WriteLine("Creating Example.Data.Standard.DB2Core Connection Object");
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
