using MorphyDotNet.DictUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorphyDotNet.ExternalApi
{
    public class MorphAnalyzer
    {
        WordDictionary m_dictionary;

        public MorphAnalyzer()
        {
            m_dictionary = new WordDictionary(@"E:\Workspace\pymorphy2_tests\your_file.ydawg");
        }

        public List<Parse> Parse(string word)
        {
            List<string> parses = m_dictionary.MatchPrefix(word);
            List<Parse> results = new List<Parse>();
            foreach(string parse in parses)
            {
                results.Add(new Parse(parse));
            }
            return results;
        }
    }
}
