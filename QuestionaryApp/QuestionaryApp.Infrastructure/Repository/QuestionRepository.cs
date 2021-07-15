
using Microsoft.EntityFrameworkCore;
using QuestionaryApp.Application.Repository;
using QuestionaryApp.Core.Domain;
using QuestionaryApp.Infrastructure.Data.Context;
using QuestionaryApp.Infrastructure.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionaryApp.Infrastructure.Data.Query
{
    public class QuestionRepository:RepositoryBase<Question>, IQuestionRepository
    {
       

        public QuestionRepository(QuestionaryAppDbContext dbContext) : base(dbContext)
        {
           
        }

      
        public async Task<List<Question>> GetQuestionByIds(List<int> ids)
        {
            return await _dbContext.Questions.Include(x => x.Choices).Where(x=>ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<List<Question>> GetAllAsync()
        {
            return await _dbContext.Questions.Include(x => x.Choices).ToListAsync();
        }
    }
}
