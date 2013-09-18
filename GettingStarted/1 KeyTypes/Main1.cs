using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GettingStarted._1_KeyTypes
{
    public static class Main1
    {
        public static void Run()
        {
            var numbers = new MySequenceOfNumbers();
            var observer = new MyConsoleObserver<int>();

            numbers.Subscribe(observer);
        }
    }
}
