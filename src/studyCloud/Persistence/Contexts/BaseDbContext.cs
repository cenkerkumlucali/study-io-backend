using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Categories;
using Domain.Entities.Comments;
using Domain.Entities.Common;
using Domain.Entities.Feeds;
using Domain.Entities.Quizzes;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using File = Domain.Entities.File;

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
        public DbSet<PostImageFile> PostImages { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Mention> Mentions { get; set; }
        public DbSet<UserCoin> UserCoins { get; set; }
        public DbSet<UserImageFile> UserImageFiles { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }


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
                a.HasOne(x => x.Following).WithMany().HasForeignKey(x => x.FollowingId).OnDelete(DeleteBehavior.Restrict);
                a.HasOne(x => x.Follower).WithMany().HasForeignKey(x => x.FollowerId).OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}