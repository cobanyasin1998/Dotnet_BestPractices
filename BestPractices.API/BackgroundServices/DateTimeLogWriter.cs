using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BestPractices.API.BackgroundServices
{
    public class DateTimeLogWriter : IHostedService, IDisposable
    {
        private Timer _timer;


        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(DateTimeLogWriter) } Service Started");

            _timer = new Timer(writeDateTimeOnLog, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

            return Task.CompletedTask;
        }

        private void writeDateTimeOnLog(object state)
        {
            Console.WriteLine($"Datetime is {DateTime.Now.ToLongTimeString()}");
        }



        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            Console.WriteLine($"{nameof(DateTimeLogWriter) } Service Stopped");
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer = null;
        }
    }


    public class DateTimeLogWriter2 : BackgroundService
    {
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
