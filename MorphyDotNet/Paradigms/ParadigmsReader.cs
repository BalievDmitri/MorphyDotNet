using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MorphyDotNet.Paradigms
{
    // This is a reader that parses the binary file containing paradigm data
    // It returns lists of int wich is stupid. 
    // A wrapper will be made later to provide a more coherent structure
    internal sealed class ParadigmsReader
    {
        public ParadigmsCollection ReadFromFile(string fileName, IParadigmStrings tags)
        {
            ParadigmsCollection result;
            using (FileStream stream = File.OpenRead(fileName))
                result = ReadFromStream(stream, tags);
            return result;
        }

        public ParadigmsCollection ReadFromStream(Stream stream, IParadigmStrings tags)
        {
            var paradigms = new List<Paradigm>();

            using (BinaryReader reader = new BinaryReader(stream))
            {
                // In the binary file, we first read the number of paradigms present
                int paradigmsCount = reader.ReadUInt16();
                
                for (int i = 0; i < paradigmsCount; i++)
                {
                    // We read the length of the current paradigm
                    int paradigmLength = reader.ReadUInt16();
                    // A paradigm has n entries and n is a multiple of 3
                    var declensions = new List<Declension>(paradigmLength/3);

                    // This loop is not efficient, but since we do it only once
                    // and the filesize is relatively small,
                    // we will stick to this more readable variant

                    // First we have n/3 suffix indexes
                    List<int> suffixIndexes = new List<int>(paradigmLength / 3);
                    for (int j = 0; j < paradigmLength / 3; j++)
                    {
                        suffixIndexes.Add(reader.ReadUInt16());
                    }

                    // Then we have n/3 tag indexes
                    List<int> tagIndexes = new List<int>(paradigmLength / 3);
                    for (int j = 0; j < paradigmLength / 3; j++)
                    {
                        tagIndexes.Add(reader.ReadUInt16());
                    }

                    // The we have n/3 prefix indexes
                    List<int> prefixIndexes = new List<int>(paradigmLength / 3);
                    for (int j = 0; j < paradigmLength / 3; j++)
                    {
                        prefixIndexes.Add(reader.ReadUInt16());
                    }

                    // Now we asseble our declensions
                    for (int j = 0; j < paradigmLength / 3; j++)
                    {
                        declensions.Add(new Declension("prefix", new Tag(tags.GetString(tagIndexes[j])), "suffix"));
                    }

                    paradigms.Add(new Paradigm(declensions));
                }
            }

            return new ParadigmsCollection(paradigms);
        }
    }
}
