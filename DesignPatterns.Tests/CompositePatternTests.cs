using CompositePattern;

namespace DesignPatterns.Tests;

public class CompositePatternTests
{
    [Fact]
    public void GetSize_OnAFile_ReturnsItsOwnSize()
    {
        var file = new FileItem("readme.txt", 10);
        Assert.Equal(10, file.GetSize());
    }

    [Fact]
    public void GetSize_OnADirectory_SumsAllDescendants()
    {
        var docs = new DirectoryItem("docs");
        docs.Add(new FileItem("readme.txt", 10));
        docs.Add(new FileItem("notes.txt", 5));

        var root = new DirectoryItem("root");
        root.Add(docs);
        root.Add(new FileItem("setup.exe", 100));

        Assert.Equal(115, root.GetSize());
    }

    [Fact]
    public void GetSize_OnAnEmptyDirectory_ReturnsZero()
    {
        var empty = new DirectoryItem("empty");
        Assert.Equal(0, empty.GetSize());
    }
}
