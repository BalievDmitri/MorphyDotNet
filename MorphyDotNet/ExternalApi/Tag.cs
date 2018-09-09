using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorphyDotNet
{
    /// <summary>
    /// Container for a list of grammemes. Used to caracterize a word during parsing, or in some transormation operations.
    /// </summary>
    public class Tag
    {
        // This will be used later
        List<Grammeme> m_grammemes = new List<Grammeme>() { new Grammeme("NOUN", "СУЩ", "имя существительное", null) };

        /// <summary>
        /// Use this method to find out if this tag contains a given grammeme.
        /// </summary>
        /// <param name="grammeme">Grammeme to find. You can use any viable representation.</param>
        /// <returns>True if the tag contains this grammeme, false otherwise.</returns>
        //This method doesn't really work right now.
        public bool HasGrammeme(string grammeme) => m_grammemes.Any(g => g.ExternalId == grammeme);

        string m_tag;

        // For now we make the constructor internal
        // but we will provide a public constructor when 
        // we will be dealing with Inflect operation on Parse
        internal Tag(string tag)
        {
            m_tag = tag;
        }

        public override string ToString()
        {
            return m_tag;
            return String.Join(",", m_grammemes);
        }
    }
}
