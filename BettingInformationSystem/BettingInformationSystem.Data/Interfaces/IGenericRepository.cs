namespace BettingInformationSystem.Data.Interfaces
{
    using System.Linq;

    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> All();

        T Find(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Remove(object id);
    }
}