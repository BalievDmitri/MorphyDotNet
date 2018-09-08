using MorphyDotNet.DictUtils;
using MorphyDotNet.Paradigms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MorphyDotNet.ExternalApi
{
    public class MorphAnalyzer
    {
        static readonly NLog.Logger s_logger = NLog.LogManager.GetCurrentClassLogger();
        WordDictionary m_dictionary;

        public MorphAnalyzer(string dictionaryFolderPath)
        {
            if (!Directory.Exists(dictionaryFolderPath))
            {
                s_logger.Error($"Could not create MorphAnalyzer because directory '{dictionaryFolderPath}' specified as dictionaryFolderPath does not exist.");
                throw new DirectoryNotFoundException($"Directory '{dictionaryFolderPath}' specified by dictionaryFolderPath was not found.");
            }

            var tags = new Suffixes(Path.Combine(dictionaryFolderPath, "gramtab-opencorpora-int.json"));

            var paradigms = new ParadigmsReader().ReadFromFile(Path.Combine(dictionaryFolderPath, "paradigms.array"));
            m_dictionary = new WordDictionary(Path.Combine(dictionaryFolderPath, "dict.dawgsharp"), tags, paradigms);
        }

        public List<Parse> Parse(string word)
        {
            return m_dictionary.MatchParses(word);
        }
    }
}
