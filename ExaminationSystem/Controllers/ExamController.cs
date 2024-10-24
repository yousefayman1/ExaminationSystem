using BusinessLogicLayer;
using DataAccessLayer.DTOs;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Controllers
{
	public class ExamController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ApplicationDbContext _context;

		public ExamController(IUnitOfWork unitOfWork, ApplicationDbContext context)
		{
			_unitOfWork = unitOfWork;
			_context = context;
		}
		public async Task<IActionResult> Index()
		{
			var models = await _unitOfWork.exams.GetAll();
			if (models == null)
			{
				return NotFound();
			}
			return View(models);
		}
		public async Task<IActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Exam model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					Random rand = new Random();
					int skipper = rand.Next(0, _context.Questions.Count() - 10);
					List<Question> models = await _context.Questions.OrderBy(product => Guid.NewGuid()).Skip(skipper)
					.Take(10).ToListAsync();
					model.Questions = models;
					await _unitOfWork.exams.Create(model);
					await _unitOfWork.complete();
					return RedirectToAction("TakingExam", new { id = model.Id }); ;
				}
				return View(model);
			}
			catch
			{
				return View();
			}
		}
		[HttpGet]
		public async Task<IActionResult> TakingExam(int id)
		{
			var examModel = await _context.Exams.Where(c => c.Id == id).Include(x => x.Questions).SingleOrDefaultAsync();
			List<Question> questions = examModel.Questions;
			List<QuestionExamDto> questionExamDtos = new List<QuestionExamDto>();
			foreach (var question in examModel.Questions)
			{
				questionExamDtos.Add(new QuestionExamDto
				{
					examId = id,
					questionId = question.Id,
					questionTitle = question.QuestionTitle,
					answersQuestion = await _unitOfWork.answers.GetAll(x => x.QuestionId == question.Id)

				});
			}
			return View(questionExamDtos);
		}
		[HttpPost]

		public async Task<IActionResult> TakingExam(int examId, string selectedAnswers)
		{
			int total = 0;
			foreach (var item in selectedAnswers.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				var answer = await _unitOfWork.answers.GetById(x => x.Id == int.Parse(item));
				if (answer.isTrue)
				{
					var question = await _unitOfWork.questions.GetById(x => x.Id == answer.QuestionId);
					total += question.Score;
				}
			}
			var exam = await _unitOfWork.exams.GetById(x => x.Id == examId);
			exam.Grade = total;
			await _unitOfWork.exams.Update(exam);
			await _unitOfWork.complete();
			return RedirectToAction("Index");
		}
	}
}
