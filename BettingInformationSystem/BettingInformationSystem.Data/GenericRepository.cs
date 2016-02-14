namespace BettingInformationSystem.Data
{
    using System.Data.Entity;
    using System.Linq;

    using BettingInformationSystem.Data.Interfaces;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private IBettingInformationSystemDbContext context;
        private IDbSet<T> set;

        public GenericRepository(IBettingInformationSystemDbContext context)
        {
            this.context = context;
            this.set = this.context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set.AsQueryable();
        }

        public T Find(object id)
        {
            return this.set.Find(id);
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public void Remove(object id)
        {
            var entity = this.Find(id);
            this.Delete(entity);
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}