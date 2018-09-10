using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorphyDotNet.Paradigms
{
    internal sealed class ParadigmsCollection
    {
        IParadigmStrings m_tags;
        List<List<int>> m_paradigms;

        public ParadigmsCollection(List<List<int>> paradigms, IParadigmStrings tags)
        {
            m_paradigms = paradigms;
            m_tags = tags;
        }

        public Tag GetTag(int paradigmId, int index)
        {
            // A paradigm has n entries and n is a multiple of 3
            // First we have n/3 suffix indexes
            // Then we have n/3 tag indexes
            // The we have n/3 prefix indexes
            // This should probably be later wrapped in a container
            int n = m_paradigms[paradigmId].Count();
            int tagIndex = m_paradigms[paradigmId][n / 3 + index];
            string tag = m_tags.GetString(tagIndex);

            return new Tag(tag);
        }
    }
}
