// using System;
// using static SearchTest.TestEssentials;
// using System.Collections.Generic;
// using System.Linq;
// using Iveonik.Stemmers;
// using NSubstitute;
// using Search.DatabaseAndStoring;
// using Search.Index;
// using Search.IO.FolderIO;
// using Search.Search;
// using Search.Tags;
// using Search.Word;
// using Xunit;
//
// namespace SearchTest
// {
//     [Collection("Test Collection 1")]
//     public class SearchTest
//     {
//         private ISearcher _searcher;
//         private IIndexer _indexer;
//
//         public SearchTest()
//         {
//             InitializeFields();
//         }
//
//         private void InitializeFields()
//         {
//             IStemmer stemmer = new EnglishStemmer();
//             ICustomStemmer customStemmer = new ICustomStemmer();
//             ITagProcessor tagProcessor = new TagProcessor(customStemmer);
//             ITagCreator tagCreator = new TagCreator(tagProcessor);
//             IDatabase database = new Database(new DatabaseContext());
//             _searcher = new Searcher(tagCreator, database);
//             IFolderReader folderReader = Substitute.For<IFolderReader>();
//             MockFolderReaderForDataBase(folderReader);
//             MockFolderReaderForDataBase2(folderReader);
//             IWordProcessor wordProcessor = new WordProcessor(customStemmer);
//             _indexer = new Indexer(folderReader, wordProcessor, database);
//         }
//
//         [Fact]
//         public void Search_ShouldSearchCorrectly_ForOneWord()
//         {
//             _indexer.Index("TestDataBase");
//
//             var tests = new Dictionary<string, HashSet<string>>()
//             {
//                 {
//                     "mir",
//                     new HashSet<string>(new[] {"4"})
//                 },
//                 {
//                     "mikham",
//                     new HashSet<string>(new[] {"3"})
//                 }
//             };
//             Assert.All(tests.ToList(),
//                 testPair => Assert.Equal(_searcher.Search(testPair.Key), testPair.Value));
//
//
//             _indexer.Index("TestDataBase2");
//             tests = new Dictionary<string, HashSet<string>>()
//             {
//                 {
//                     "sag mikham",
//                     new HashSet<string>(new[] {"3"})
//                 },
//                 {
//                     "dubai",
//                     new HashSet<string>(new[] {"4", "sag"})
//                 }
//             };
//             Assert.All(tests.ToList(),
//                 testPair => Assert.Equal(_searcher.Search(testPair.Key), testPair.Value));
//         }
//
//         [Fact]
//         public void Search_ShouldSearchCorrectly_ForOneFolder()
//         {
//             _indexer.Index("TestDataBase");
//             Assert.Equal(new HashSet<string>(System.Array.Empty<string>()), _searcher.Search("mohammad -am"));
//         }
//
//         [Theory]
//         [MemberData(nameof(Get_Search_ShouldSearchCorrectly_ForTwoFolders_TestData))]
//         public void Search_ShouldSearchCorrectly_ForTwoFolders(string searchFor, HashSet<string> expectedAnswer)
//         {
//             _indexer.Index("TestDataBase");
//             _indexer.Index("TestDataBase2");
//             Assert.Equal(expectedAnswer, _searcher.Search(searchFor));
//         }
//
//         public static IEnumerable<Object[]> Get_Search_ShouldSearchCorrectly_ForTwoFolders_TestData()
//         {
//             return new List<object[]>()
//             {
//                 new object[]
//                 {
//                     "mohammad -am",
//                     new HashSet<string>(new[] {"mohammad"})
//                 },
//                 new object[]
//                 {
//                     "-amirraftKhonnashoonKhabeshMioomad",
//                     new HashSet<string>(new string[] { })
//                 },
//                 new object[]
//                 {
//                     "taghi +mamooli -dubai",
//                     new HashSet<string>(new string[] { })
//                 },
//                 new object[]
//                 {
//                     "sag +mikham",
//                     new HashSet<string>(new[] {"gorbe", "3"})
//                 },
//                 new object[]
//                 {
//                     "sag -mikham",
//                     new HashSet<string>(new[] {"gorbe"})
//                 },
//                 new object[]
//                 {
//                     "+dubai",
//                     new HashSet<string>(new[] {"sag", "4"})
//                 },
//                 new object[]
//                 {
//                     "+dubai +talaii",
//                     new HashSet<string>(new[] {"sag", "4"})
//                 },
//                 new object[]
//                 {
//                     "mohammad -mikham +mohammad",
//                     new HashSet<string>(new[] {"mohammad", "1"})
//                 },
//                 new object[]
//                 {
//                     "abbas +rafte +dubai +sag -mikham -taghi",
//                     new HashSet<string>(new[] {"4", "gorbe", "mohammad"})
//                 }
//             };
//         }
//     }
// }