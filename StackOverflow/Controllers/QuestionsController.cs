using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackOverflow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StackOverflow.Controllers
{
    [Authorize]
    public class QuestionsController : Controller
    {
        private readonly IQuestionRepository _context;
        ApplicationDbContext db = new ApplicationDbContext();
        private readonly UserManager<ApplicationUser> _userManager;


        public QuestionsController(UserManager<ApplicationUser> userManager, IQuestionRepository thisRepo = null)
             {
                 if (thisRepo == null)
                 {
                     _context = new EFQuestionRepository();
                     _userManager = userManager;

             }
                 else
                 {
                     _context = thisRepo;
                     _userManager = userManager;

                 }
             }

             public IActionResult Index()
             {
                 var questionList = _context.Questions
                                            .Include(x => x.Answers)
                                            .Include(x => x.User)
                                            .Include(x => x.QuestionComments)
                                            .ToList();
                 return View(questionList);
             }

             public IActionResult Details(int questionId)
             {
                 var thisQuestion = _context.Questions
                                            .Include(x => x.Answers)
                                            .Include(x => x.User)
                                            .Include(x => x.QuestionComments)
                                            .FirstOrDefault(x => x.QuestionId == questionId);
                 return View(thisQuestion);

             }

             public IActionResult Create()
             {
                 ViewBag.Tags = db.Tags.ToList();
                 return View();
             }

            [HttpPost]
            public async Task<IActionResult> Create(Question question)
            {
                var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var currentUser = await _userManager.FindByIdAsync(userId);
                question.User = currentUser;
                db.Questions.Add(question);
                db.SaveChanges();


                return RedirectToAction("Index");
            }
       

            public IActionResult Edit(int questionId)
            {
                var thisQuestion = _context.Questions
                                           .Include(x => x.Answers)
                                           .Include(x => x.User)
                                           .Include(x => x.QuestionComments)
                                           .FirstOrDefault(x => x.QuestionId == questionId);
                ViewBag.Tags = db.Tags.ToList();
                return View(thisQuestion);
            }

            [HttpPost]
            public IActionResult Edit(Question question)
            {
                if (ModelState.IsValid)
                {
                    _context.Save(question);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }

            public IActionResult Delete(int questionId)
            {
                var thisQuestion = _context.Questions.FirstOrDefault(x => x.QuestionId == questionId);
                return View(thisQuestion);
            }

            [HttpPost, ActionName("Delete")]
            public IActionResult DeleteConfirmation(int questionId)
            {
                var thisQuestion = _context.Questions.FirstOrDefault(x => x.QuestionId == questionId);
                _context.Remove(thisQuestion);
                return RedirectToAction("Index");
            }

        }
}