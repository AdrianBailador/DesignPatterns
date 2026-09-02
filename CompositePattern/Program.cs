using System;
using System.Collections.Generic;

namespace CompositePattern
{
    public abstract class FileSystemItem
    {
        public string Name { get; }

        protected FileSystemItem(string name)
        {
            Name = name;
        }

        public abstract int GetSize();
    }

    public class FileItem : FileSystemItem
    {
        private readonly int size;

        public FileItem(string name, int size) : base(name)
        {
            this.size = size;
        }

        public override int GetSize() => size;
    }

    public class DirectoryItem : FileSystemItem
    {
        private readonly List<FileSystemItem> children = new();

        public DirectoryItem(string name) : base(name) { }

        public void Add(FileSystemItem item) => children.Add(item);

        public override int GetSize()
        {
            int total = 0;
            foreach (var child in children)
            {
                total += child.GetSize();
            }
            return total;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var root = new DirectoryItem("root");
            var docs = new DirectoryItem("docs");

            docs.Add(new FileItem("readme.txt", 10));
            docs.Add(new FileItem("notes.txt", 5));

            root.Add(docs);
            root.Add(new FileItem("setup.exe", 100));

            Console.WriteLine($"Total size: {root.GetSize()}");
        }
    }
}
