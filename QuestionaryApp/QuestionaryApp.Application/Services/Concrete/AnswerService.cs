using QuestionaryApp.Application.Models;
using QuestionaryApp.Application.Repository;
using QuestionaryApp.Application.Services.Abstract;
using QuestionaryApp.Core.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionaryApp.Application.Services.Concrete
{
    public class AnswerService:IAnswerService
    {
        private readonly IQuestionRepository _questionRepository;

        public AnswerService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }


        public async Task<bool> AnswerQuestion(AnswerQuestionModel model)
        {
            var questions=await _questionRepository.GetQuestionByIds(model.Answers.Select(x=>x.QuestionId).ToList());
            foreach (var question in questions)
            {
                var choiceIds = model.Answers.FirstOrDefault(x => x.QuestionId == question.Id).SelectedChoiceIds;
                question.Answer(new Answer(question.Id, choiceIds, model.UserName));
              
            }

           return await _questionRepository.Commit();
          
            
        }
    }
}
