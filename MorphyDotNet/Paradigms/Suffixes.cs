using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MorphyDotNet.Paradigms
{
    internal sealed class Suffixes
    {
        List<string> m_suffixes;

        public Suffixes(string fileName)
        {
            using (FileStream stream = File.OpenRead(fileName))
                Load(stream);
        }
        
        public Suffixes(Stream stream)
        {
            Load(stream);
        }

        void Load(Stream stream)
        {
            m_suffixes = new List<string>();
            //using (TextReader reader = new StreamReader(stream))
            //{
            //    reader.re
            //}
            using (JsonTextReader reader = new JsonTextReader(new StreamReader(stream)))
            {
                while(reader.Read())
                {
                    if (reader.Value != null)
                        m_suffixes.Add(reader.Value.ToString());
                }
            }
        }

        public string GetSuffix(int index)
        {
            return m_suffixes[index];
        }
    }
}
