using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MorphyDotNet.ExternalApi;

namespace ConsoleApiTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var morph = new MorphAnalyzer();
            var parsed = morph.Parse("стали");
            Console.WriteLine(parsed[0]);

            var paradigms = new MorphyDotNet.DictUtils.ParadigmsReader().ReadFromFile(@"C:\Anaconda3\envs\pymorphy2_tests\Lib\site-packages\pymorphy2_dicts_ru\data\paradigms.array");

            Console.ReadKey();
        }
    }
}
