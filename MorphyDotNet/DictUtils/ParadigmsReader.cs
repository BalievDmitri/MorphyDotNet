using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MorphyDotNet.DictUtils
{
    internal class ParadigmsReader
    {
        public List<List<int>> ReadFromFile(string fileName)
        {
            List<List<int>> result;
            using (FileStream stream = File.OpenRead(fileName))
                result = ReadFromStream(stream);
            return result;
        }

        public List<List<int>> ReadFromStream(Stream stream)
        {
            List<List<int>> paradigms;

            using (BinaryReader reader = new BinaryReader(stream))
            {
                int paradigmsCount = reader.ReadUInt16();

                paradigms = new List<List<int>>(paradigmsCount);
                for (int i = 0; i < paradigmsCount; i++)
                {
                    int paradigmLength = reader.ReadUInt16();
                    List<int> paradigm = new List<int>(paradigmLength);

                    for (int j = 0; j < paradigmLength; j++)
                    {
                        paradigm.Add(reader.ReadUInt16());
                    }

                    paradigms.Add(paradigm);
                }
            }

            return paradigms;
        }
    }
}
