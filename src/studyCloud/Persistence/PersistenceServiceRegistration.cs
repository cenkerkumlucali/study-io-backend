using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Application.Services.Repositories.Categories;
using Application.Services.Repositories.Comments;
using Application.Services.Repositories.Feeds;
using Application.Services.Repositories.Files;
using Application.Services.Repositories.Follows;
using Application.Services.Repositories.Mentions;
using Application.Services.Repositories.Quizzes;
using Application.Services.Repositories.Users;
using Persistence.Repositories.Categories;
using Persistence.Repositories.Comments;
using Persistence.Repositories.Feeds;
using Persistence.Repositories.Files;
using Persistence.Repositories.Follows;
using Persistence.Repositories.Mentions;
using Persistence.Repositories.Quizzes;
using Persistence.Repositories.Users;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<BaseDbContext>(options =>
                options.UseNpgsql(Configuration.ConnectionString));

            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<ISubCategoryRepository,SubCategoryRepository>();
            services.AddScoped<ICommentRepository,CommentRepository>();
            services.AddScoped<ICommentImageRepository,CommentImageRepository>();
            services.AddScoped<ICommentLikeRepository,CommentLikeRepository>();
            services.AddScoped<IPostRepository,PostRepository>();
            services.AddScoped<IPostLikeRepository,PostLikeRepository>();
            services.AddScoped<IPostImageRepository,PostImageRepository>();
            services.AddScoped<IFollowRepository,FollowRepository>();
            services.AddScoped<IMentionRepository,MentionRepository>();
            services.AddScoped<IAnswerRepository,AnswerRepository>();
            services.AddScoped<IQuestionRepository,QuestionRepository>();
            services.AddScoped<IQuizHistoryRepository,QuizHistoryRepository>();
            services.AddScoped<IQuizRepository,QuizRepository>();
            services.AddScoped<ISelectedAnswerRepository,SelectedAnswerRepository>();
            services.AddScoped<IUserCoinRepository,UserCoinRepository>();
            services.AddScoped<IUserImageRepository,UserImageRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IFileRepository,FileRepository>();
           

            return services;
        }
    }
}