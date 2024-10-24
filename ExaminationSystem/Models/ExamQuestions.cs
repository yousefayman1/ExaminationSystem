using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.Models
{
	public class ExamQuestion
    {
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
		[ForeignKey("Question")]
		public int QuestionID { get; set; }
        public Question Question { get; set; }
    }
}
