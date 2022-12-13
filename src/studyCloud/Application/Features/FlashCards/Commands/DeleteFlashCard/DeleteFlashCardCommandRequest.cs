using MediatR;

namespace Application.Features.FlashCards.Commands.DeleteFlashCard;

public class DeleteFlashCardCommandRequest:IRequest<DeleteFlashCardCommandResponse>
{
    public long Id { get; set; }
}