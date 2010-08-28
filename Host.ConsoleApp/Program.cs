using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Host.ConsoleApp {
    class Program {
        static void Main(string[] args) {
            ServiceHost serviceHost = null;

            try {
                serviceHost = new ServiceHost(
                    typeof(Service.Service1Web)
                 );

                serviceHost.Open();

                System.Console.WriteLine("Service is running on adress: " + serviceHost.BaseAddresses.ToString());

            } catch(AddressAccessDeniedException e) {
                //for non-admin user permissions need to be setup:
                //Example: netsh http add urlacl url=http://+:[PortNumber]/ user=[Domain]\[UserName]
                Console.Write(e.ToString());
            } catch(Exception) {
                throw;
            }

            System.Console.ReadKey();

            serviceHost.Close();
        }
    }
}
