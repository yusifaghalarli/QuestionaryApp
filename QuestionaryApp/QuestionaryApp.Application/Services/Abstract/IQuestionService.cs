using QuestionaryApp.Application.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionaryApp.Application.Services.Abstract
{
    public interface IQuestionService
    {
        Task<List<QuestionDTO>> GetAllQuestions();
    }
}
