using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorphyDotNet
{
    public sealed class Parse
    {
        public string Word { get; }
        public Tag Tag { get; }

        // To be done
        public string NormalForm { get; }
        public Parse Normalized { get; }
        public double Score { get; }
        public bool IsKnown { get; }
        public List<Parse> Lexeme { get; }
        public int Count { get; }

        // Parse is just a container object for word information and should be created via MorphAnalyzer
        // So we make it's constructor internal
        internal Parse(string word, Tag tag)
        {
            Word = word;
            Tag = tag;
        }

        // To be done
        public Parse MakeAgreeWithNumber(int number) => this;
        public Parse Inflect() => this;

        public override string ToString()
        {
            return $"Word:'{Word}', Tag:'{Tag.ToString()}', NormalForm: '{NormalForm}', Score: '{Score}'";
        }
    }
}
