using MorphyDotNet.DictUtils;
using MorphyDotNet.Paradigms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MorphyDotNet
{
    /// <summary>
    /// Main class of MorphyDotNet.
    /// It uses a dictionary to provide morphological parsing of words.
    /// </summary>
    public class MorphAnalyzer
    {
        static readonly NLog.Logger s_logger = NLog.LogManager.GetCurrentClassLogger();
        WordDictionary m_dictionary;

        /// <summary>
        /// MorphAnalyzer takes a dictionary and uses it to perform morphological parsing of words.
        /// </summary>
        /// <param name="dictionaryFolderPath">Path to a directory containing dictionary files.</param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="IOException"></exception>
        public MorphAnalyzer(string dictionaryFolderPath)
        {
            if (!Directory.Exists(dictionaryFolderPath))
            {
                s_logger.Error($"Could not create MorphAnalyzer because directory '{dictionaryFolderPath}' specified as dictionaryFolderPath does not exist.");
                throw new DirectoryNotFoundException($"Directory '{dictionaryFolderPath}' specified by dictionaryFolderPath was not found.");
            }

            // As the top-level entity of the library, we create all needed objects and distribute them here.
            var tags = new ParadigmJsonStrings(Path.Combine(dictionaryFolderPath, "gramtab-opencorpora-int.json"));

            var paradigms = new ParadigmsReader().ReadFromFile(Path.Combine(dictionaryFolderPath, "paradigms.array"));

            m_dictionary = new WordDictionary(Path.Combine(dictionaryFolderPath, "dict.dawgsharp"), tags, paradigms);
        }

        /// <summary>
        /// Morpologically parses the given word
        /// </summary>
        /// <param name="word">Word to be parsed.</param>
        /// <returns>List of morphological variants. Can be empty.</returns>
        public List<Parse> Parse(string word)
        {
            return m_dictionary.MatchParses(word);
        }
    }
}
