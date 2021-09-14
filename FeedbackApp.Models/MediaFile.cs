using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackApp.Models
{
    public class MediaFile : BaseEntity
    {
       // public string Name { get; set; }
       // public string Type { get; set; }  //doc, pdf, mp3, gif, ...
        public string Path { get; set; }
        public Guid FeedbackId { get; set; }
        public virtual Feedback Feedback { get; set; }

    }
}
