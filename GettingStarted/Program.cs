using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GettingStarted
{
    using System.Threading;
    using System.Threading.Tasks;

    using GettingStarted.DEVHOL202;
    using GettingStarted._1_KeyTypes;

    class Program
    {
        static void Main(string[] args)
        {
            Excercise8.Run();
        }

        static async void AsyncCall()
        {
            int result = await Calculate();
            Console.WriteLine(result);
        }

        static async Task<int> Calculate()
        {
            return await Task.Factory.StartNew(() => 1);
        }
    }
}
