using IteratorPattern;

namespace DesignPatterns.Tests;

public class IteratorPatternTests
{
    [Fact]
    public void Foreach_VisitsBooksInInsertionOrder()
    {
        var collection = new BookCollection();
        collection.Add("Design Patterns");
        collection.Add("Clean Code");

        var visited = new List<string>();
        foreach (string book in collection)
        {
            visited.Add(book);
        }

        Assert.Equal(new[] { "Design Patterns", "Clean Code" }, visited);
    }

    [Fact]
    public void Foreach_OnEmptyCollection_VisitsNothing()
    {
        var collection = new BookCollection();
        var visited = new List<string>();

        foreach (string book in collection)
        {
            visited.Add(book);
        }

        Assert.Empty(visited);
    }
}
