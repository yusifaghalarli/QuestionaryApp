using Microsoft.EntityFrameworkCore;
using QuestionaryApp.Core;
using QuestionaryApp.Core.Interfaces;
using QuestionaryApp.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionaryApp.Infrastructure.Data.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity :Entity
    {
        protected readonly QuestionaryAppDbContext _dbContext;

        public RepositoryBase(QuestionaryAppDbContext context)
        {
            this._dbContext = context;
        }

        public async Task<bool> Commit()
        {
            return  await _dbContext.SaveChangesAsync()>0;  
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public  virtual Task<List<TEntity>> GetAllAsync()
        {
            return _dbContext.Set<TEntity>().ToListAsync();
        }
    }
}
