using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GettingStarted.DEVHOL202
{
    using System.Windows.Forms;

    internal class Excercise6
    {
        internal static void Run()
        {
            var txt = new TextBox();

            var form = new Form() { Controls = { txt } };

            var moves = from evt in Observable.FromEvent<MouseEventArgs>(form, "MouseMove")
                        select evt.EventArgs.Location;

            var input = (from evt in Observable.FromEvent<EventArgs>(txt, "TextChanged")
                        select ((TextBox)evt.Sender).Text)
                        .Timestamp()
                        .Do(x => Console.WriteLine("Before applying do operator:time {0}, value {1}", x.Timestamp.Millisecond, x.Value))
                        .Throttle(TimeSpan.FromSeconds(1))
                        .Do(x => Console.WriteLine("After throttle: time {0}, value {1}", x.Timestamp.Millisecond, x.Value))
                        .RemoveTimestamp()
                        .DistinctUntilChanged();

            var overFirstBisector = from mov in moves
                                    where mov.X == mov.Y
                                    select mov;


            overFirstBisector.Subscribe(
                x => Console.WriteLine("Mouse at : {0}", x));

            input.Subscribe(
                x => Console.WriteLine("User wrote : {0}", x));

            {
                Application.Run(form);
            }
        }
    }
}
