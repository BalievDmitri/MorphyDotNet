using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorphyDotNet.Paradigms
{
    /// <summary>
    /// This class provides a container for information about a word declension (склонение) varinat in a paradigm
    /// </summary>
    internal sealed class Declension
    {
        public string Prefix { get; }
        public Tag Tag { get; }
        public string Suffix { get; }

        public Declension(string prefix, Tag tag, string suffix)
        {
            Prefix = prefix;
            Tag = tag;
            Suffix = suffix;
        }
    }
}
