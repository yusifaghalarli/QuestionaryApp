


using QuestionaryApp.Application.Models;
using System.Threading.Tasks;

namespace QuestionaryApp.Application.Services.Abstract
{
    public interface IAnswerService
    {
        Task<bool> AnswerQuestion(AnswerQuestionModel model);
    }
    
}
