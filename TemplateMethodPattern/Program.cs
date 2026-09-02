using System;

namespace TemplateMethodPattern
{
    public abstract class DataExporter
    {
        public string Export(string[] rows)
        {
            return GetHeader() + string.Join(GetRowSeparator(), rows) + GetFooter();
        }

        protected abstract string GetHeader();
        protected abstract string GetRowSeparator();
        protected abstract string GetFooter();
    }

    public class CsvExporter : DataExporter
    {
        protected override string GetHeader() => "";
        protected override string GetRowSeparator() => "\n";
        protected override string GetFooter() => "";
    }

    public class JsonExporter : DataExporter
    {
        protected override string GetHeader() => "[\"";
        protected override string GetRowSeparator() => "\", \"";
        protected override string GetFooter() => "\"]";
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] rows = { "Alice", "Bob", "Charlie" };

            DataExporter csv = new CsvExporter();
            Console.WriteLine("CSV:");
            Console.WriteLine(csv.Export(rows));

            DataExporter json = new JsonExporter();
            Console.WriteLine("\nJSON:");
            Console.WriteLine(json.Export(rows));
        }
    }
}
