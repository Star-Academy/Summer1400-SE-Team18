using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Search.DatabaseAndStoring;
using Search.Index;
using Search.IO.FileIO;
using Search.IO.FolderIO;
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
            var t = (ProgramController)_serviceProvider.GetService(typeof(ProgramController));
            t.run();
        }

        private static void CreateHost()
        {
            var host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                services.AddSingleton<ProgramController>();
                services.AddSingleton<IFileReader, FileReader>();
                services.AddSingleton<IFolderReader, FolderReader>();
                services.AddSingleton<ICustomStemmer, Stemmer>();
                services.AddSingleton<IWordProcessor, WordProcessor>();
                services.AddSingleton<IDatabase, Database>();
                services.AddSingleton<IIndexer, Indexer>();
                services.AddSingleton<ITagCreator, TagCreator>();
                services.AddSingleton<ITagProcessor, TagProcessor>();
            }).Build();
            
            _serviceProvider = host.Services;
        }
    }
}