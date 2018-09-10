using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorphyDotNet.DictUtils
{
    /// <summary>
    /// Container for information pulled out of a Dawg dictionary
    /// </summary>
    internal sealed class DictionaryMatch
    {
        public string Word { get; }
        public int ParadigmId { get; }
        public int ParadigmIndex { get; }

        public DictionaryMatch(string word, int paradigmId, int paradigmIndex)
        {
            Word = word;
            ParadigmId = paradigmId;
            ParadigmIndex = paradigmIndex;
        }
    }
}
