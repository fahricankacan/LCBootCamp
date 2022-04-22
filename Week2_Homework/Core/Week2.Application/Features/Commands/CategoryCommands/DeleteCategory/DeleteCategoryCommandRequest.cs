using MediatR;

namespace Week2.Application.Features.Commands.CategoryCommands.DeleteCategory
{
    public class DeleteCategoryCommandRequest : IRequest<DeleteCategoryCommandResponse>
    {
        public string Id { get; set; }
    }
}
