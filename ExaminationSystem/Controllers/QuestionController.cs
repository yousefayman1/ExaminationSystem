using ExaminationSystem.Interfaces;
using ExaminationSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{

	public class QuestionController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public QuestionController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<IActionResult> Index()
		{
			var models = await _unitOfWork.questions.GetAll();
			return View(models);
		}
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Question model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await _unitOfWork.questions.Create(model);
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

		public async Task<IActionResult> Edit(int id)
		{
			var model = await _unitOfWork.questions.GetById(x => x.Id == id);
			if (model == null)
			{
				return NotFound();
			}
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Question model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await _unitOfWork.questions.Update(model);
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

		public async Task<IActionResult> Delete(int id)
		{
			var model = await _unitOfWork.questions.GetById(x => x.Id == id);
			if (model == null)
			{
				return NotFound();
			}
			return View(model);
		}

		// POST: QuestionController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(Question model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var answer = await _unitOfWork.answers.GetAll(x => x.QuestionId == model.Id);
					await _unitOfWork.questions.Delete(model);
					await _unitOfWork.complete();
					if (answer != null)
					{
						foreach (var item in answer)
						{
							await _unitOfWork.answers.Delete(item);
							await _unitOfWork.complete();
						}
					}

					return RedirectToAction(nameof(Index));
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
