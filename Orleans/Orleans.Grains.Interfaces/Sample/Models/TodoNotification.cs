using System;
using Orleans.Concurrency;

namespace Orleans.Grains.Sample.Models
{
    [Immutable]
    public class TodoNotification
    {
        public TodoNotification(Guid itemKey, TodoItem item)
        {
            ItemKey = itemKey;
            Item = item;
        }

        public Guid ItemKey { get; }
        public TodoItem Item { get; }
    }
}