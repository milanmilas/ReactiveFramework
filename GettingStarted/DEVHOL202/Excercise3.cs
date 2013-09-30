namespace GettingStarted.DEVHOL202
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public class Excercise3
    {
        public static void Run()
        {
            var lbl = new Label();
            var txt = new TextBox();

            var form = new Form() { Controls = { txt} };

            //form.MouseMove += (sender, args) => { lbl.Text = args.Location.ToString(); };
            //Application.Run(form);

            IObservable<IEvent<MouseEventArgs>> moves = Observable.FromEvent<MouseEventArgs>(form, "MouseMove");
            IObservable<IEvent<EventArgs>> input = Observable.FromEvent<EventArgs>(txt, "TextChanged");

            moves.Subscribe(
                x => Console.WriteLine("User moved to location: {0}", x.EventArgs.Location.ToString()));

            input.Subscribe(
                x => Console.WriteLine("User entered input: {0}", ((TextBox)x.Sender).Text));

            //using (moves.Subscribe(evt => {
            //        lbl.Text = evt.EventArgs.Location.ToString();
            //    }))
            {
                Application.Run(form);
            }
        } 
    }
}