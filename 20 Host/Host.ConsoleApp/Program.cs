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
                    typeof(Web.Service.TechnobabbleService)
                 );

                serviceHost.Open();

                foreach (var channel in serviceHost.ChannelDispatchers) {
                    System.Console.WriteLine(
                        "Service is running on address: " + channel.Listener.Uri.ToString()
                    );
                }

                System.Console.ReadKey();

                serviceHost.Close();
            } catch (AddressAccessDeniedException e) {
                Console.WriteLine(@"For non-admin user permissions need to be setup:");
                Console.WriteLine(@"Example: netsh http add urlacl url=http://+:[PortNumber]/ user=[Domain]\[UserName]");
                Console.WriteLine();
                Console.WriteLine(e.ToString());
            } catch (Exception) {
                throw;
            }
        }
    }
}
