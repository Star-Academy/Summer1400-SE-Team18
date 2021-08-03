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
            var readingString = _fileReader.Read("TestDataBase/3");
            var expectedString = "man sag mikham\nsag khoshgel - mikham !!! mio !!!\n";
        }

        [Fact]
        public void ReadFolderTest()
        {
            
        }
    }
}