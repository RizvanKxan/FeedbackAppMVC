using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeedbackApp.BLL.Interfaces;
using FeedbackApp.BLL.VMs.Comment;
using FeedbackApp.BLL.VMs.Feedback;
using FeedbackApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackApp.PL.Controllers
{
    [Route("comment")]
    public class CommentController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly ICommentService _commentService;

        public CommentController(UserManager<User> userManager, ICommentService commentService)
        {
            _userManager = userManager;
            _commentService = commentService;
        }

        [HttpGet]
        [Route("comment/{id}")]
        public ActionResult GetCommentListByFeedbackId(Guid id)
        {
            var comments = _commentService.FindCommentsByFunc(c => c.FeedbackId == id);
            return View(comments.OrderBy(m=>m.CreationDate).Take(4));
        }

        [HttpGet]
        [Route("comment/create/{id}")]
        public ActionResult CreateComment(Guid id)
        {
            return View(new CreateComment() { FeedbackId=id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment(CreateComment c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var currentUser = _userManager.GetUserAsync(User).Result;
                    c.UserId = new Guid(currentUser.Id);

                    _commentService.CreateCommentAsync(c);

                    return RedirectToAction("GetFeedbackById", "FeedbackController", c.FeedbackId);
                }
                return View(c);
            }
            catch
            {
                return View();
            }
        }
    }
}
