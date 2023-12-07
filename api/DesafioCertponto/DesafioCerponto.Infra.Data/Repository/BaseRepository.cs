using DesafioCerponto.Infra.Data.Context;
using DesafioCertponto.Domain.Interfaces.Repositories;

namespace DesafioCerponto.Infra.Data.Repository
{
    public abstract class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly MySqlContext _mySqlContext;

        public BaseRepository(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }

        public virtual void Add(TEntity obj)
        {
            _mySqlContext.Set<TEntity>().Add(obj);
            _mySqlContext.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            _mySqlContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _mySqlContext.SaveChanges();
        }

        public virtual void Remove(int id)
        {
            _mySqlContext.Set<TEntity>().Remove(GetById(id));
            _mySqlContext.SaveChanges();
        }

        public virtual IList<TEntity> GetAll()
        {
            return _mySqlContext.Set<TEntity>().ToList();
        }


        public virtual TEntity GetById(int id)
        {
            return _mySqlContext.Set<TEntity>().Find(id);
        }
        public virtual void Dispose()
        {
            _mySqlContext.Dispose();
        }

    }
}