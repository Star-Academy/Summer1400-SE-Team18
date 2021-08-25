using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Search.DatabaseAndStoring;
using Search.Index;
using Search.IO.FileIO;
using Search.IO.FolderIO;
using Search.Search;
using Search.Tags;
using Search.Word;
using SearchWeb.Controllers;

namespace SearchWeb
{
    public class Program
    {
        public static IHost HostStatic { get; set; }
        public static void Main(string[] args)
        {
            HostStatic = CreateHostBuilder(args).Build();
            HostStatic.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IFileReader, FileReader>();
                    services.AddSingleton<IFolderReader, FolderReader>();
                    services.AddSingleton<IWordProcessor, WordProcessor>();
                    services.AddSingleton<IDatabase, Database>();
                    services.AddSingleton<IIndexer, Indexer>();
                    services.AddSingleton<ITagCreator, TagCreator>();
                    services.AddSingleton<ITagProcessor, TagProcessor>();
                    services.AddSingleton<ISearcher, Searcher>();
                    services.AddSingleton<ResultController>();
                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}