using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackApp.Models
{

    public class User : IdentityUser
    {
        public int Age { get; set; }
    }
}
