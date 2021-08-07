using System;
using static SearchTest.TestEssentials;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;

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
            Dictionary<string, HashSet<string>> tests;
            
            tests = new Dictionary<string, HashSet<string>>()
            {
                {
                    "mir",
                    new HashSet<string>(new[] {"4"})
                },
                {
                    "mikham",
                    new HashSet<string>(new[] {"3"})
                }
            };  
            Assert.All(tests.ToList(),
                testPair => Assert.Equal(_searcher.Search(testPair.Key), testPair.Value));

            
            _managerInstance.Indexer.Index("TestDataBase2");
            tests = new Dictionary<string, HashSet<string>>()
            {
                {
                    "sag mikham",
                    new HashSet<string>(new[] {"3"})
                },
                {
                    "dubai",
                    new HashSet<string>(new[] {"4", "sag"})
                }
            };
            Assert.All(tests.ToList(),
                testPair => Assert.Equal(_searcher.Search(testPair.Key), testPair.Value));
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
            var tests = new Dictionary<string, HashSet<string>>()
            {
                {
                    "mohammad -am",
                    new HashSet<string>(new []{"mohammad"})
                }, 
                {
                    "-amirraftKhonnashoonKhabeshMioomad",
                    new HashSet<string>(new string[]{})
                }, 
                {
                    "taghi +mamooli -dubai",
                    new HashSet<string>(new string[]{})
                }, 
                {
                    "sag +mikham",
                    new HashSet<string>(new []{"gorbe", "3"})
                }, 
                {
                    "sag -mikham",
                    new HashSet<string>(new []{"gorbe"})
                }, 
                {
                    "+dubai",
                    new HashSet<string>(new []{"sag", "4"})
                }, 
                {
                    "+dubai +talaii",
                    new HashSet<string>(new []{"sag", "4"})
                }, 
                {
                    "mohammad -mikham +mohammad",
                    new HashSet<string>(new []{"mohammad", "1"})
                }, 
                {
                    "abbas +rafte +dubai +sag -mikham -taghi",
                    new HashSet<string>(new []{"4", "gorbe", "mohammad"})
                }
            };
            
            Assert.All(tests.ToList(), 
                pair => Assert.Equal(_searcher.Search(pair.Key), pair.Value));
        }

    }
}