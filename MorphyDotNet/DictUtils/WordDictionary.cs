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
        IParadigmStrings m_tags;
        List<List<int>> m_paradigms;

        public WordDictionary(IWordMatchingDictionary dictionary, IParadigmStrings tags, List<List<int>> paradigms)
        {
            m_wordMatchingDictionary = dictionary;
            m_tags = tags;
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
                // A paradigm has n entries and n is a multiple of 3
                // First we have n/3 suffix indexes
                // Then we have n/3 tag indexes
                // The we have n/3 prefix indexes
                // This should probably be later wrapped in a container
                int n = m_paradigms[pair.ParadigmId].Count();
                int tagIndex = m_paradigms[pair.ParadigmId][n / 3 + pair.ParadigmIndex];
                string tag = m_tags.GetString(tagIndex);

                result.Add(new Parse(word, new Tag(tag)));
            }

            return result;
        }
    }
}
