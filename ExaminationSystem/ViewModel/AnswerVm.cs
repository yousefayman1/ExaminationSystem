using ExaminationSystem.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExaminationSystem.ViewModel
{
	public class AnswerVm
	{
		public Answer Answer { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> QuestionList { get; set; }
	}
}
