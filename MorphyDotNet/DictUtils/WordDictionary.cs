using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DawgSharp;
using MorphyDotNet.ExternalApi;
using MorphyDotNet.Paradigms;

namespace MorphyDotNet.DictUtils
{
    // This a utility class that provides dictionary loading and matching operations
    // It should never be accessed directly, so we make it internal
    internal class WordDictionary
    {
        static readonly NLog.Logger s_logger = NLog.LogManager.GetCurrentClassLogger();
        Dawg<bool> m_dictionary;
        Suffixes m_tags;
        List<List<int>> m_paradigms;

        public WordDictionary(string fileName, Suffixes tags, List<List<int>> paradigms)
        {
            if (!File.Exists(fileName))
            {
                s_logger.Error($"Could not create WordDictionary because the file '{fileName}' specified as fileName does not exist.");
                throw new DirectoryNotFoundException($"File '{fileName}' specified by fileName was not found.");
            }

            try
            {
                using (FileStream stream = File.OpenRead(fileName))
                {
                    LoadDictionary(stream);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                s_logger.Error(ex, $"UnauthorizedAccessException in WordDictionary constructor.");
                throw;
            }
            catch (IOException ex)
            {
                s_logger.Error(ex, $"IOException in WordDictionary constructor.");
                throw;
            }

            m_tags = tags;
            m_paradigms = paradigms;
        }

        public WordDictionary(Stream stream, Suffixes tags, List<List<int>> paradigms)
        {
            LoadDictionary(stream);
            m_tags = tags;
            m_paradigms = paradigms;
        }

        void LoadDictionary(Stream stream)
        {
            m_dictionary = Dawg<bool>.Load(stream);
        }

        // This function returns all dictionary entries that
        // start with a given prefix.
        // It was used during initial debugging
        // and I will leave it for now, as it can be usefull in some future stuff
        public List<string> MatchPrefix(string prefix)
        {
            List<string> result = new List<string>();
            var pairs = m_dictionary.MatchPrefix(prefix);

            foreach(var pair in pairs)
            {
                result.Add(pair.Key.Split('\x01').First());
            }

            return result;
        }

        // This function returns parses for all dictionary entries that
        // start with a given prefix.
        // It is not used and is likely to be removed soon.
        public List<Parse> MatchParsesForPrefix(string prefix)
        {
            List<Parse> result = new List<Parse>();
            var pairs = m_dictionary.MatchPrefix(prefix);

            foreach (var pair in pairs)
            {
                string word = pair.Key.Split('\x01').First();
                int paradigm = Int32.Parse(pair.Key.Split('\x01')[1]);
                int paradigmIndex = Int32.Parse(pair.Key.Split('\x01')[2]);

                int n = m_paradigms[paradigm].Count();
                int tagIndex = m_paradigms[paradigm][n / 3 + paradigmIndex];
                string tag = m_tags.GetSuffix(tagIndex);

                result.Add(new Parse(word, new Tag(tag)));
            }

            return result;
        }

        // This method finds all occurences of word in the dictionary and
        // forms Parse objects with their morphological tags
        public List<Parse> MatchParses(string word)
        {
            // We store our words in format
            // 'Word' + '\x01\ + paradigm_id + '\x01' + paradigm_index

            List<Parse> result = new List<Parse>();
            // Our dictionary contains only lower case versions of words
            var pairs = m_dictionary.MatchPrefix(word.ToLower() + "\x01");

            // Dawg stores pairs of a string key and a payload.
            // We don't have payload and our data is entierly in keys
            foreach (var pair in pairs)
            {
                int paradigm = Int32.Parse(pair.Key.Split('\x01')[1]);
                int paradigmIndex = Int32.Parse(pair.Key.Split('\x01')[2]);

                // A paradigm has n entries and n is a multiple of 3
                // First we have n/3 suffix indexes
                // Then we have n/3 tag indexes
                // The we have n/3 prefix indexes
                // This should probably be later wrapped in a container
                int n = m_paradigms[paradigm].Count();
                int tagIndex = m_paradigms[paradigm][n / 3 + paradigmIndex];
                string tag = m_tags.GetSuffix(tagIndex);

                result.Add(new Parse(word, new Tag(tag)));
            }

            return result;
        }
    }
}
