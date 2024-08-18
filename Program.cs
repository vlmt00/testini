using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace testini;

class Program
{
    static void Main(string[] args)
    {
        string filename = "launcher.ini";
        string path = Directory.GetCurrentDirectory();

        Console.WriteLine(" {0}", path);
         // Build a configuration object from INI file
        IConfigurationBuilder builder = new ConfigurationBuilder()
            .AddIniFile(path + "\\" + filename);
        IConfiguration config;
        IConfigurationSection section;
        try{
            config = builder.Build();
        }
        catch(System.IO.FileNotFoundException ex)
        {
            Console.WriteLine("File not found : \"{0}\".", path + "\\" + filename);
            return;
        }
        // Get a configuration section
        section = config.GetSection("Config");

        // Read configuration values
        Console.WriteLine($"maxLines: {section["maxLines"]}");
        Console.WriteLine($"DisplayDuration: {section["DisplayDuration"]}");
    }
}
