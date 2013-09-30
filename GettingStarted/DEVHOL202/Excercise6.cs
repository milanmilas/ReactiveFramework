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
            var lbl = new Label() { Left = txt.Width + 20 };

            var form = new Form() { Controls = { txt, lbl } };

            var input = (from evt in Observable.FromEvent<EventArgs>(txt, "TextChanged")
                        select ((TextBox)evt.Sender).Text)
                        .Timestamp()
                        .Do(x => Console.WriteLine("Before applying do operator:time {0}, value {1}", x.Timestamp.Millisecond, x.Value))
                        .Throttle(TimeSpan.FromSeconds(1))
                        .Do(x => Console.WriteLine("After throttle: time {0}, value {1}", x.Timestamp.Millisecond, x.Value))
                        .RemoveTimestamp()
                        .DistinctUntilChanged();

            input.ObserveOn(lbl).Subscribe(x => lbl.Text = x);

            Application.Run(form);
        }
    }
}
