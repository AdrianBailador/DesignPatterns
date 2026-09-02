using TemplateMethodPattern;

namespace DesignPatterns.Tests;

public class TemplateMethodPatternTests
{
    private static readonly string[] Rows = { "Alice", "Bob", "Charlie" };

    [Fact]
    public void CsvExporter_JoinsRowsWithNewlines()
    {
        DataExporter exporter = new CsvExporter();
        Assert.Equal("Alice\nBob\nCharlie", exporter.Export(Rows));
    }

    [Fact]
    public void JsonExporter_WrapsRowsAsAJsonArrayOfStrings()
    {
        DataExporter exporter = new JsonExporter();
        Assert.Equal("[\"Alice\", \"Bob\", \"Charlie\"]", exporter.Export(Rows));
    }
}
