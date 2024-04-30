using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    public interface IObserver
    {
        void Update(int i);
    }

    public interface ISubject
    {
        void Register(IObserver o);
        void Unregister(IObserver o);
        void NotifyRegisteredUsers(int i);
    }

    public class Subject : ISubject
    {
        List<IObserver> UserList = new List<IObserver>();

        public void NotifyRegisteredUsers(int i)
        {
            foreach (var observer in UserList)
            {
                observer.Update(i);
            }
        }

        public void Register(IObserver o)
        {
            UserList.Add(o);
        }

        public void Unregister(IObserver o)
        {
            UserList.Remove(o);
        }
    }

    public class Observer : IObserver
    {
        public void Update(int i)
        {
            Console.WriteLine("Flag value changed to :" + i);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject();
            Observer observer = new Observer();

            subject.Register(observer);
            subject.NotifyRegisteredUsers(5);

            subject.Unregister(observer);
            subject.NotifyRegisteredUsers(10);
        }
    }
}
