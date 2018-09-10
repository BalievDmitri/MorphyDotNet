using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorphyDotNet.Paradigms
{
    internal sealed class ParadigmsCollection
    {
        IParadigmStrings m_tags;
        List<Paradigm> m_paradigms;

        public ParadigmsCollection(List<List<int>> paradigms, IParadigmStrings tags)
        {
            m_paradigms = new List<Paradigm>();
            foreach(var paradigm in paradigms)
            {
                var declensions = new List<Declension>();
                // A paradigm file has n entries and n is a multiple of 3
                // First we have n/3 suffix indexes
                // Then we have n/3 tag indexes
                // The we have n/3 prefix indexes
                var tagIndexes = paradigm.Skip(paradigm.Count / 3).Take(paradigm.Count / 3);

                foreach (var tagIndex in tagIndexes)
                {
                    declensions.Add(new Declension("prefix", new Tag(tags.GetString(tagIndex)), "suffix"));
                }
                m_paradigms.Add(new Paradigm(declensions));
            }

            m_tags = tags;
        }

        public Tag GetTag(int paradigmId, int index)
        {
            return m_paradigms[paradigmId].GetDeclension(index).Tag;
        }
    }
}
