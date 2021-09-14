using FeedbackApp.BLL.VMs.Comment;
using FeedbackApp.BLL.VMs.Feedback;
using FeedbackApp.BLL.VMs.Product;
using FeedbackApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeedbackApp.BLL.Interfaces
{
    public interface ICommentService
    {
        Task<Guid> CreateCommentAsync(CreateComment comment);  //вернем ID созданного 
        List<InfoComment> FindCommentsByFunc(Func<Comment, bool> func);
    }
}
