using MediatR;

namespace Application.Features.FlashCard.Commands.DeleteFlashCard;

public class DeleteFlashCardCommandRequest:IRequest<DeleteFlashCardCommandResponse>
{
    public long Id { get; set; }
}