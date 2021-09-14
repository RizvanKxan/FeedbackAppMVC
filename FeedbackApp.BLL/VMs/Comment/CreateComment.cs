using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FeedbackApp.BLL.VMs.Comment
{
    public class CreateComment
    {
        //public string AuthorName { get; set; }

        public Guid UserId { get; set; }

        [Required]
        public string Text { get; set; }
        public Guid FeedbackId { get; set; }
    }
}
