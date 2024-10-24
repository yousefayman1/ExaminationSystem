using ExaminationSystem.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExaminationSystem.ViewModel
{
	public class QuestionVm
	{
		public IEnumerable<SelectListItem> QuestionList { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> AnswerList { get; set; }
	}
}
