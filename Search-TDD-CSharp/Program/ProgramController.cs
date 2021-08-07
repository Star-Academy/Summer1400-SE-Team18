using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Program.View;
using Search.DatabaseAndStoring;
using Search.Index;
using Search.IO;
using Search.IO.FileIO;
using Search.IO.FolderIO;
using Search.Search;
using Search.Tags;
using Search.Word;

namespace Program
{
    public class ProgramController
    {

        private readonly IReader _folderReader;
        private readonly ISearcher _searcher;
        
        public ProgramController(IReader folderReader, ISearcher searcher)
        {
            _folderReader = folderReader;
            _searcher = searcher;
        }
        
        public void run()
        {
            Menu.ShowMessage("******* Welcome to our program *******");
            string command;
            while ((command = Console.ReadLine()) != "quit")
            {
                ParseCommand(command);
            }
        }

        private void ParseCommand(string command)
        {
            
        }

        private void Read(string folderName)
        {
            FolderReader
        }

        private void Search(string command)
        {
            
        }
    }
}