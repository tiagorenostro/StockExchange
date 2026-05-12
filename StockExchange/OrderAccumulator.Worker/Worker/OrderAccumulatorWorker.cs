namespace OrderAccumulator.Worker.Worker;

public class OrderAccumulatorWorker(IAcceptor acceptor, ILogger<OrderAccumulatorWorker> logger) : BackgroundService
{
    private const string Starting = "Starting FIX Acceptor...";
    private const string Stopping = "Stopping FIX Acceptor...";
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation(Starting);
        acceptor.Start();

        return Task.CompletedTask;
    }
    
    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation(Stopping);
        acceptor.Stop();
        await base.StopAsync(cancellationToken);
    }
}