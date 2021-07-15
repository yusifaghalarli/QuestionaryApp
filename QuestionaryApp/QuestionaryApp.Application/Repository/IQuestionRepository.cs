using QuestionaryApp.Core.Domain;
using QuestionaryApp.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestionaryApp.Application.Repository
{
    public interface IQuestionRepository:IRepository<Question>
    {
        Task<List<Question>> GetQuestionByIds(List<int> id);
      
    }
}
