using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorphyDotNet.ExternalApi
{
    public class Grammeme
    {
        public string IntrenalId { get; }
        public string ExternalId { get; }
        public string FullName { get; }
        public Grammeme Parent { get; }

        public Grammeme(string intrenalId, string externalId, string fullName, Grammeme parent)
        {
            IntrenalId = intrenalId;
            ExternalId = externalId;
            FullName = fullName;
            Parent = parent;
        }

        public override string ToString()
        {
            return IntrenalId;
        }
    }
}
