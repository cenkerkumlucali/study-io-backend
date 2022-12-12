using Application.Abstractions.Services.Paging;
using Application.Features.QuizHistory.Commands.CreateQuizHistory;
using Application.Features.QuizHistory.Commands.DeleteQuizHistory;
using Application.Features.QuizHistory.Commands.UpdateQuizHistory;
using Application.Features.QuizHistory.Models;
using Application.Features.QuizHistory.Queries.GetByIdQuizHistory;
using Application.Features.QuizHistory.Queries.GetListQuizHistory;
using AutoMapper;

namespace Application.Features.QuizHistory.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Quizzes.QuizHistory, CreateQuizHistoryCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.QuizHistory, CreateQuizHistoryCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.QuizHistory, DeleteQuizHistoryCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.QuizHistory, DeleteQuizHistoryCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.QuizHistory, UpdateQuizHistoryQueryResponse>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.QuizHistory, UpdateQuizHistoryCommandRequest>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Quizzes.QuizHistory>,QuizHistoryListModel>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.QuizHistory,ListQuizHistoryQueryResponse>().ReverseMap();

        CreateMap<Domain.Entities.Quizzes.QuizHistory, GetByIdQuizHistoryQueryResponse>().ReverseMap();
    }
}