using System;
using System.Collections;
using System.Collections.Generic;

namespace IteratorPattern
{
    public class BookCollection : IEnumerable<string>
    {
        private readonly List<string> books = new();

        public void Add(string title) => books.Add(title);

        public IEnumerator<string> GetEnumerator() => new BookIterator(books);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class BookIterator : IEnumerator<string>
        {
            private readonly List<string> books;
            private int position = -1;

            public BookIterator(List<string> books)
            {
                this.books = books;
            }

            public string Current => books[position];

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                position++;
                return position < books.Count;
            }

            public void Reset() => position = -1;

            public void Dispose() { }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var collection = new BookCollection();
            collection.Add("Design Patterns");
            collection.Add("Clean Code");
            collection.Add("The Pragmatic Programmer");

            foreach (string book in collection)
            {
                Console.WriteLine(book);
            }
        }
    }
}
