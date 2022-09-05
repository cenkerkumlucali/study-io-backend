using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.Entities;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<SelectedAnswer> SelectedAnswers { get; set; }
        public DbSet<Answer> Answers { get; set; }


        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(a =>
            {
                a.ToTable("Categories").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
            });
            modelBuilder.Entity<SubCategory>(a =>
            {
                a.ToTable("SubCategories").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.CategoryId).HasColumnName("CategoryId");
                a.Property(p => p.Name).HasColumnName("Name");
            });
           
            
            modelBuilder.Entity<Answer>(a =>
            {
                a.ToTable("Answers").HasKey(k => k.Id);
                a.Property(p => p.QuestionId).HasColumnName("QuestionId");
                a.Property(p => p.Text).HasColumnName("Text");
                a.Property(p => p.IsCorrect).HasColumnName("IsCorrect");
            });

            modelBuilder.Entity<Question>(a =>
            {
                a.ToTable("Questions").HasKey(k => k.Id);
                a.Property(p => p.AnswerId).HasColumnName("AnswerId");
                a.Property(p => p.Text).HasColumnName("Text");
                a.Property(p => p.QuizId).HasColumnName("QuizId");
            }).Entity<Question>()
                .HasMany(c => c.Answers)
                .WithOne(e => e.Question)
                .HasForeignKey(c => c.QuestionId);;
            
            
            modelBuilder.Entity<SelectedAnswer>(a =>
            {
                a.ToTable("SelectedAnswers").HasKey(k => k.QuestionId);
                a.Property(p => p.PossibleAnswerId).HasColumnName("PossibleAnswerId");
            });
            
        }
    }
}