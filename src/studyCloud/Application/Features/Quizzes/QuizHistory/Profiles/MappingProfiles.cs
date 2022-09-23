using Application.Features.Quizzes.QuizHistory.Commands.CreateQuizHistory;
using Application.Features.Quizzes.QuizHistory.Commands.DeleteQuizHistory;
using Application.Features.Quizzes.QuizHistory.Commands.UpdateQuizHistory;
using Application.Features.Quizzes.QuizHistory.Dtos;
using Application.Features.Quizzes.QuizHistory.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.Quizzes.QuizHistory.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Quizzes.QuizHistory, CreatedQuizHistoryDto>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.QuizHistory, CreateQuizHistoryCommand>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.QuizHistory, DeletedQuizHistoryDto>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.QuizHistory, DeleteQuizHistoryCommand>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.QuizHistory, UpdatedQuizHistoryDto>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.QuizHistory, UpdateQuizHistoryCommand>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Quizzes.QuizHistory>,QuizHistoryListModel>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.QuizHistory,ListQuizHistoryDto>().ReverseMap();

        CreateMap<Domain.Entities.Quizzes.QuizHistory, GetByIdQuizHistoryDto>().ReverseMap();
    }
}