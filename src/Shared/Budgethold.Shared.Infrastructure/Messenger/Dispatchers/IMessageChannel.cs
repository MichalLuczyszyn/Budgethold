namespace Budgethold.Shared.Infrastructure.Messenger.Dispatchers;

using System.Threading.Channels;
using Abstractions.Messenger;

public interface IMessageChannel
{
    ChannelReader<IMessage> Reader { get; }
    ChannelWriter<IMessage> Writer { get; }
}