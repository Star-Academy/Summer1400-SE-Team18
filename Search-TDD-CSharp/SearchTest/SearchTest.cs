using static SearchTest.TestEssentials;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using Search.Dependencies;
using Search.IO;
using Search.Search;
using Xunit;

namespace SearchTest
{
    [Collection("Test Collection 1")]
    public class SearchTest
    {
        
        private readonly Manager _managerInstance = Manager.GetInstance();

        private readonly ISearcher _searcher = new Searcher();

        public SearchTest()
        {
            Reset();
        }
        
        [Fact]
        public void Search_ShouldSearchCorrectly_ForOneWord()
        {
            var folderReader = Substitute.For<IReader>();
            MockFolderReaderForDataBase(folderReader);
            MockFolderReaderForDataBase2(folderReader);
            _managerInstance.FolderReaderInstance = folderReader;
            _managerInstance.Indexer.Index("TestDataBase");
            Assert.All(new []
            {
                new {
                    SearchFor = "mir",
                    Answers = new HashSet<string>(new []{"4"})
                }, 
                new {
                    SearchFor = "mikham",
                    Answers = new HashSet<string>(new []{"3"})
                }
            }.Select(str => str), (commandAndAnswers) => 
                Assert.Equal(_searcher.Search(commandAndAnswers.SearchFor), commandAndAnswers.Answers));
            _managerInstance.Indexer.Index("TestDataBase2");
            Assert.All(new []
            {
                new {
                    SearchFor = "sag mikham",
                    Answers = new HashSet<string>(new []{"3"})
                }, 
                new {
                    SearchFor = "dubai",
                    Answers = new HashSet<string>(new []{"4", "sag"})
                }
            }.Select(str => str), (commandAndAnswers) => 
                Assert.Equal(_searcher.Search(commandAndAnswers.SearchFor), commandAndAnswers.Answers));
        }

        [Fact]
        public void Search_ShouldSearchCorrectly_ForOneFolder()
        {
            var folderReader = Substitute.For<IReader>();
            MockFolderReaderForDataBase(folderReader);
            _managerInstance.Indexer.Index("TestDataBase");
            _managerInstance.FolderReaderInstance = folderReader;
            Assert.Equal(_searcher.Search("mohammad -am"), (new HashSet<string>(new string[] { })));
        }

        [Fact]
        public void Search_ShouldSearchCorrectly_ForTwoFolders()
        {
            var folderReader = Substitute.For<IReader>();
            MockFolderReaderForDataBase(folderReader);
            MockFolderReaderForDataBase2(folderReader);
            _managerInstance.FolderReaderInstance = folderReader;
            _managerInstance.Indexer.Index("TestDataBase");
            _managerInstance.Indexer.Index("TestDataBase2");
            Assert.All(new []
            {
                new {
                    SearchFor = "mohammad -am",
                    Answers = new HashSet<string>(new []{"mohammad"})
                }, 
                new {
                    SearchFor = "-amirraftKhonnashoonKhabeshMioomad",
                    Answers = new HashSet<string>(new string[]{})
                },
                new {
                    SearchFor = "taghi +mamooli -dubai",
                    Answers = new HashSet<string>(new string[]{})
                },
                new {
                    SearchFor = "sag +mikham",
                    Answers = new HashSet<string>(new []{"gorbe", "3"})
                },
                new {
                    SearchFor = "sag -mikham",
                    Answers = new HashSet<string>(new []{"gorbe"})
                },
                new {
                    SearchFor = "+dubai",
                    Answers = new HashSet<string>(new []{"sag", "4"})
                },
                new {
                    SearchFor = "+dubai +talaii",
                    Answers = new HashSet<string>(new []{"sag", "4"})
                },
                new {
                    SearchFor = "mohammad -mikham +mohammad",
                    Answers = new HashSet<string>(new []{"mohammad", "1"})
                },
                new {
                    SearchFor = "abbas +rafte +dubai +sag -mikham -taghi",
                    Answers = new HashSet<string>(new []{"4", "gorbe", "mohammad"})
                }
            }.Select(str => str), (commandAndAnswers) => 
                Assert.Equal(_searcher.Search(commandAndAnswers.SearchFor), commandAndAnswers.Answers));
        }
    }
}