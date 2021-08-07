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
        
        private readonly Manager _managerInstance = Manager.GetInstance();

        private readonly IIndexer _indexer = new Indexer();
        private readonly IReader _reader = Substitute.For<IReader>();
        private readonly string _lineSeparator = TestEssentials.LineSeparator;

        public IndexerTest()
        {
            Reset();
        }

        [Fact]
        public void Indexer_ShouldIndexCorrectly_WhenReadingFolder()
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
            Database database = _managerInstance.Database;
            var databaseInfo = new HashSet<Data>();

            _indexer.Index("TestDataBase");

            databaseInfo.Add(database.GetData(GetStem("hello")));
            databaseInfo.Add(database.GetData(GetStem("dear")));
            databaseInfo.Add(database.GetData(GetStem("i")));
            databaseInfo.Add(database.GetData(GetStem("am")));
            databaseInfo.Add(database.GetData(GetStem("mohammad")));
            databaseInfo.Add(database.GetData(GetStem("man")));
            databaseInfo.Add(database.GetData(GetStem("sag")));
            databaseInfo.Add(database.GetData(GetStem("mikham")));
            databaseInfo.Add(database.GetData(GetStem("khoshgel")));
            databaseInfo.Add(database.GetData(GetStem("mikham")));
            databaseInfo.Add(database.GetData(GetStem("mio")));
            databaseInfo.Add(database.GetData(GetStem("mir")));
            databaseInfo.Add(database.GetData(GetStem("rafte")));
            databaseInfo.Add(database.GetData(GetStem("dubai")));
            databaseInfo.Add(database.GetData(GetStem("vase")));
            databaseInfo.Add(database.GetData(GetStem("nakhle")));
            databaseInfo.Add(database.GetData(GetStem("talaii")));

            Assert.Equal(expectedData, databaseInfo);
        }

        private void MockingFolderReader()
        {
            var folderData = new Dictionary<string, string>()
            {
                {
                    "1", $"Hello Dear,{_lineSeparator}" +
                         $"I am Mohammad.{_lineSeparator}"
                },
                {
                    "3", $"man sag mikham{_lineSeparator}" +
                         $"sag khoshgel - mikham !!! mio !!!{_lineSeparator}"
                },
                {
                    "4", "Mir rafte dubai vase nakhle talaii !!"
                }
            };

            _reader.Read("TestDataBase").Returns(folderData);
            _managerInstance.FolderReaderInstance = _reader;
        }
    }
}