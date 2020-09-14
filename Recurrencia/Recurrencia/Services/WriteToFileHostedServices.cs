using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Recurrencia.Services
{
    public class WriteToFileHostedServices : IHostedService, IDisposable
    {
        private readonly IHostingEnvironment environment;
        private readonly string filename = "File 1.txt";
        private Timer timer;

        public WriteToFileHostedServices(IHostingEnvironment environment)
        {
            this.environment = environment;

        }

        public void Dispose()
        {
            timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            WriteToFile("WriteToFileHostedService: Process Started");
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            WriteToFile("WriteToFileHostedService: Process stopped");
            timer.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private void DoWork(Object state)
        {
            WriteToFile("WriteToFileHostedService: Doing some work at: " + 
                DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
        }
        private void WriteToFile(string message)
        {
            var path = $@"{ environment.ContentRootPath}\wwwroot\{filename}";
            using (StreamWriter writer=new StreamWriter(path, append: true))
            {
                writer.WriteLine(message);
            }

        }
    }
}
