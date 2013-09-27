using System;
using System.Linq;

namespace GettingStarted.DEVHOL202
{
    using System.Windows.Forms;

    internal class Excercise4
    {
        internal static void Run()
        {
            var txt = new TextBox();

            var form = new Form() { Controls = { txt } };

            var moves = from evt in Observable.FromEvent<MouseEventArgs>(form, "MouseMove")
                        select evt.EventArgs.Location;

            var input = from evt in Observable.FromEvent<EventArgs>(txt, "TextChanged")
                        select ((TextBox)evt.Sender).Text;

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
