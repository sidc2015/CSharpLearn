using System;
using System.ServiceModel;

namespace WCFConsole
{
    class Program
    {
        // 可能需要 Administrator 權限啟動
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(WCFLib.HelloService)))
            {
                host.Open();
                Console.WriteLine("Host 在" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "啟動");
                Console.ReadLine();//防止控制台程序自動關閉
            }
        }
    }
}
