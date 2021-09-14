using FeedbackApp.BLL.Interfaces;
using FeedbackApp.BLL.VMs.Comment;
using FeedbackApp.DAL.Patterns;
using FeedbackApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.BLL.Services
{
    public class CommentService : ICommentService
    {
        public CommentService(IUnitOfWork _db)
        {
            db = _db;
        }
        private readonly IUnitOfWork db;

        public async Task<Guid> CreateCommentAsync(CreateComment comment)
        {
            try
            {
                var dbComment = new Comment()
                {
                    UserId = comment.UserId,
                    CreationDate = DateTime.Now,
                    FeedbackId = comment.FeedbackId,
                    Text = comment.Text
                };
                dbComment = await db.Comments.CreateAsync(dbComment);
                return dbComment.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<InfoComment> FindCommentsByFunc(Func<Comment, bool> func)
        {
            try
            {
                var dbComments = db.Comments.GetAll().Where(func). 
                                                      Select(m =>
                                                      {
                                                          return new InfoComment()
                                                          {
                                                              CreationDate = m.CreationDate,
                                                              AuthorName = m.User.UserName,
                                                              ProductName = m.Feedback.Product.Name,
                                                              Text = m.Text,
                                                              FeedbackId = m.FeedbackId
                                                          };
                                                      }).ToList();
                return dbComments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
