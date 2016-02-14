namespace BettingInformationSystem.Data.Interfaces
{
    using BettingInformationSystem.Models;

    public interface IBettingInformationSystemData
    {
        IGenericRepository<Comment> Comments { get; }

        IGenericRepository<Post> Posts { get; }

        IGenericRepository<ApplicationUser> Users { get; }

        void SaveChanges();

        void SaveChangesAsync();
    }
}