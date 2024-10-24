using DataAccessLayer.Models;

namespace DataAccessLayer.DTOs
{
	public class AnswerQuestionDto
	{
        public IEnumerable<Answer> answersQuestion { get; set; }
        public int questionId { get; set; }
    }
}
