using DependencyInjectionPattern;

namespace DesignPatterns.Tests;

file class RecordingMessage : IMessage
{
    public string? LastMessage { get; private set; }

    public void SendMessage(string message) => LastMessage = message;
}

public class DependencyInjectionPatternTests
{
    [Fact]
    public void Notify_DelegatesToTheInjectedMessage()
    {
        var recorder = new RecordingMessage();
        var notification = new Notification(recorder);

        notification.Notify("hello");

        Assert.Equal("hello", recorder.LastMessage);
    }

    [Fact]
    public void Email_SendMessage_DoesNotThrow()
    {
        IMessage email = new Email();
        var exception = Record.Exception(() => email.SendMessage("test"));

        Assert.Null(exception);
    }
}
