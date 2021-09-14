using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeedbackApp.BLL.Interfaces;
using FeedbackApp.BLL.VMs.Feedback;
using FeedbackApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackApp.PL.Controllers
{
    public class FeedbackController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(UserManager<User> userManager, IFeedbackService feedbackService)
        {
            _userManager = userManager;
            _feedbackService = feedbackService;
        }


        [HttpGet]
        [Authorize]
        [Route("feedback")]
        public ActionResult GetAllFeedbacks()
        {
            var feedbacks = _feedbackService.FindFeedbacksByFunc(null);
            return View(feedbacks);
        }

        [HttpGet]
        [Route("feedback_id/{id}")]
        [Authorize]
        public ActionResult GetFeedbackById(Guid id)
        {
            var feedback = _feedbackService.FindFeedbacksByFunc(f=>f.Id==id).SingleOrDefault();
            return View(feedback);
        }

        [HttpGet]
        [Route("feedback/create")]
        [Authorize]
        public ActionResult CreateFeedback()
        {
            return View(new CreateFeedback());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [Route("feedback")]
        public ActionResult CreateFeedback([FromForm]CreateFeedback f)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var currentUser = _userManager.GetUserAsync(User).Result;
                    f.UserId = new Guid(currentUser.Id);

                    var feedbackId = _feedbackService.CreateFeedbackAsync(f).Result;
                    return RedirectToAction(nameof(GetFeedbackById), feedbackId);
                }
                return View(f);
            }
            catch
            {
                return View();
            }
        }
    }
}
