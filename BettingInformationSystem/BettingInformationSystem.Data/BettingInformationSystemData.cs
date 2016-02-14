namespace BettingInformationSystem.Data
{
    using System;
    using System.Collections.Generic;

    using BettingInformationSystem.Data.Interfaces;
    using BettingInformationSystem.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class BettingInformationSystemData : IBettingInformationSystemData
    {
        private BettingInformationSystemDbContext context;

        private IDictionary<Type, object> repositories;

        private IUserStore<ApplicationUser> userStore;

        public BettingInformationSystemData()
            : this(new BettingInformationSystemDbContext())
        {
        }

        public BettingInformationSystemData(BettingInformationSystemDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public IGenericRepository<Post> Posts
        {
            get
            {
                return this.GetRepository<Post>();
            }
        }

        public IGenericRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IUserStore<ApplicationUser> UserStore
        {
            get
            {
                if (this.userStore == null)
                {
                    this.userStore = new UserStore<ApplicationUser>(this.context);
                }

                return this.userStore;
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void SaveChangesAsync()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                // Ako imame custom repository

                // if (typeOfModel.IsAssignableFrom(typeof(Book))) 
                // {
                // type = typeof(BookRepository);
                // }
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}