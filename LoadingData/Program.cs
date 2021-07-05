using LoadData.Model;
using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LoadData
{
    public class Program
    {
        static void Main()
        {
            ApplicationDbContext repository = new ApplicationDbContext(ConfigureDb());
            Console.Write("Введите путь файла: ");
            string path = Console.ReadLine();
            Console.Clear();

            string[] text = TextFile.LoadTextFile(@path);

            TextFile.RenderWordsFile(repository, text);
            Console.ReadLine();
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
