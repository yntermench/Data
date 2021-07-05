using LoadData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using Uploading_Data.Components;
using Uploading_Data.Model;

namespace Uploading_Data
{
    class Program
    {
        static void Main()
        {
            string str = ViewApp.Start();
            ApplicationDbContext repository = new ApplicationDbContext(ConfigureDb());
            List<string> words  = WordSearch.SearchWordsDb(str, repository);
            bool isFind = true;
            if (words.Count == 0)
            {
                isFind = false;
            }
            ViewApp.Finish(isFind, words.Count, words);
        }
        static DbContextOptions<ApplicationDbContext> ConfigureDb()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            return options;
        }
    }
}
