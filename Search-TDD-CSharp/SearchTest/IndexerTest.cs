using static SearchTest.TestEssentials;
using System.Collections.Generic;
using Iveonik.Stemmers;
using NSubstitute;
using Search.DatabaseAndStoring;

using Search.Index;
using Search.IO;
using Search.IO.FolderIO;
using Search.Models;
using Search.Word;
using Xunit;

namespace SearchTest
{
    [Collection("Test Collection 1")]
    public class IndexerTest
    {
        private readonly string _lineSeparator = TestEssentials.LineSeparator;
        private IIndexer _indexer;
        private IFolderReader _reader;
        private IWordProcessor _wordProcessor;
        private IDatabase _database;

        public IndexerTest()
        {
            InitializeFields();
        }

        private void InitializeFields()
        {
            _reader = Substitute.For<IFolderReader>();
            MockFolderReader();
            IStemmer englishStemmer = new EnglishStemmer();
            ICustomStemmer stemmer = new Stemmer(englishStemmer);
            _wordProcessor = new WordProcessor(stemmer);
            _database = new Database();
            _indexer = new Indexer(_reader, _wordProcessor, _database);
        }

        [Fact]
        public void Indexer_ShouldIndexCorrectly_WhenReadingFolder()
        {
            var expectedData = new HashSet<Data>();
            var fileNames = new[]
            {
                new HashSet<string>() {"1"},
                new HashSet<string>() {"3"},
                new HashSet<string>() {"4"}
            };
            AddFilesData(expectedData, fileNames);
            var databaseInfo = new HashSet<Data>();

            _indexer.Index("TestDataBase");
            FillDatabaseInfo(databaseInfo, _database);
            Assert.Equal(expectedData, databaseInfo);
        }

        private void MockFolderReader()
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
        }

        private void AddFile1Data(HashSet<Data> data, HashSet<string>[] fileNames)
        {
            data.Add(MakeData(GetStem("hello"), fileNames[0]));
            data.Add(MakeData(GetStem("dear"), fileNames[0]));
            data.Add(MakeData(GetStem("i"), fileNames[0]));
            data.Add(MakeData(GetStem("am"), fileNames[0]));
            data.Add(MakeData(GetStem("mohammad"), fileNames[0]));
        }

        private void AddFilesData(HashSet<Data> data, HashSet<string>[] fileNames)
        {
            
            AddFile1Data(data, fileNames);
            AddFile2Data(data, fileNames);
            AddFile3Data(data, fileNames);
        }

        private void AddFile2Data(HashSet<Data> data, HashSet<string>[] fileNames)
        {
            data.Add(MakeData(GetStem("man"), fileNames[1]));
            data.Add(MakeData(GetStem("sag"), fileNames[1]));
            data.Add(MakeData(GetStem("mikham"), fileNames[1]));
            data.Add(MakeData(GetStem("khoshgel"), fileNames[1]));
            data.Add(MakeData(GetStem("mikham"), fileNames[1]));
            data.Add(MakeData(GetStem("mio"), fileNames[1]));
        }

        private void AddFile3Data(HashSet<Data> data, HashSet<string>[] fileNames)
        {
            data.Add(MakeData(GetStem("mir"), fileNames[2]));
            data.Add(MakeData(GetStem("rafte"), fileNames[2]));
            data.Add(MakeData(GetStem("dubai"), fileNames[2]));
            data.Add(MakeData(GetStem("vase"), fileNames[2]));
            data.Add(MakeData(GetStem("nakhle"), fileNames[2]));
            data.Add(MakeData(GetStem("talaii"), fileNames[2]));
        }

        private void FillDatabaseInfo(HashSet<Data> data, IDatabase database)
        {
            data.Add(_database.GetData(GetStem("hello")));
            data.Add(_database.GetData(GetStem("dear")));
            data.Add(_database.GetData(GetStem("i")));
            data.Add(_database.GetData(GetStem("am")));
            data.Add(_database.GetData(GetStem("mohammad")));
            data.Add(_database.GetData(GetStem("man")));
            data.Add(_database.GetData(GetStem("sag")));
            data.Add(_database.GetData(GetStem("mikham")));
            data.Add(_database.GetData(GetStem("khoshgel")));
            data.Add(_database.GetData(GetStem("mikham")));
            data.Add(_database.GetData(GetStem("mio")));
            data.Add(_database.GetData(GetStem("mir")));
            data.Add(_database.GetData(GetStem("rafte")));
            data.Add(_database.GetData(GetStem("dubai")));
            data.Add(_database.GetData(GetStem("vase")));
            data.Add(_database.GetData(GetStem("nakhle")));
            data.Add(_database.GetData(GetStem("talaii")));
        }
    }
}