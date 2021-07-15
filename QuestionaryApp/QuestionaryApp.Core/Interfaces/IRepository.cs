using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestionaryApp.Core.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {

        Task<List<TEntity>> GetAllAsync();
        Task<bool> Commit();
        
    }
}
