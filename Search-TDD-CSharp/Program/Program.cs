using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Program.CommandController;
using Search.DatabaseAndStoring;
using Search.Index;
using Search.IO.FileIO;
using Search.IO.FolderIO;
using Search.Search;
using Search.Tags;
using Search.Word;

namespace Program
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            CreateHost();
            var programController = _serviceProvider.GetService<ProgramController>();
            programController?.Run();
            var db = _serviceProvider.GetService<Database>();
            Console.WriteLine(db.GetData("hi").FilesWithWordInThem.Count);
        }

        private static void CreateHost()
        {
            var host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                services.AddSingleton<ProgramController>();
                services.AddSingleton<IFileReader, FileReader>();
                services.AddSingleton<IFolderReader, FolderReader>();
                services.AddSingleton<IWordProcessor, WordProcessor>();
                services.AddSingleton<IDatabase, Database>();
                services.AddSingleton<IIndexer, Indexer>();
                services.AddSingleton<ITagCreator, TagCreator>();
                services.AddSingleton<ITagProcessor, TagProcessor>();
                services.AddSingleton<ISearcher, Searcher>();
                services.AddSingleton<ICommandParser, CommandParser>();
            }).Build();

            _serviceProvider = host.Services;
        }
    }
}