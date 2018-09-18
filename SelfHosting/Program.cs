using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SelfHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(UberReadingService.ReadData)))
            {
                host.Open();
                Console.WriteLine("Host Start Time" + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
