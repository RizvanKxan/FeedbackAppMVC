﻿using FeedbackApp.BLL.VMs.MediaFile;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FeedbackApp.BLL.VMs.Feedback
{
    public class CreateFeedback
    {
        //public string AuthorName { get; set; }

        public Guid UserId { get; set; }
        public string Text { get; set; }

        [Range(0,5)]
        public int Rate { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
       // public List<CreateMediaFile> MediaFiles { get; set; }
    }
}
