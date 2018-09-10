using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MorphyDotNet;
using MorphyDotNet.DictUtils;
using Moq;
using MorphyDotNet.Paradigms;

namespace MorphyDotNet.Tests.DictUtils
{
    [TestFixture]
    public class WordDictionaryTests
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(65)]
        [TestCase(65046)]
        public void MatchParses_should_return_same_number_of_parses_as_words_in_dictionary(int numberOfWords)
        {
            // Arrange
            var dictionaryParseResult = Enumerable.Repeat(new DictionaryMatch("word", 0, 0), numberOfWords).ToList();

            var dictMock = new Mock<IWordMatchingDictionary>();
            dictMock.Setup(dict => dict.MatchWord(It.IsAny<string>())).Returns(dictionaryParseResult);

            var tagsMoq = new Mock<IParadigmStrings>();
            tagsMoq.Setup(tag => tag.GetString(It.IsAny<int>())).Returns("Tag");
            
            var sut = new WordDictionary(dictMock.Object, tagsMoq.Object, new List<List<int>>() { new List<int>() { 0 } });

            // Act
            var expected = numberOfWords;
            var actual = sut.MatchParses("word").Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
