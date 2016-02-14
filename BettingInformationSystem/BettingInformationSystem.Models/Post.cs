namespace BettingInformationSystem.Models
{
    using System;
    using System.Collections.Generic;

    public class Post
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();    
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } 
    }
}