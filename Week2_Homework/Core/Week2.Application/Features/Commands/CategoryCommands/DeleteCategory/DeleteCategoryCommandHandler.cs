using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Repositories.CategoryRepository;
using Week2.Application.Repositories.ProductRepository;

namespace Week2.Application.Features.Commands.CategoryCommands.DeleteCategory
{

    public partial class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly ICategoryWriteRepository _categoryWriteRepository;

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryReadRepository.GetByIdAsync(request.Id);
            if (category == null)
            {
                return new DeleteCategoryCommandResponse
                {
                    Success = false,
                    Message = "Category not found"
                };
            }

            _categoryWriteRepository.Remove(category);
            return new DeleteCategoryCommandResponse
            {
                Success = true,
                Message = "Category deleted"
            };
        }
    }
}
