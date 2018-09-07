using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorphyDotNet.ExternalApi
{
    public class Parse
    {
        public string Word { get; }
        public Tag Tag { get; }
        public string NormalForm { get; }
        public Parse Normalized { get; }
        public double Score { get; }
        public bool IsKnown { get; }
        public List<Parse> Lexeme { get; }
        public int Count { get; }

        public Parse MakeAgreeWithNumber(int number) => this;
        public Parse Inflect() => this;

        public override string ToString()
        {
            return $"Word:'{Word}', Tag:'{Tag.ToString()}', NormalForm: '{NormalForm}', Score: '{Score}'";
        }
    }
}
