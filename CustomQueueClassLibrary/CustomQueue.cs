using System;
using System.Collections.Generic;

namespace WarehouseManagementSystemAPI
{
    public delegate void QueueChangedEventHandler<T, U>(T sender, U eventArgs);

    public class CustomQueue<T> where T : IEntityPrimaryProperties, IEntityAdditionalProperties
    {
        private Queue<T> _queue = null;

        public event QueueChangedEventHandler<CustomQueue<T>, QueueEventArgs> CustomQueueEvent;

        public CustomQueue()
        {
            _queue = new Queue<T>();
        }

        public int QueueLength
        {
            get
            {
                return _queue.Count;
            }
        }

        public void AddItem(T item)
        {
            _queue.Enqueue(item);

            QueueEventArgs args = new QueueEventArgs
            { Message = $"DateTime: {DateTime.Now.ToString(Constants.DateTimeFormat)}, Id: {item.Id}, Name: {item.Name}, Type: {item.Type}, Quantity: {item.Quantity}, has been added to the queue" };

            OnQueueChanged(args);
        }

        public T GetItem()
        {
            T item = _queue.Dequeue();

            QueueEventArgs args = new QueueEventArgs
            { Message = $"DateTime: {DateTime.Now.ToString(Constants.DateTimeFormat)}, Id: {item.Id}, Name: {item.Name}, Type: {item.Type}, Quantity: {item.Quantity}, has been processed" };

            OnQueueChanged(args);

            return item;
        }

        protected virtual void OnQueueChanged(QueueEventArgs e)
        {
            CustomQueueEvent(this, e);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _queue.GetEnumerator();
        }
    }

    public class QueueEventArgs : EventArgs
    {
        public string Message { get; set; } = string.Empty;
    }
}