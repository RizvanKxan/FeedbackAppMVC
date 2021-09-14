using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackApp.Models
{
    public class Comment : BaseEntity
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public string Text { get; set; }
        public DateTime CreationDate { get; set; }

        public Guid FeedbackId { get; set; }
        public virtual Feedback Feedback { get; set; }
    }
}
