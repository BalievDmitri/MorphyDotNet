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
                    m_dictionary = Dawg<bool>.Load(stream);
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

        public WordDictionary(Stream stream)
        {
            m_dictionary = Dawg<bool>.Load(stream);
        }

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

        public List<Parse> MatchParses(string word)
        {
            List<Parse> result = new List<Parse>();
            var pairs = m_dictionary.MatchPrefix(word.ToLower() + "\x01");

            foreach (var pair in pairs)
            {
                int paradigm = Int32.Parse(pair.Key.Split('\x01')[1]);
                int paradigmIndex = Int32.Parse(pair.Key.Split('\x01')[2]);

                int n = m_paradigms[paradigm].Count();
                int tagIndex = m_paradigms[paradigm][n / 3 + paradigmIndex];
                string tag = m_tags.GetSuffix(tagIndex);

                result.Add(new Parse(word, new Tag(tag)));
            }

            return result;
        }
    }
}
