using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MorphyDotNet;

namespace Examples
{
    class SimpleUsageExample
    {
        public SimpleUsageExample()
        {
            MorphAnalyzer morphAnalizer = new MorphAnalyzer("MyDictionaryFolderPath");
            List<Parse> myWordParses = morphAnalizer.Parse("myWord");

            foreach(var wordParse in myWordParses)
            {
                string wordParseStringRepresentation = wordParse.ToString();
                Tag wordTagWithGrammemes = wordParse.Tag;
                string wordGrammemesList = wordTagWithGrammemes.ToString();
            }

        }
    }
}
