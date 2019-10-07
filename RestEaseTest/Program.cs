using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestEase;

namespace RestEaseTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MakeCallToGitHubAsync();
            CreateWebHostBuilder(args).Build().Run();
        }

        private static async void MakeCallToGitHubAsync()
        {
            var githubClient = RestClient.For<IGithubClient>("https://api.github.com");
            var user = await githubClient.GetUserAsync("thiagoruggiero", CancellationToken.None);
            Console.WriteLine(user.ReceivedEventsUrl);
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
