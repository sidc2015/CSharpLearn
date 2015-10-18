
namespace WCFLib
{
    public class HelloService : IHelloService
    {
        public string GetMessage(string name)
        {
            return name + " Hello";
        }
    }
}
