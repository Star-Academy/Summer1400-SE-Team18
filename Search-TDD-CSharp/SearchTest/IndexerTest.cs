using static SearchTest.TestEssentials;
using System.Collections.Generic;
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

        [Fact]
        public void Indexer_ShouldNotCallDatabase_WhenFolderIsEmpty()
        {
            var wordProcessor = Substitute.For<IWordProcessor>();
            var folderReader = Substitute.For<IFolderReader>();
            folderReader.Read("Abbas").Returns(new Dictionary<string, string>() {});
            var database = Substitute.For<IDatabase>();
            _indexer = new Indexer(folderReader, wordProcessor, database);
            _indexer.Index("Abbas");
            database.DidNotReceive().AddModelData(Arg.Any<Data>());
        }

        [Fact]
        public void Indexer_ShouldCallDatabase_WhenFolderIsNotEmpty()
        {
            var wordProcessor = Substitute.For<IWordProcessor>();
            wordProcessor.ParseText(default).ReturnsForAnyArgs(new List<string>() {"ali", "rafte", "biroon"});
            
            var folderReader = Substitute.For<IFolderReader>();
            folderReader.Read("mohammad").Returns(new Dictionary<string, string>() {{"mohammad", null}});
            
            var database = Substitute.For<IDatabase>();
            database.DoesContainsWord(default).ReturnsForAnyArgs(false);
            _indexer = new Indexer(folderReader, wordProcessor, database);
            
            _indexer.Index("mohammad");
            
            // check for database calls
            database.Received(3).AddModelData(Arg.Any<Data>());
            // database.Received().AddModelData(Arg.Is<Data>(d => d.Word == "ali" && d.FileName == "mohammad"));
            // database.Received().AddModelData(Arg.Is<Data>(d => d.Word == "rafte" && d.FileName == "mohammad"));
            // database.Received().AddModelData(Arg.Is<Data>(d => d.Word == "biroon" && d.FileName == "mohammad"));
        }
    }
}