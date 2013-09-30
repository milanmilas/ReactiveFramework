using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GettingStarted.DEVHOL202
{
    using System.Windows.Forms;

    using GettingStarted.DictionarySuggestService;

    internal class Excercise8
    {
        internal static void Run()
        {
            var txt = new TextBox();
            var lst = new ListBox(){ Top = txt.Height + 20 };

            var form = new Form() { Controls = { txt, lst } };

            var svc = new DictServiceSoapClient("DictServiceSoap");

            var input =
                (from evt in Observable.FromEvent<EventArgs>(txt, "TextChanged") 
                 select ((TextBox)evt.Sender).Text)
                 .Throttle(TimeSpan.FromSeconds(1))
                 .DistinctUntilChanged()
                 .Do(x => Console.WriteLine(x));

            var mathcInDict = Observable.FromAsyncPattern<string, string, string, DictionaryWord[]>(
                svc.BeginMatchInDict, svc.EndMatchInDict);

            Func<string,IObservable<DictionaryWord[]>> matchInWordNetByPrefic = term => mathcInDict("wn", term, "prefix");

            IObservable<DictionaryWord[]> res;
            res = from term in input
                  from words in
                      matchInWordNetByPrefic(term)
                      .Finally(() => Console.WriteLine("Disposing has happened for term: {0}", term))
                      .TakeUntil(input)
                  select words;

            using (res.ObserveOn(lst).Subscribe(words =>
                {
                    lst.Items.Clear();
                    lst.Items.AddRange((from word in words select word.Word).ToArray());
                },
                ex => MessageBox.Show(ex.Message)))


            Application.Run(form);
        }
    }
}
