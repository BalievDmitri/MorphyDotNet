using DawgSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MorphyDotNet.DictUtils
{
    /// <summary>
    /// This class wrpas DawgSharp to provide word matching functionality
    /// </summary>
    internal sealed class DawgSharpDictionary : IWordMatchingDictionary
    {
        static readonly NLog.Logger s_logger = NLog.LogManager.GetCurrentClassLogger();
        Dawg<bool> m_dictionary;

        public DawgSharpDictionary(string fileName)
        {
            if (!File.Exists(fileName))
            {
                s_logger.Error($"Could not create DawgSharpDictionary because the file '{fileName}' specified as fileName does not exist.");
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
                s_logger.Error(ex, $"UnauthorizedAccessException in DawgSharpDictionary constructor.");
                throw;
            }
            catch (IOException ex)
            {
                s_logger.Error(ex, $"IOException in DawgSharpDictionary constructor.");
                throw;
            }
        }

        public DawgSharpDictionary(Stream stream)
        {
            LoadDictionary(stream);
        }

        void LoadDictionary(Stream stream)
        {
            m_dictionary = Dawg<bool>.Load(stream);
        }

        /// <summary>
        /// Finds all occurances of a given word in the dictionary
        /// </summary>
        /// <param name="word">Word to search</param>
        /// <returns>A list of matches found in the dictionary. Can be empty if nothing was found.</returns>
        public List<DictionaryMatch> MatchWord(string word)
        {
            // We store our words in format
            // 'Word' + '\x01' + paradigm_id + '\x01' + paradigm_index

            List<DictionaryMatch> result = new List<DictionaryMatch>();
            // Our dictionary contains only lower case versions of words
            // We add '\x01' so that we get only the needed word variants
            // and not all words starting with it
            var pairs = m_dictionary.MatchPrefix(word.ToLower() + "\x01");

            // Dawg stores pairs of a string key and a payload.
            // We don't have payload and our data is entierly in keys
            foreach (var pair in pairs)
            {
                int paradigm = Int32.Parse(pair.Key.Split('\x01')[1]);
                int paradigmIndex = Int32.Parse(pair.Key.Split('\x01')[2]);

                result.Add(new DictionaryMatch(word, paradigm, paradigmIndex));
            }

            return result;
        }
    }
}
