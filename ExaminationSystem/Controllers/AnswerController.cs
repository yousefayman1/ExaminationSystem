using ExaminationSystem.DTOs;
using ExaminationSystem.Interfaces;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModel;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Controllers
{
    //[Area("Admin")]
    public class AnswerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;

        public AnswerController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }
        public async Task<IActionResult> Index(int id)
        {
            var models = await _unitOfWork.answers.GetAll(x => x.QuestionId == id, "Question");
            if (models == null)
            {
                return NotFound();
            }
            var dto = new AnswerQuestionDto
            {
                answersQuestion = models,
                questionId = id

            };
            return View(dto);
        }
        [HttpGet]
        // GET: QuestionController/Create
        public async Task<IActionResult> Create(int id)
        {
            var answers = await _unitOfWork.answers.GetAll(x => x.QuestionId == id);

            var dto = new AnswerDto
            {
                answers = answers,
                questionId = id,
            };

            return View(dto);
        }

        // POST: QuestionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AnswerDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var answers = await _unitOfWork.answers.GetAll(x => x.QuestionId == dto.questionId);
                    var answerModel = new Answer
                    {
                        AnswerDescription = dto.answer,
                        isTrue = dto.isTrue,
                        QuestionId = dto.questionId
                    };
                    await _unitOfWork.answers.Create(answerModel);
                    await _unitOfWork.complete();
                    return RedirectToAction("Index", new { id = dto.questionId });
                }
                return View(dto);
            }
            catch
            {
                return View();
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _unitOfWork.answers.GetById(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Answer model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _unitOfWork.answers.Update(model);
                    await _unitOfWork.complete();
                    return RedirectToAction(nameof(Index));
                }

                return View(model);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _unitOfWork.answers.GetById(x => x.Id == id,"Question");
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Answer model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var questionId = model.QuestionId;
                    await _unitOfWork.answers.Delete(model);
                    await _unitOfWork.complete();
                    return RedirectToAction(nameof(Index), new { id = questionId });
                }

                return View(model);
            }
            catch
            {
                return View();
            }
        }
    }
}
