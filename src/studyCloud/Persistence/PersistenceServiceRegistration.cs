using Application.Abstractions.Services;
using Application.Repositories.Services.Alarm;
using Application.Repositories.Services.Categories;
using Application.Repositories.Services.Comments;
using Application.Repositories.Services.Feeds;
using Application.Repositories.Services.Files;
using Application.Repositories.Services.Follows;
using Application.Repositories.Services.Mentions;
using Application.Repositories.Services.OperationClaim;
using Application.Repositories.Services.Quizzes;
using Application.Repositories.Services.RefreshToken;
using Application.Repositories.Services.UserOperationClaim;
using Application.Repositories.Services.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using Persistence.Repositories.Alarm;
using Persistence.Repositories.Categories;
using Persistence.Repositories.Comments;
using Persistence.Repositories.Feeds;
using Persistence.Repositories.Files;
using Persistence.Repositories.Follows;
using Persistence.Repositories.Mentions;
using Persistence.Repositories.OperationClaim;
using Persistence.Repositories.Quizzes;
using Persistence.Repositories.RefreshToken;
using Persistence.Repositories.UserOperationClaim;
using Persistence.Repositories.Users;
using Persistence.Services;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<BaseDbContext>(options =>
                options.UseNpgsql(Configuration.ConnectionString));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommentImageFileRepository, CommentImageRepository>();
            services.AddScoped<ICommentLikeRepository, CommentLikeRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostLikeRepository, PostLikeRepository>();
            services.AddScoped<IPostImageFileRepository, PostImageFileRepository>();
            services.AddScoped<IFollowRepository, FollowRepository>();
            services.AddScoped<IMentionRepository, MentionRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuizHistoryRepository, QuizHistoryRepository>();
            services.AddScoped<IQuizRepository, QuizRepository>();
            services.AddScoped<ISelectedAnswerRepository, SelectedAnswerRepository>();
            services.AddScoped<IUserCoinRepository, UserCoinRepository>();
            services.AddScoped<IUserImageRepository, UserImageRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IBlockRepository, BlockRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
            services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
            services.AddScoped<IAlarmRepository, AlarmRepository>();
            services.AddScoped<IResetPasswordAuthenticationRepository, ResetPasswordAuthenticationRepository>();
            

            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentImageFileService, CommentImageFileManager>();
            services.AddScoped<IPostImageFileService, PostImageFileManager>();
            services.AddScoped<IUserImageService, UserImageManager>();
            services.AddScoped<IBlockService, BlockManager>();
            services.AddScoped<IFollowService, FollowManager>();
            services.AddScoped<IPostService, PostManager>();
            services.AddScoped<IMentionService, MentionManager>();
            services.AddScoped<IAlarmService, AlarmManager>();
            services.AddScoped<IPostLikeService, PostLikeManager>();


            return services;
        }
    }
}