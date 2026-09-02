using ObserverPattern;

namespace DesignPatterns.Tests;

file class RecordingObserver : IObserver
{
    public List<int> Received { get; } = new();

    public void Update(int i) => Received.Add(i);
}

public class ObserverPatternTests
{
    [Fact]
    public void NotifyRegisteredUsers_NotifiesAllRegisteredObservers()
    {
        var subject = new Subject();
        var observer = new RecordingObserver();

        subject.Register(observer);
        subject.NotifyRegisteredUsers(5);

        Assert.Equal(new[] { 5 }, observer.Received);
    }

    [Fact]
    public void NotifyRegisteredUsers_DoesNotNotifyUnregisteredObservers()
    {
        var subject = new Subject();
        var observer = new RecordingObserver();

        subject.Register(observer);
        subject.Unregister(observer);
        subject.NotifyRegisteredUsers(10);

        Assert.Empty(observer.Received);
    }
}
