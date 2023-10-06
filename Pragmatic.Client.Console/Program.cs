using Pragmatic.Client.Hourglass.MT4;
using System;
using System.Threading.Tasks;

namespace Pragmatic.Client.CLI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //var result = Trader.RegisterAccountFromMT4(2, 4);
            var result = Trader.RegisterAccount();
            Console.WriteLine($"result = {result}");
            Console.WriteLine("              At the end of tracks and trails, dead men tell no tales              ");
            Console.ReadLine();
        }
    }
}