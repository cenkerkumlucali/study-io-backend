using Application.Abstractions.Services;
using Application.Abstractions.Services.ElasticSearch;
using Application.DTOs.ElasticSearch;
using Application.Features.Users.User.Dtos;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.User.Commands.EditProfile;

public class EditProfileCommandHandler:IRequestHandler<EditProfileCommandRequest,EditProfileCommandResponse>
{
    private readonly IUserService _userService;
    private readonly IElasticSearch _elasticSearch;
    private IMapper _mapper;

    public EditProfileCommandHandler(IUserService userService, IMapper mapper, IElasticSearch elasticSearch)
    {
        _userService = userService;
        _mapper = mapper;
        _elasticSearch = elasticSearch;
    }

    public async Task<EditProfileCommandResponse> Handle(EditProfileCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Users.User user = await _userService.GetById(request.Id);
        Domain.Entities.Users.User? mappedUser = _mapper.Map(request,user);
        Domain.Entities.Users.User updatedUser = await _userService.Update(mappedUser);
        List<ElasticSearchGetModel<UserDto>> getUser = await
            _elasticSearch.GetSearchByField<UserDto>(
                new SearchByFieldParameters
                {
                    IndexName = "users",
                    FieldName = "UserName",
                    Value = user.UserName
                });

        ElasticSearchInsertUpdateModel model = new()
        {
            ElasticId = getUser.FirstOrDefault()?.ElasticId,
            IndexName = "users",
            Item = new UserDto
            {
                Id = updatedUser.Id,
                FullName = updatedUser.FirstName + " " + updatedUser.LastName,
                UserName = updatedUser.UserName,
                PictureUrl = updatedUser.UserImageFiles.LastOrDefault()?.Url
            }
        };
        await _elasticSearch.UpdateByElasticIdAsync(model);
        EditProfileCommandResponse? mappedResponse = _mapper.Map<EditProfileCommandResponse>(updatedUser);
        return mappedResponse;
    }
}