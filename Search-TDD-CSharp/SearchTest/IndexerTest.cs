using static SearchTest.TestEssentials;
using System.Collections.Generic;
using NSubstitute;
using Search.DatabaseAndStoring;
using Search.Dependencies;
using Search.Index;
using Search.IO;
using Xunit;

namespace SearchTest
{
    [Collection("Test Collection 1")]
    public class IndexerTest
    {
        private readonly IIndexer _indexer = new Indexer();
        private readonly IReader _reader = Substitute.For<IReader>();
        private readonly string _ls = TestEssentials.Ls;

        public IndexerTest()
        {
            Manager.Reset();
        }

        [Fact]
        public void Should_Index_Correctly_WhenReading_Folder()
        {
            MockingFolderReader();
            var expectedData = new HashSet<Data>();
            var fileNames = new []
            {
                new HashSet<string>() {"1"},
                new HashSet<string>() {"3"},
                new HashSet<string>() {"4"}
            };
            //file 1
            expectedData.Add(MakeData(GetStem("hello"), fileNames[0]));
            expectedData.Add(MakeData(GetStem("dear"), fileNames[0]));
            expectedData.Add(MakeData(GetStem("i"), fileNames[0]));
            expectedData.Add(MakeData(GetStem("am"), fileNames[0]));
            expectedData.Add(MakeData(GetStem("mohammad"), fileNames[0]));
            //file 3
            expectedData.Add(MakeData(GetStem("man"), fileNames[1]));
            expectedData.Add(MakeData(GetStem("sag"), fileNames[1]));
            expectedData.Add(MakeData(GetStem("mikham"), fileNames[1]));
            expectedData.Add(MakeData(GetStem("khoshgel"), fileNames[1]));
            expectedData.Add(MakeData(GetStem("mikham"), fileNames[1]));
            expectedData.Add(MakeData(GetStem("mio"), fileNames[1]));
            //file 4
            expectedData.Add(MakeData(GetStem("mir"), fileNames[2]));
            expectedData.Add(MakeData(GetStem("rafte"), fileNames[2]));
            expectedData.Add(MakeData(GetStem("dubai"), fileNames[2]));
            expectedData.Add(MakeData(GetStem("vase"), fileNames[2]));
            expectedData.Add(MakeData(GetStem("nakhle"), fileNames[2]));
            expectedData.Add(MakeData(GetStem("talaii"), fileNames[2]));

            _indexer.Index("TestDataBase");
            Assert.Equal(expectedData, Manager.Database.GetAllData());
        }

        private void MockingFolderReader()
        {
            var folderData = new Dictionary<string, string>()
            {
                {
                    "1", $"Hello Dear,{_ls}" +
                         $"I am Mohammad.{_ls}"
                },
                {
                    "3", $"man sag mikham{_ls}" +
                         $"sag khoshgel - mikham !!! mio !!!{_ls}"
                },
                {
                    "4", "Mir rafte dubai vase nakhle talaii !!"
                }
            };

            _reader.Read("TestDataBase").Returns(folderData);
            Manager.FolderReaderInstance = _reader;
        }
    }
}