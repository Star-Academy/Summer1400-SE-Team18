using System.Collections.Generic;
using NSubstitute;
using Search.Database;
using Search.Dependencies;
using Search.IO;
using Search.Word;
using Xunit;

namespace SearchTest
{
    public class IndexerTest
    {

        private IReader _reader = Substitute.For<IReader>();
        private IWordProcessor _wordProcessor = Substitute.For<IWordProcessor>();
        private readonly string _ls = TestEssentials.Ls;


        // [Fact]
        // public void IndexingFileTest()
        // {
        //     var expectedData = new HashSet<Data>();
        //     var fileName = new HashSet<string>() {"1"};
        //     expectedData.Add(MakeData(GetStem("hello"), fileName));
        //     expectedData.Add(MakeData(GetStem("dear"), fileName));
        //     expectedData.Add(MakeData(GetStem("i"), fileName));
        //     expectedData.Add(MakeData(GetStem("am"), fileName));
        //     expectedData.Add(MakeData(GetStem("mohammad"), fileName));
        // }

        [Fact]
        public void IndexingFolderTest()
        {
            MockingFolderReader();
            var expectedData = new HashSet<Data>();
            var fileNames = new HashSet<string>[]
            {
                new HashSet<string>(){"1"},
                new HashSet<string>(){"3"},
                new HashSet<string>(){"4"}
            };
            //file 1
            expectedData.Add(MakeData(GetStem("hessllo"), fileNames[0]));
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
                         $"sag khoshgel -  !!! mio !!!{_ls}"
                },
                {
                    "4", "Mir rafte dubai vase nakhle talaii !!"
                }
            };

            _reader.Read("TestDataBase").Returns(folderData);
            Manager.FileReaderInstance = _reader;
        }

        private Data MakeData(string word, HashSet<string> fileNames) {
            return new Data(word, fileNames);
        }

        private string GetStem(string word)
        {
            return Manager.Stemmer.Stem(word);
        }
        
    }
}