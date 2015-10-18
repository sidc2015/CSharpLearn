using System;

namespace WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HelloServiceClient.HelloServiceClient("BasicHttpBinding_IHelloService");
            Console.WriteLine( client.GetMessage("Arick"));
        }
    }
}
