namespace Budgethold.Shared.Infrastructure.Messenger.Dispatchers;

using System.Threading.Channels;
using Abstractions.Messenger;

internal class MessageChannel : IMessageChannel
{
    private readonly Channel<IMessage> _messages = Channel.CreateUnbounded<IMessage>();

    public ChannelReader<IMessage> Reader => _messages.Reader;
    public ChannelWriter<IMessage> Writer => _messages.Writer;
}
