using System;

namespace DependencyInjectionPattern
{
    public interface IMessage
    {
        void SendMessage(string message);
    }

    public class Email : IMessage
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("Email message: " + message);
        }
    }

    public class SMS : IMessage
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("SMS message: " + message);
        }
    }

    public class Notification
    {
        private IMessage _message;

        public Notification(IMessage message)
        {
            this._message = message;
        }

        public void Notify(string message)
        {
            _message.SendMessage(message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IMessage email = new Email();
            Notification emailNotification = new Notification(email);
            emailNotification.Notify("This is an email notification");

            IMessage sms = new SMS();
            Notification smsNotification = new Notification(sms);
            smsNotification.Notify("This is an SMS notification");
        }
    }
}
