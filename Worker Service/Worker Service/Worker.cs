using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Worker_Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
                var listFileFirst = Directory.GetDirectories(@"D:\Learn\CTY\Buoi3\");
            while (!stoppingToken.IsCancellationRequested)
            {
                var listFileFirst2 = Directory.GetDirectories(@"D:\Learn\CTY\Buoi3\");
                if(listFileFirst2.Length>listFileFirst.Length)
                {
                    foreach (var item in listFileFirst2)
                    {
                        if (!listFileFirst.Contains(item))
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
                Directory.CreateDirectory(@"D:\Learn\CTY\Buoi3\foldernew");
                //foreach (var item in listFileFirst)
                //{
                //    item
                //}
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
