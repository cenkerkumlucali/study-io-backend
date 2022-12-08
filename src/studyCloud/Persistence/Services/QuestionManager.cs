using Application.Abstractions.Services;
using Application.Repositories.Services.Quizzes;
using Domain.Entities.Quizzes;
using Microsoft.AspNetCore.Http;

namespace Persistence.Services;

public class QuestionManager:IQuestionService
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IQuestionImageService _questionImageService;

    public QuestionManager(IQuestionRepository questionRepository, IQuestionImageService questionImageService)
    {
        _questionRepository = questionRepository;
        _questionImageService = questionImageService;
    }

    public async Task<Question> AddAsync(Question question, IFormFileCollection files)
    {
        Question createdQuestion = await _questionRepository.AddAsync(question);
        await _questionImageService.Upload(createdQuestion.Id, files);
        return createdQuestion;
    }
}