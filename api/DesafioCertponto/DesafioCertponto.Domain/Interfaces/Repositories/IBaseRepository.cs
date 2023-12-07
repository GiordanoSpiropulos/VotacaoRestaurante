namespace DesafioCertponto.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        TEntity GetById(int id);

        IList<TEntity> GetAll();

        void Update(TEntity obj);

        void Remove(int id);

        void Dispose();
    }
}
