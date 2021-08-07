using static SearchTest.TestEssentials;
using System;
using System.Collections.Generic;
using System.Linq;
using Iveonik.Stemmers;
using NSubstitute;
using Search.IO;
using Search.IO.FileIO;
using Search.IO.FolderIO;
using Search.Search;
using Search.Tags;
using Search.Word;
using Xunit;

namespace SearchTest
{
    [Collection("Test Collection 1")]
    public class SearchTest
    {
        private ISearcher _searcher;
        private IIndexer _indexer;

        public SearchTest()
        {
            Reset();
            InitializeFields();
        }

        private void InitializeFields()
        {
            IStemmer stemmer = new EnglishStemmer();
            ICustomStemmer customStemmer = new Stemmer(stemmer);
            ITagProcessor tagProcessor = new TagProcessor(customStemmer);
            ITagCreator tagCreator = new TagCreator(tagProcessor);
            IDatabase database = new Database();
            _searcher = new Searcher(tagCreator, database);
            IFolderReader folderReader = Substitute.For<IFolderReader>();
            MockFolderReaderForDataBase(folderReader);
            MockFolderReaderForDataBase2(folderReader);
            IWordProcessor wordProcessor = new WordProcessor(customStemmer);
            _indexer = new Indexer(folderReader, wordProcessor, database);

        }
        
        [Fact]
        public void Search_ShouldSearchCorrectly_ForOneWord()
        {
            _indexer.Index("TestDataBase");

            var tests = new Dictionary<string, HashSet<string>>()
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

            
            _indexer.Index("TestDataBase2");
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
            _indexer.Index("TestDataBase");
            Assert.Equal(_searcher.Search("mohammad -am"), (new HashSet<string>(new string[] { })));
        }

        [Fact]
        public void Search_ShouldSearchCorrectly_ForTwoFolders()
        {
            _indexer.Index("TestDataBase");
            _indexer.Index("TestDataBase2");
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