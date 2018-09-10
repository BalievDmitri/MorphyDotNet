using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorphyDotNet.Paradigms
{
    /// <summary>
    /// This class is a container for paradigm information
    /// </summary>
    internal sealed class Paradigm
    {
        List<Declension> m_declensions;

        public Paradigm(List<Declension> declensions)
        {
            m_declensions = declensions;
        }

        public Declension GetDeclension(int index)
        {
            return m_declensions[index];
        }
    }
}
