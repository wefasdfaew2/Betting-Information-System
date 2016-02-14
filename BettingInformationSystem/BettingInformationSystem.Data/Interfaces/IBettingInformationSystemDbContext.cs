namespace BettingInformationSystem.Data.Interfaces
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Reflection.Emit;

    using BettingInformationSystem.Models;

    public interface IBettingInformationSystemDbContext
    {
        IDbSet<Comment> Comments { get; set; }

        IDbSet<Post> Posts { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}