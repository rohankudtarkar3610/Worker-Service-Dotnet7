namespace WorkerServiceApp
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private readonly IUserService userService;
        public Worker(ILogger<Worker> logger, IUserService userService)
        {
            this.logger = logger;
            this.userService= userService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation("Execution Started");
                try
                {
                    logger.LogInformation("getdata Started");
                    logger.LogInformation("logic");
                    //logger.LogInformation("data "+ userService.GetData());
                    logger.LogInformation("getdata stopped");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, ex.Message);
                    throw;
                }
                await Task.Delay(10000, stoppingToken);
            }
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Service Started");
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Service Stopped");
            return base.StopAsync(cancellationToken);
        }
    }
}