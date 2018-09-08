using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MorphyDotNet.ExternalApi;
using MorphyDotNet.Paradigms;

namespace ConsoleApiTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var morph = new MorphAnalyzer(@"E:\Workspace\VisualStudio\MorphyDotNetSampleDictionary");
            var parsed = morph.Parse("стали");
            foreach(var parse in parsed)
                Console.WriteLine(parse);

            //Suffixes suffixes = new Suffixes(@"E:\Workspace\pymorphy2_tests\gramtab-opencorpora-ext.json");


            //var paradigms = new MorphyDotNet.DictUtils.ParadigmsReader().ReadFromFile(@"C:\Anaconda3\envs\pymorphy2_tests\Lib\site-packages\pymorphy2_dicts_ru\data\paradigms.array");

            Console.ReadKey();
        }
    }
}
