using Microsoft.EntityFrameworkCore;
using Resume.Application.Common.Interfaces;
using Resume.Domain.Entity.Common;
using Resume.Domain.Entity.Reservation;
using Resume.Infra.Data.Context;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Infra.Data.Repository
{

    public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity : class, IEntity


    {

        protected readonly AppDbContext _dbContext ;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<TEntity> AddAsync(TEntity entity,CancellationToken cancellationToken)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
            return entity;
        }


        public void Delete(TEntity entity)
        {
             _dbContext.Set<TEntity>().Remove(entity);

        }


        public void  Update (TEntity entity)
        {
             _dbContext.Set<TEntity>().Update(entity);
        }

        public async Task<TEntity> Get(ulong id, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

 
    }
}
