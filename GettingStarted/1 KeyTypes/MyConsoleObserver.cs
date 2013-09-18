using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GettingStarted._1_KeyTypes
{
    public class MyConsoleObserver<T> : IObserver<T>
    {

        public void OnCompleted()
        {
            Console.WriteLine("Sequence terminated");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("Excpetion received:{0}", error.Message);
        }

        public void OnNext(T value)
        {
            Console.WriteLine("Received value:{0}", value);
        }
    }
}
