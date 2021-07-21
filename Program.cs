using ConsoleAppCommandLine.Helpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleAppCommandLine
{
    public class Program
    {
        private static IConfiguration _config;
        private static AppSettingsUpdater _settingsUpdater;

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(GetBasePath())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            if (Array.IndexOf(args, "--?") >= 0 || Array.IndexOf(args, "--help") >= 0)

            builder.AddCommandLine(args);

            _config = builder.Build();
            _settingsUpdater = new AppSettingsUpdater();

            //var help = GetParamValue("?", "help");
            //if (help != null)
            if (Array.IndexOf(args, "--?") >= 0 || Array.IndexOf(args, "--help") >= 0)
            {
                Console.WriteLine("Update the RestAPI settings\n");
                Console.WriteLine("--n | --name <value>           Set the Name");
                Console.WriteLine("--u | --username <value>       Set the UserName");
                Console.WriteLine("--p | --password <value>       Set the Password");
                Console.WriteLine("--c | --clientid <value>       Set the ClientId");
                Console.WriteLine("--s | --clientsecret <value>   Set the ClientSecret");
                return;
            }

            ProcessParam("Name", "n", "name", false);
            ProcessParam("UserName", "u", "username", false);
            ProcessParam("Password", "p", "password", true);
            ProcessParam("ClientId", "c", "clientid", false);
            ProcessParam("ClientSecret", "s", "clientsecret", true);
        }

        private static string GetBasePath()
        {
            //var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            //var isDevelopment = environment == Environments.Development;
            //if (isDevelopment)
            //{
            //    return Directory.GetCurrentDirectory();
            //}
            using var processModule = Process.GetCurrentProcess().MainModule;
            return Path.GetDirectoryName(processModule?.FileName);
        }

        private static void ProcessParam(string name, string key1, string key2, bool encrypt)
        {
            var value = GetParamValue(key1, key2);
            if (value != null)
                _settingsUpdater.UpdateAppSetting($"RestAPI:{name}", encrypt ? value.EncodeBase64() : value);
        }

        private static string GetParamValue(string key1, string key2)
        {
            return _config[key1.ToLower()] ?? _config[key2.ToLower()];
        }
    }
}
