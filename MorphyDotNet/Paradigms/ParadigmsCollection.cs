using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorphyDotNet.Paradigms
{
    /// <summary>
    /// This is a container for a collection of paradigms.
    /// You can create one via ParadigmsReader.
    /// </summary>
    internal sealed class ParadigmsCollection : IParadigmsCollection
    {
        List<Paradigm> m_paradigms;

        public ParadigmsCollection(List<Paradigm> paradigms)
        {
            m_paradigms = paradigms;
        }

        public Tag GetTag(int paradigmId, int index)
        {
            return m_paradigms[paradigmId].GetDeclension(index).Tag;
        }
    }
}
