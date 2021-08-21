using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Program;
using Search.DatabaseAndStoring;
using Search.Index;
using Search.IO.FileIO;
using Search.IO.FolderIO;
using Search.Search;
using Search.Tags;
using Search.Word;

namespace SearchApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<DatabaseContext>();
                    services.AddSingleton<IFileReader, FileReader>();
                    services.AddSingleton<IFolderReader, FolderReader>();
                    services.AddSingleton<ICustomStemmer, Stemmer>();
                    services.AddSingleton<IWordProcessor, WordProcessor>();
                    services.AddSingleton<IDatabase, Database>();
                    services.AddSingleton<IIndexer, Indexer>();
                    services.AddSingleton<ITagCreator, TagCreator>();
                    services.AddSingleton<ITagProcessor, TagProcessor>();
                    services.AddSingleton<ISearcher, Searcher>();
                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}