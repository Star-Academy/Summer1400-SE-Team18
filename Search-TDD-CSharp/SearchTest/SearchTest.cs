using System.Collections.Generic;
using NSubstitute;
using Search.DatabaseAndStoring;
using Search.Search;
using Search.Tags;
using Xunit;

namespace SearchTest
{
    [Collection("Test Collection 1")]
    public class SearchTest
    {
        private ISearcher _searcher;

        [Fact]
        public void Search_ShouldOperateCorrectSetOperations_WhenRetainingAndJoining1()
        {
            // mock tag creator
            var tagCreator = Substitute.For<ITagCreator>();
            tagCreator.CreateTags("mir").Returns(new HashSet<Tag>()
            {
                new Tag("mir", TagType.NoTag)
            });
            tagCreator.CreateTags("mir dubai").Returns(new HashSet<Tag>()
            {
                new Tag("dubai", TagType.NoTag),
                new Tag("mir", TagType.NoTag)
            });

            // mock database
            var database = Substitute.For<IDatabase>();
            database.GetData(Arg.Is<string>(s => s == "mir")).Returns(new Data("mir", new HashSet<string>()
            {
                "1", "2"
            }));
            database.GetData(Arg.Is<string>(s => s == "dubai")).Returns(new Data("dubai", new HashSet<string>()
            {
                "1"
            }));

            // create searcher
            _searcher = new Searcher(tagCreator, database);

            Assert.Equal(_searcher.Search("mir"), new HashSet<string>() {"1", "2"});
            Assert.Equal(_searcher.Search("mir dubai"), new HashSet<string>() {"1"});
        }

        [Fact]
        public void Search_ShouldOperateCorrectSetOperations_WhenRetainingAndJoining2()
        {
            const string firstTest = "mir +mohammad -ali";
            const string secondTest = "mir +mohammad";
            const string thirdTest = "+mohammad -ali";
            const string fourthTest = "ali -mir";
            const string fifthTest = "-mir";
            // mock tag creator
            var tagCreator = Substitute.For<ITagCreator>();
            tagCreator.CreateTags(firstTest).Returns(new HashSet<Tag>()
            {
                new Tag("mir", TagType.NoTag),
                new Tag("mohammad", TagType.Plus),
                new Tag("ali", TagType.Minus),
            });
            tagCreator.CreateTags(secondTest).Returns(new HashSet<Tag>()
            {
                new Tag("mohammad", TagType.Plus),
                new Tag("mir", TagType.NoTag)
            });
            tagCreator.CreateTags(thirdTest).Returns(new HashSet<Tag>()
            {
                new Tag("mohammad", TagType.Plus),
                new Tag("ali", TagType.Minus)
            });
            tagCreator.CreateTags(fourthTest).Returns(new HashSet<Tag>()
            {
                new Tag("ali", TagType.NoTag),
                new Tag("mir", TagType.Minus)
            });
            tagCreator.CreateTags(fifthTest).Returns(new HashSet<Tag>()
            {
                new Tag("mir", TagType.Minus)
            });

            // mock database
            var database = Substitute.For<IDatabase>();
            database.GetData(Arg.Is<string>(s => s == "mir")).Returns(new Data("mir", new HashSet<string>()
            {
                "1", "2"
            }));
            database.GetData(Arg.Is<string>(s => s == "mohammad")).Returns(new Data("mohammad", new HashSet<string>()
            {
                "1", "3", "4"
            }));
            database.GetData(Arg.Is<string>(s => s == "ali")).Returns(new Data("ali", new HashSet<string>()
            {
                "1", "2", "4"
            }));

            // create searcher
            _searcher = new Searcher(tagCreator, database);

            Assert.Equal(_searcher.Search(firstTest), new HashSet<string>() {"3"});
            Assert.Equal(_searcher.Search(secondTest), new HashSet<string>() {"1", "2", "3", "4"});
            Assert.Equal(_searcher.Search(thirdTest), new HashSet<string>() {"3"});
            Assert.Equal(_searcher.Search(fourthTest), new HashSet<string>() {"4"});
            Assert.Equal(_searcher.Search(fifthTest), new HashSet<string>());
        }
    }
}