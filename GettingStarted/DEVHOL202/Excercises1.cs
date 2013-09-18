using System;

namespace GettingStarted.DEVHOL202
{
    public static class Excercises1
    {
        public static void Run()
        {
            IObservable<int> source = null;
            IObserver<int> handler = null;

            IDisposable subscription = source.Subscribe(
                    (int x) => { Console.WriteLine("Received {0} from source", x);},
                    (Exception ex) => { Console.WriteLine("Source signaled an error: {0}", ex.Message);},
                    () => { Console.WriteLine("Source said there is no more mesages to flow anymore");}
                );

            Console.WriteLine("Press Enter to terminate program");
            Console.ReadKey();

            subscription.Dispose();
        }
    }
}
