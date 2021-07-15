using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuestionaryApp.Application.Models
{
    public class AnswerQuestionModel
    {
        public List<SeletedAnswersModel> Answers { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
