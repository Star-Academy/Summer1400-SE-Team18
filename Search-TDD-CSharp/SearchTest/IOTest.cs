using System;
using System.Collections.Generic;
using Search.IO;
using Xunit;

namespace SearchTest
{
    public class IoTest
    {
        private IReader _fileReader;
        private IReader _folderReader;
        
        [Fact]
        public void ReadFileTest()
        {
            var readingData = _fileReader.Read("TestDataBase/3");
            string expectedString;
            expectedString = "man sag mikham\nsag khoshgel - mikham !!! mio !!!\n";
            Assert.Equal(expectedString, readingData["3"]);
        }

        [Fact]
        public void ReadFolderTest()
        {
            var readingData = _folderReader.Read("TestDataBase");
            var expectedData = new Dictionary<string, string>()
            {
                {
                    "1", "Hello Dear,\n" +
                         "I am Mohammad.\n"
                },
                {
                    "3", "man sag mikham\n" +
                         "sag khoshgel - mikham !!! mio !!!\n"
                },
                {
                    "4", "Mir rafte dubai vase nakhle talaii !!"
                }
            };
            
            Assert.Equal(readingData, expectedData);
        }
    }
}