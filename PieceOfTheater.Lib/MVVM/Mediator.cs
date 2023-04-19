using System;

namespace PieceOfTheater.Lib.MVVM
{
    public interface IMediator
    {
        void Publish(string messageType);
        void Subscribe(string messageName, Action action);
        void Publish<T>(string messageType, T data);
        void Subscribe<T>(string messageName, Action<T> action);
    }

    public class Mediator : IMediator
    {
        private class MessageEventArgs : EventArgs
        {
            public string MessageType { get; set; }
            public object MessageData { get; set; }
        }

        event EventHandler<MessageEventArgs> _messageSubscriber;

        public void Publish<T>(string messageType, T data)
        {
            _messageSubscriber?.Invoke(this, new MessageEventArgs { MessageType = messageType, MessageData = data });
        }

        public void Subscribe<T>(string messageName, Action<T> action)
        {

            _messageSubscriber += (s, e) =>
            {
                if (e.MessageType == messageName && e.MessageData is T)
                {
                    action((T)e.MessageData);
                }
            };
        }

        public void Publish(string messageType)
        {
            _messageSubscriber?.Invoke(this, new MessageEventArgs { MessageType = messageType, MessageData = null });
        }

        public void Subscribe(string messageName, Action action)
        {

            _messageSubscriber += (s, e) =>
            {
                if (e.MessageType == messageName && e.MessageData == null)
                {
                    action();
                }
            };
        }

    }
}
