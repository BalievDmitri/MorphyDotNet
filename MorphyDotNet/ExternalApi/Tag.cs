using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorphyDotNet.ExternalApi
{
    public class Tag
    {
        List<Grammeme> m_grammemes = new List<Grammeme>() { new Grammeme("NOUN", "СУЩ", "имя существительное", null) };

        public bool HasGrammeme(string grammeme) => m_grammemes.Any(g => g.ExternalId == grammeme);

        string m_tag;

        public Tag(string tag)
        {
            m_tag = tag;
        }

        public string GetGrammemesAsString()
        {
            return m_tag;
        }

        public override string ToString()
        {
            return m_tag;
            return String.Join(",", m_grammemes);
        }
    }
}
