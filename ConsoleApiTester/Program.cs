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
            Console.ReadKey();
        }
    }
}
