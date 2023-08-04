using Pragmatic.Client.MT4.Hourglass;
using System;
using System.Threading.Tasks;

namespace Pragmatic.Client.CLI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var result = Trader.RegisterAccount();
            Console.WriteLine($"result = {result}");
            Console.WriteLine("              At the end of tracks and trails, dead men tell no tales              ");
            Console.ReadLine();
        }
    }
}