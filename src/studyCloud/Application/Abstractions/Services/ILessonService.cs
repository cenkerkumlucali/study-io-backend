using Application.Features.Categories.Dtos;
using Domain.Entities.Categories;

namespace Application.Abstractions.Services;

public interface ILessonService
{
    Task<List<Category>> GetListAsync();
}