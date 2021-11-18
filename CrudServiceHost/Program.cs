using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace CrudServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseHttpUrl = new Uri("http://localhost:8090/MyServices");

            using (ServiceHost serviceHost = new ServiceHost(typeof(MyServices.CrudService), baseHttpUrl))
            {
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                serviceHost.Description.Behaviors.Add(smb);
                serviceHost.AddServiceEndpoint(typeof(MyServices.ICrudService), new BasicHttpBinding(), "CrudService");

                serviceHost.Open();

                Console.WriteLine("Service is ready");
                Console.WriteLine("Service name: " + serviceHost.Description.Name);
                
                Console.WriteLine("Press <Enter> to terminate service");
                Console.ReadLine();
            }
        }
    }
}
