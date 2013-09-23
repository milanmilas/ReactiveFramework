namespace GettingStarted.DEVHOL202
{
    using System.Linq;
    using System.Windows.Forms;

    public class Excercise3
    {
        public static void Run()
        {
            var lbl = new Label();
            var form = new Form() { Controls = {lbl} };

            //form.MouseMove += (sender, args) => { lbl.Text = args.Location.ToString(); };
            //Application.Run(form);

            var moves = Observable.FromEvent<MouseEventArgs>(form, "MouseMove");

            using (moves.Subscribe(evt => {
                    lbl.Text = evt.EventArgs.Location.ToString();
                }))
            {
                Application.Run(form);
            }
        } 
    }
}