using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackApp.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public virtual List<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}
