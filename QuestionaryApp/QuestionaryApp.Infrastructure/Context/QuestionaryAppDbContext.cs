

using Microsoft.EntityFrameworkCore;
using QuestionaryApp.Core.Domain;
using QuestionaryApp.Infrastructure.Data.Mappings;
using System.Collections.Generic;

namespace QuestionaryApp.Infrastructure.Data.Context
{
    public class QuestionaryAppDbContext : DbContext
    {

        public QuestionaryAppDbContext(DbContextOptions<QuestionaryAppDbContext> options) : base(options) { }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Answer> Answers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuestionMap).Assembly);


            var choicesOne = new List<Choice>()
            {
                new Choice(1,1,"6"),
                new Choice(2,1,"9"),
                new Choice(3,1,"12"),

                new Choice(4,2,"11"),
                new Choice(5,2,"15"),
                new Choice(6,2,"17"),

                new Choice(7,3,"8-20"),
                new Choice(8,3,"21-45"),
                new Choice(9,3,"45-70"),
                new Choice(10,3,"70+")

            };

            modelBuilder.Entity<Question>().HasData(new Question(1,"3+3?",true));
            modelBuilder.Entity<Question>().HasData(new Question(2,"7+4?",true ));
            modelBuilder.Entity<Question>().HasData(new Question(3,"How old are you?",true));

            foreach (var item in choicesOne)
            {
                modelBuilder.Entity<Choice>().HasData(item);
            }
        }

        public static QuestionaryAppDbContext GetInstanceForFactory(DbContextOptions<QuestionaryAppDbContext> options)
        {
            return new QuestionaryAppDbContext(options);
        }

    }

}
