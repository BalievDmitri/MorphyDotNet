using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DawgSharp;

namespace MorphyDotNet.DictUtils
{
    internal class WordDictionary
    {
        Dawg<bool> m_dictionary;

        public WordDictionary(string fileName)
        {
            using (FileStream stream = File.OpenRead(fileName))
            {
                m_dictionary = Dawg<bool>.Load(stream);
            }
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
    }
}
