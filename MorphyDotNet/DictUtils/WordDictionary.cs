using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DawgSharp;
using MorphyDotNet.Paradigms;

namespace MorphyDotNet.DictUtils
{
    // This a utility class that provides dictionary loading and matching operations
    // It should never be accessed directly, so we make it internal
    internal sealed class WordDictionary
    {
        static readonly NLog.Logger s_logger = NLog.LogManager.GetCurrentClassLogger();
        IWordMatchingDictionary m_wordMatchingDictionary;
        IParadigmsCollection m_paradigms;

        public WordDictionary(IWordMatchingDictionary dictionary, IParadigmsCollection paradigms)
        {
            m_wordMatchingDictionary = dictionary;
            m_paradigms = paradigms;
        }

        // This method finds all occurences of word in the dictionary and
        // forms Parse objects with their morphological tags
        public List<Parse> MatchParses(string word)
        {
            List<Parse> result = new List<Parse>();

            List<DictionaryMatch> pairs = m_wordMatchingDictionary.MatchWord(word.ToLower());

            foreach (var pair in pairs)
            {
                Tag tag = m_paradigms.GetTag(pair.ParadigmId, pair.ParadigmIndex);
                
                result.Add(new Parse(word, tag));
            }

            return result;
        }
    }
}
