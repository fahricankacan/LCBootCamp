using MediatR;

namespace Week2.Application.Features.Commands.DiscountCommands.DeleteDiscount
{
    public class DeleteDiscountCommandRequest : IRequest<DeleteDiscountCommandResponse>
    {
        public string Id { get; set; }
    }
}
