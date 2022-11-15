using Microsoft.EntityFrameworkCore;
using Domain.Entities.Categories;
using Domain.Entities.Comments;
using Domain.Entities.Common;
using Domain.Entities.Feeds;
using Domain.Entities.Follow;
using Domain.Entities.Mentions;
using Domain.Entities.Quizzes;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {


        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizHistory> QuizHistories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<SelectedAnswer> SelectedAnswers { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<CommentImageFile> CommentImages { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Mention> Mentions { get; set; }
        public DbSet<UserCoin> UserCoins { get; set; }
        public DbSet<UserImageFile> UserImageFiles { get; set; }
        public DbSet<Domain.Entities.File.File> Files { get; set; }


        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            IEnumerable<EntityEntry<BaseEntity>> datas = ChangeTracker
                .Entries<BaseEntity>().Where(e =>
                    e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var data in datas)
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                };

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Follow>(a =>
            {
                a.ToTable("Follows").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.FollowingId).HasColumnName("FollowingId");
                a.Property(p => p.FollowerId).HasColumnName("FollowerId");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.HasOne(x => x.Following).WithMany().HasForeignKey(x => x.FollowingId)
                    .OnDelete(DeleteBehavior.Restrict);
                a.HasOne(x => x.Follewer).WithMany().HasForeignKey(x => x.FollowerId).OnDelete(DeleteBehavior.Restrict);
            });
            // modelBuilder.Entity<Category>(a =>
            // {
            //     a.ToTable("Categories").HasKey(k => k.Id);
            //     a.Property(p => p.Id).HasColumnName("Id");
            //     a.Property(p => p.Name).HasColumnName("Name");
            //     a.HasMany(c => c.SubCategories)
            //         .WithOne(e => e.Category)
            //         .HasForeignKey(c => c.CategoryId).IsRequired();
            // });
            //
            // modelBuilder.Entity<SubCategory>(a =>
            // {
            //     a.ToTable("SubCategories").HasKey(k => k.Id);
            //     a.Property(p => p.Id).HasColumnName("Id");
            //     a.Property(p => p.CategoryId).HasColumnName("CategoryId");
            //     a.Property(p => p.Name).HasColumnName("Name");
            //     a.HasOne(p => p.Category).WithMany().HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Cascade);
            // });
            //
            // modelBuilder.Entity<Quiz>(a =>
            // {
            //     a.ToTable("Quizzes").HasKey(k => k.Id);
            //     a.Property(p => p.Id).HasColumnName("Id");
            //     a.Property(p => p.CategoryId).HasColumnName("CategoryId");
            //     a.Property(p => p.SubCategoryId).HasColumnName("SubCategoryId");
            //     a.HasOne(p => p.Category).WithMany().HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Cascade);
            //     a.HasOne(p => p.SubCategory).WithMany().HasForeignKey(p => p.SubCategoryId).OnDelete(DeleteBehavior.Restrict);
            // });
            //
            // modelBuilder.Entity<QuizHistory>(a =>
            // {
            //     a.ToTable("QuizHistories").HasKey(k => k.Id);
            //     a.Property(p => p.Id).HasColumnName("Id");
            //     a.Property(p => p.UserId).HasColumnName("UserId");
            //     a.Property(p => p.QuizId).HasColumnName("QuizId");
            //     a.Property(p => p.QuizDate).HasColumnName("QuizDate");
            //     a.HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
            //     a.HasOne(p => p.Quiz).WithMany().HasForeignKey(p => p.QuizId).OnDelete(DeleteBehavior.Cascade);
            // });
            //
            // modelBuilder.Entity<Answer>(a =>
            // {
            //     a.ToTable("Answers").HasKey(k => k.Id);
            //     a.Property(p => p.QuestionId).HasColumnName("QuestionId");
            //     a.Property(p => p.Text).HasColumnName("Text");
            //     a.Property(p => p.IsCorrect).HasColumnName("IsCorrect");
            //     a.HasOne(p => p.Question).WithMany().HasForeignKey(p => p.QuestionId).OnDelete(DeleteBehavior.Cascade);
            // });
            //
            // modelBuilder.Entity<Question>(a =>
            // {
            //     a.ToTable("Questions").HasKey(k => k.Id);
            //     a.Property(p => p.Text).HasColumnName("Text");
            //     a.Property(p => p.QuizId).HasColumnName("QuizId");
            //     a.Property(p => p.Difficulty).HasColumnName("Difficulty");
            //     a.HasMany(c => c.Answers)
            //         .WithOne(e => e.Question)
            //         .HasForeignKey(c => c.QuestionId);
            //     a.HasOne(p => p.Quiz).WithMany().HasForeignKey(p => p.QuizId).OnDelete(DeleteBehavior.Cascade);
            // });
            //
            //
            // modelBuilder.Entity<SelectedAnswer>(a =>
            // {
            //     a.ToTable("SelectedAnswers").HasKey(k => k.Id);
            //     a.Property(p => p.QuestionId).HasColumnName("QuestionId");
            //     a.Property(p => p.PossibleAnswerId).HasColumnName("PossibleAnswerId");
            //     a.Property(p => p.UserId).HasColumnName("UserId");
            //     a.Property(p => p.QuizHistoryId).HasColumnName("QuizHistoryId");
            //     a.HasOne(p => p.QuizHistory).WithMany().HasForeignKey(p => p.QuizHistoryId).OnDelete(DeleteBehavior.Restrict);
            //     a.HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
            //     a.HasOne(p => p.Question).WithMany().HasForeignKey(p => p.QuestionId).OnDelete(DeleteBehavior.Restrict);
            //     a.HasOne(p => p.Answer).WithMany().HasForeignKey(p => p.PossibleAnswerId)
            //         .OnDelete(DeleteBehavior.Cascade);
            //     a.HasOne(p => p.QuizHistory).WithMany().HasForeignKey(p => p.QuizHistoryId)
            //         .OnDelete(DeleteBehavior.Restrict);
            //
            // });
            //
            //
            // modelBuilder.Entity<Comment>(a =>
            // {
            //     a.ToTable("Comments").HasKey(k => k.Id);
            //     a.Property(p => p.UserId).HasColumnName("UserId");
            //     a.Property(p => p.ParentId).HasColumnName("ParentId").IsRequired(false);
            //     a.Property(p => p.Content).HasColumnName("Content");
            //     a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
            //     a.HasMany(p => p.CommentLikes);
            //     a.HasMany(m => m.Childrens)
            //         .WithOne(m => m.Parent).OnDelete(DeleteBehavior.SetNull)
            //         .HasForeignKey(m => m.ParentId);
            //     a.HasOne(p => p.Parent).WithMany().HasForeignKey(p=>p.ParentId).OnDelete(DeleteBehavior.Restrict);
            //     a.HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
            // });
            //
            // modelBuilder.Entity<CommentImageFile>(a =>
            // {
            //     a.ToTable("CommentImages").HasKey(k => k.Id);
            //     a.Property(p => p.Id).HasColumnName("Id");
            //     a.Property(p => p.CommentId).HasColumnName("CommentId");
            //     a.Property(p => p.ImagePath).HasColumnName("ImagePath");
            //     a.HasOne(p => p.Comment).WithMany().HasForeignKey(p=>p.CommentId);
            // });
            //
            // modelBuilder.Entity<CommentLike>(a =>
            // {
            //     a.ToTable("CommentLikes").HasKey(k => k.Id);
            //     a.Property(p => p.Id).HasColumnName("Id");
            //     a.Property(p => p.CommentId).HasColumnName("CommentId");
            //     a.Property(p => p.UserId).HasColumnName("UserId");
            //     a.HasOne(p => p.Comment);
            //     a.HasOne(p => p.User).WithMany().HasForeignKey(p=>p.UserId).OnDelete(DeleteBehavior.Restrict);
            //     a.HasOne(p => p.Comment).WithMany().HasForeignKey(p => p.CommentId);
            // });
            // modelBuilder.Entity<PostLike>(a =>
            // {
            //     a.ToTable("PostLikes").HasKey(k => k.Id);
            //     a.Property(p => p.Id).HasColumnName("Id");
            //     a.Property(p => p.PostId).HasColumnName("PostId");
            //     a.Property(p => p.UserId).HasColumnName("UserId");
            //     a.HasOne(p => p.Post).WithMany().HasForeignKey(p=>p.PostId);
            //     a.HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
            //     ;
            // });
            // modelBuilder.Entity<Post>(a =>
            // {
            //     a.ToTable("Posts").HasKey(k => k.Id);
            //     a.Property(p => p.Id).HasColumnName("Id");
            //     a.Property(p => p.UserId).HasColumnName("UserId");
            //     a.Property(p => p.Content).HasColumnName("Content");
            //     a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
            //     a.HasOne(p => p.User).WithMany().OnDelete(DeleteBehavior.Restrict);
            //     
            //     a.HasMany(p => p.PostLikes);
            //     a.HasMany(p => p.Comments);
            // });
            //
            // modelBuilder.Entity<PostImage>(a =>
            // {
            //     a.ToTable("PostImages").HasKey(k => k.Id);
            //     a.Property(p => p.Id).HasColumnName("Id");
            //     a.Property(p => p.PostId).HasColumnName("PostId");
            //     a.Property(p => p.ImagePath).HasColumnName("ImagePath");
            //     a.HasOne(p => p.Post).WithMany().OnDelete(DeleteBehavior.Restrict);
            // });
            //
            // modelBuilder.Entity<Follow>(a =>
            // {
            //     a.ToTable("Follows").HasKey(k => k.Id);
            //     a.Property(p => p.Id).HasColumnName("Id");
            //     a.Property(p => p.FollowingId).HasColumnName("FollowingId");
            //     a.Property(p => p.FollowerId).HasColumnName("FollowerId");
            //     a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
            //     a.HasOne(x => x.Following).WithMany().HasForeignKey(x => x.FollowingId)
            //         .OnDelete(DeleteBehavior.Restrict);
            //     a.HasOne(x => x.Follewer).WithMany().HasForeignKey(x => x.FollowerId).OnDelete(DeleteBehavior.Restrict);
            // });
            //
            // modelBuilder.Entity<Mention>(a =>
            // {
            //     a.ToTable("Mentions").HasKey(k => k.Id);
            //     a.Property(p => p.Id).HasColumnName("Id");
            //     a.Property(p => p.PostId).HasColumnName("PostId");
            //     a.Property(p => p.CommentId).HasColumnName("CommentId");
            //     a.Property(p => p.AgentId).HasColumnName("AgentId");
            //     a.Property(p => p.TargetId).HasColumnName("TargetId");
            //     a.Property(p => p.MentionType).HasColumnName("MentionType");
            //     a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
            //     a.HasOne(p => p.Post);
            //     a.HasOne(x => x.Agent).WithMany().HasForeignKey(x => x.AgentId).OnDelete(DeleteBehavior.Restrict);
            //     a.HasOne(x => x.Target).WithMany().HasForeignKey(x => x.TargetId).OnDelete(DeleteBehavior.Restrict);
            //     a.HasOne(p => p.Comment);
            // });
            //
            // modelBuilder.Entity<UserCoin>(a =>
            // {
            //     a.ToTable("UserCoins").HasKey(k => k.Id);
            //     a.Property(p => p.Id).HasColumnName("Id");
            //     a.Property(p => p.UserId).HasColumnName("UserId");
            //     a.Property(p => p.Coin).HasColumnName("Coin");
            //     a.HasOne(p => p.User).WithMany().OnDelete(DeleteBehavior.Restrict);
            // });
            //
            // modelBuilder.Entity<UserImage>(a =>
            // {
            //     a.ToTable("UserImages").HasKey(k => k.Id);
            //     a.Property(p => p.Id).HasColumnName("Id");
            //     a.Property(p => p.UserId).HasColumnName("UserId");
            //     a.Property(p => p.ImagePath).HasColumnName("ImagePath");
            //     a.HasOne(p => p.User).WithMany().OnDelete(DeleteBehavior.Restrict);
            // });


        }
    }
}