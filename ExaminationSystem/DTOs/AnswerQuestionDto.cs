using ExaminationSystem.Models;

namespace ExaminationSystem.DTOs
{
	public class AnswerQuestionDto
	{
        public IEnumerable<Answer> answersQuestion { get; set; }
        public int questionId { get; set; }
    }
}
