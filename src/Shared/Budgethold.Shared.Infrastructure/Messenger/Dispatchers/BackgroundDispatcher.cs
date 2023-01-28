namespace Budgethold.Shared.Infrastructure.Messenger.Dispatchers;

using Abstractions.Modules;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

internal sealed class BackgroundDispatcher : BackgroundService
{
    private readonly IMessageChannel _messageChannel;
    private readonly IModuleClient _moduleClient;
    private readonly ILogger<BackgroundDispatcher> _logger;

    public BackgroundDispatcher(IMessageChannel messageChannel, IModuleClient moduleClient, ILogger<BackgroundDispatcher> logger)
    {
        _messageChannel = messageChannel;
        _moduleClient = moduleClient;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Running the background dispatcher");

        await foreach (var message in _messageChannel.Reader.ReadAllAsync(stoppingToken))
        {
            try
            {
                await _moduleClient.PublishAsync(message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }
        
        _logger.LogInformation("Finished running the bacground dispatcher");
    }
}
