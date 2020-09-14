using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Recurrencia.Services
{
    public class ConsumeScopedService : IHostedService, IDisposable
    {
        public ConsumeScopedService(IServiceProvider services )
        {
            Services = services;
        }
        private Timer _timer;

        public IServiceProvider Services { get; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(20));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        private void DoWork(Object state)
        {
            using (var scope = Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var message="ConsumeScopedService. Received messaje at "+ DateTime.Now.ToString();
                var log = new HostedServiceLog() { Message = message };
                context.HostedServiceLogs.Add(log);
                context.SaveChanges();
            }
        }
    }
}
