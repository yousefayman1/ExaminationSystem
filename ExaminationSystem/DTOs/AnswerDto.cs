using ExaminationSystem.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ExaminationSystem.DTOs
{
	public class AnswerDto
	{
		[ValidateNever]
		public IEnumerable<Answer> answers { get; set; }
		public int questionId { get; set; }
		public string? answer { get; set; }
		public bool isTrue { get; set; }
	}
}
