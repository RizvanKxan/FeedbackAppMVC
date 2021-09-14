using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackApp.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
