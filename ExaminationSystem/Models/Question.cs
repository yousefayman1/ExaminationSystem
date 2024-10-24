using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Hosting;

namespace ExaminationSystem.Models
{
    public class Question
    {
        public int Id { get; set; }
        [ValidateNever]
        public string QuestionTitle { get; set; }
        public int Score { get; set; } = 5;
        [ValidateNever]
        public List<Exam> Exams { get; } = [];
        [ValidateNever]
        public List<Answer> Answers { get; } = [];
    }
}
