using static SearchTest.TestEssentials;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using Search.Dependencies;
using Search.IO;
using Search.Searcher;
using Xunit;

namespace SearchTest
{
    public class SearchTest
    {
        private ISearcher _searcher;
        private static string _ls = TestEssentials.Ls;

        [Fact]
        public void Should_Search_For_One_Word()
        {
            IReader folderReader = new FolderReader();
            MockFolderReaderForDataBase(folderReader);
            MockFolderReaderForDataBase2(folderReader);
            Manager.Indexer.Index("TestDataBase");
            Assert.Equal(_searcher.Search("mir"), new HashSet<string>(new[] {"4"}));
            Assert.Equal(_searcher.Search("mikham"), new HashSet<string>(new[] {"3"}));
            Manager.Indexer.Index("TestDataBase2");
            Assert.Equal(_searcher.Search("sag"), new HashSet<string>(new[] {"3", "gorbe"}));
            Assert.Equal(_searcher.Search("dubai"), new HashSet<string>(new[] {"4", "sag"}));
        }

        [Fact]
        public void Should_Search_Properly_For_One_Folder()
        {
            IReader folderReader = Substitute.For<IReader>();
            MockFolderReaderForDataBase(folderReader);
            Manager.Indexer.Index("TestDataBase");
            Assert.Equal(_searcher.Search("mohammad -am"), (new HashSet<string>(new string[] { })));
        }

        [Fact]
        public void Should_Advance_Search_For_Two_Folders()
        {
            IReader folderReader = Substitute.For<IReader>();
            MockFolderReaderForDataBase(folderReader);
            MockFolderReaderForDataBase2(folderReader);
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