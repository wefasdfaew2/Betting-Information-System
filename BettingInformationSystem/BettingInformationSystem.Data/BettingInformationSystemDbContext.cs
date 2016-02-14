namespace BettingInformationSystem.Data
{
    using System.Data.Entity;

    using BettingInformationSystem.Data.Interfaces;
    using BettingInformationSystem.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class BettingInformationSystemDbContext : IdentityDbContext<ApplicationUser>, IBettingInformationSystemDbContext
    {
        public BettingInformationSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Post> Posts { get; set; }

        public static BettingInformationSystemDbContext Create()
        {
            return new BettingInformationSystemDbContext();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }

    // public class BettingInformationSystemDbContext : DbContext
    // {
    // // Your context has been configured to use a 'BettingInformationSystemDbContext' connection string from your application's 
    // // configuration file (App.config or Web.config). By default, this connection string targets the 
    // // 'BettingInformationSystem.Data.BettingInformationSystemDbContext' database on your LocalDb instance. 
    // // 
    // // If you wish to target a different database and/or database provider, modify the 'BettingInformationSystemDbContext' 
    // // connection string in the application configuration file.
    // public BettingInformationSystemDbContext()
    // : base("name=BettingInformationSystemDbContext")
    // {
    // }

    // // Add a DbSet for each entity type that you want to include in your model. For more information 
    // // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

    // // public virtual DbSet<MyEntity> MyEntities { get; set; }
    // }

    ////public class MyEntity
    ////{
    ////    public int Id { get; set; }
    ////    public string Name { get; set; }
    ////}
}