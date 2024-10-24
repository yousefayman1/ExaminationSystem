using DataAccessLayer.Models;

namespace DataAccessLayer.DTOs
{
    public class QuestionExamDto
    {
        public int examId { get; set; }
        public int questionId {  get; set; }
        public string questionTitle { get; set; }
		public IEnumerable<Answer> answersQuestion { get; set; }
	}
}
