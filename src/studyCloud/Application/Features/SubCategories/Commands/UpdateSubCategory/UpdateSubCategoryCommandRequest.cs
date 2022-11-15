using Application.Features.SubCategories.Dtos;
using MediatR;

namespace Application.Features.SubCategories.Commands.UpdateSubCategory;

public class UpdateSubCategoryCommandRequest:IRequest<UpdateSubCategoryCommandResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
    
}