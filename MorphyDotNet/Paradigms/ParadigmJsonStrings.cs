using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MorphyDotNet.Paradigms
{
    // This class allows to load a Json file with string definitions for suffixes, tags and prefixes of a paradigm
    internal sealed class ParadigmJsonStrings : IParadigmStrings
    {
        List<string> m_strings;

        public ParadigmJsonStrings(string fileName)
        {
            using (FileStream stream = File.OpenRead(fileName))
            {
                Load(stream);
            }
        }
        
        public ParadigmJsonStrings(Stream stream)
        {
            Load(stream);
        }

        // We just load all strings in Json array into m_strings
        void Load(Stream stream)
        {
            m_strings = new List<string>();
            
            using (JsonTextReader reader = new JsonTextReader(new StreamReader(stream)))
            {
                while(reader.Read())
                {
                    if (reader.Value != null)
                        m_strings.Add(reader.Value.ToString());
                }
            }
        }

        public string GetString(int index)
        {
            return m_strings[index];
        }
    }
}
