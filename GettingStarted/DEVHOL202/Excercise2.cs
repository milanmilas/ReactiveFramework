using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GettingStarted.DEVHOL202
{
    public static class Excercise2
    {
        public static void Run()
        {
            //Observable.Empty<int>();
            //Observable.Throw<int>(new Exception("Oops"));
            //Observable.Return(42);
            //Observable.Range(5, 3);
            //Observable.Never<int>();
            //Observable.Generate(0, i => i < 5, i => i + 1, i => i * i);

            IObservable<int> observable = Observable.GenerateWithTime(0, i => i < 5, i => i + 1, i => i * i, x => TimeSpan.FromSeconds(x));

            //IDisposable subscription = 
            using (
                observable.Subscribe(
                    x => Console.WriteLine("OnNext : {0}", x),
                    ex => Console.WriteLine("OnError : {0}", ex),
                    () => Console.WriteLine("OnCompleted")))
            {
                Console.WriteLine("Press Enter to unsubscribe...");
                Console.ReadKey();
            }

            //subscription.Dispose();
        }
    }
}
