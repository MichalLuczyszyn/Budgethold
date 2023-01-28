namespace Budgethold.Shared.Infrastructure.Messenger.Dispatchers;

using System.Threading.Channels;
using Abstractions.Messenger;

internal class MessageChannel : IMessageChannel
{
    private readonly Channel<IMessage> _messages = Channel.CreateUnbounded<IMessage>();

    public ChannelReader<IMessage> Reader { get; }
    public ChannelWriter<IMessage> Writer { get; }
}
