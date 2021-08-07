using Program.View;
using Search.Index;
using Search.Search;

namespace Program.CommandController
{
    public class CommandParser : ICommandParser
    {

        private const string ReadCommand = "read";
        private const string SearchCommand = "search";
        private const char WhiteSpace = ' ';

        private readonly IIndexer _indexer;
        private readonly ISearcher _searcher;

        public CommandParser(IIndexer indexer, ISearcher searcher)
        {
            _indexer = indexer;
            _searcher = searcher;
        }
        
        public void ParseCommand(string command)
        {
            string parsedCommand = command.Substring(command.IndexOf(WhiteSpace) + 1);
            if (command.StartsWith(ReadCommand))
            {
                ReadExecute(parsedCommand);
            }
            else if (command.StartsWith(SearchCommand))
            {
                SearchExecute(parsedCommand);
            }
        }

        private void ReadExecute(string folderName)
        {
            _indexer.Index(folderName.Trim());
        }

        private void SearchExecute(string command)
        {
            var searchResult = _searcher.Search(command);
            Menu.ShowResult(searchResult);
        }
    }
}