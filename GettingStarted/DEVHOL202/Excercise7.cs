using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GettingStarted.DEVHOL202
{
    using System.Windows.Forms;

    using GettingStarted.DictionarySuggestService;

    internal class Excercise7
    {
        internal static void Run()
        {
            var svc = new DictServiceSoapClient("DictServiceSoap");

            //A
            //svc.BeginMatchInDict(
            //    "wn",
            //    "react",
            //    "prefix",
            //    iar =>
            //        { var words = svc.EndMatchInDict(iar);
            //            foreach (var dictionaryWord in words)
            //            {
            //                Console.WriteLine(dictionaryWord.Word);
            //            }
            //        },
            //    null);

            //B
            //var mathcInDict = Observable.FromAsyncPattern<string, string, string, DictionaryWord[]>(
            //    svc.BeginMatchInDict, svc.EndMatchInDict);

            //var res = mathcInDict("wn", "react", "prefix");

            //res.Subscribe(words => {
            //                           foreach (var dictionaryWord in words)
            //                           {
            //                               System.Console.WriteLine(dictionaryWord.Word);
            //                           }
            //});

            //C
            var mathcInDict = Observable.FromAsyncPattern<string, string, string, DictionaryWord[]>(
                svc.BeginMatchInDict, svc.EndMatchInDict);

            Func<string,IObservable<DictionaryWord[]>> matchInWordNetByPrefic = term => mathcInDict("wn", term, "prefix");

            var res = matchInWordNetByPrefic("res");

            res.Subscribe(words =>
            {
                foreach (var dictionaryWord in words)
                {
                    System.Console.WriteLine(dictionaryWord.Word);
                }
            },
            ex => Console.WriteLine(ex.Message)
            );

            Console.ReadLine();
        }
    }
}
