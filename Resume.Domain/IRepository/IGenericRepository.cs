using Resume.Domain.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Common.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);

        void Delete(TEntity entity);

        void Update(TEntity entity);

        Task<TEntity> Get(ulong id, CancellationToken cancellationToken);

    }


}
