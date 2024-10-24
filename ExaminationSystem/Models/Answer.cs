using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Build.Framework;

namespace ExaminationSystem.Models
{
	public class Answer
	{
		public int Id { get; set; }
		[ValidateNever]
		[Required]
		public string AnswerDescription { get; set; }
		public bool isTrue { get; set; } = false;
		public int QuestionId { get; set; }
		[ValidateNever]
		public Question Question { get; set; }


	}
}
