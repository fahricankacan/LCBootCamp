using MediatR;
using Week2.Application.Repositories.CategoryRepository;

namespace Week2.Application.Features.Commands.CategoryCommands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly ICategoryWriteRepository _categoryWriteRepository;

        public UpdateCategoryCommandHandler(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryReadRepository.GetByIdAsync(request.Id);
            if (category == null)
            {
                return new UpdateCategoryCommandResponse
                {
                    Success = false,
                    Message = "Category not found"
                };
            }

            if(request.Name is null && request.Description is null)
            {
                return new UpdateCategoryCommandResponse
                {
                    Success = false,
                    Message = "There is a no data to update"
                };
            }

            category.Name = request.Name ?? category.Name;

            category.Description = request.Description ?? category.Description;
            //category.Description != request.Description && request.Description !=null ? request.Description : category.Description;

            await _categoryWriteRepository.SaveAsync();

            return new UpdateCategoryCommandResponse
            {
                Success = true,
                Message = "Category updated successfully"
            };
        }
    }

}
