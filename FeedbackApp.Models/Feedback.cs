using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackApp.Models
{
    public class Feedback : BaseEntity
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public DateTime CreationDate { get; set; }
        public string Text { get; set; }
        public int Rate { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public virtual List<Comment> Comments { get; set; } = new List<Comment>();
        public virtual List<MediaFile> MediaFiles { get; set; } = new List<MediaFile>();
    }
}
