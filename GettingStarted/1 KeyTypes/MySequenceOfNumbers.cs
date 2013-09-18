using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GettingStarted._1_KeyTypes
{
    public class MySequenceOfNumbers : IObservable<int>
    {
        public IDisposable Subscribe(IObserver<int> observer)
        {
            observer.OnNext(1);
            observer.OnNext(2);
            observer.OnNext(3);
            observer.OnCompleted();

            return null;

        }
    }
}
