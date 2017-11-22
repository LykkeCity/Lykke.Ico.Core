using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Ico.Core.Queues
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class QueueMessageAttribute : Attribute
    {
        public string QueueName { get; set; }
    }
}
