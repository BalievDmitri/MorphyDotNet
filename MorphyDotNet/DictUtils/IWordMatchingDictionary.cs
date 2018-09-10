using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorphyDotNet.DictUtils
{
    internal interface IWordMatchingDictionary
    {
        List<DictionaryMatch> MatchWord(string word);
    }
}
