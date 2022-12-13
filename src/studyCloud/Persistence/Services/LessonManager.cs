using Application.Abstractions.Services;
using Application.Features.Categories.Dtos;
using Application.Repositories.Services.Categories;
using Application.Repositories.Services.Lessons;
using AutoMapper;
using Domain.Entities.Categories;
using Domain.Entities.Lessons;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services;

public class LessonManager : ILessonService
{
    private readonly ILessonRepository _lessonRepository;
    private readonly ICategoryRepository _categoryRepository;
    private IMapper _mapper;

    public LessonManager(ILessonRepository lessonRepository, ICategoryRepository categoryRepository, IMapper mapper)
    {
        _lessonRepository = lessonRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<List<Category>> GetListAsync()
    {
        
        List<Category> categories = await _categoryRepository.GetAllAsync(
            include: c => c.Include(c => c.Lessons)
                .Include(c => c.SubCategories).ThenInclude(c => c.Parent)
                .Include(c => c.SubCategories).ThenInclude(c => c.Lessons)
                .Include(c => c.SubCategories).ThenInclude(c => c.Children));
        
        categories = categories
            .Select(p => new Category
            {   
                Name = p.Name,
                SubCategories = p.SubCategories.Where(c=>c.ParentId is null).ToList(),
                Lessons = p.SubCategories.Count == 0 ? p.Lessons : null,
            }).ToList();
        IList<LessonCategoryDto>? mapped = _mapper.Map<IList<LessonCategoryDto>>(categories);


        return categories;
    }
}