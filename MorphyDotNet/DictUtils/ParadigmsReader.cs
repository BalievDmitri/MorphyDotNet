using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MorphyDotNet.DictUtils
{
    // This is a reader that parses the binary file containing paradigm data
    // It returns lists of int wich is stupid. 
    // A wrapper will be made later to provide a more coherent structure
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
                // In the binary file, we first read the number of paradigms present
                int paradigmsCount = reader.ReadUInt16();

                paradigms = new List<List<int>>(paradigmsCount);
                for (int i = 0; i < paradigmsCount; i++)
                {
                    // We read the length of the current paradigm
                    int paradigmLength = reader.ReadUInt16();
                    List<int> paradigm = new List<int>(paradigmLength);

                    // This loop is not efficient, but since we do it only once
                    // and the filesize is relatively small,
                    // we will stick to this more readable variant
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
