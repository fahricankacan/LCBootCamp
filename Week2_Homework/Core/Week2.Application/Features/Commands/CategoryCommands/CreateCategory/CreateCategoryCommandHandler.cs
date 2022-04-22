using MediatR;
using Week2.Application.Repositories.CategoryRepository;
using Week2.Domain.Entities;

namespace Week2.Application.Features.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly ICategoryWriteRepository _categoryWriteRepository;

        public CreateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = new Category() { Name = request.Name, Description = request.Description };
            
            var result = await _categoryWriteRepository.AddAsync(category);

            _categoryWriteRepository.SaveAsync();
            return new CreateCategoryCommandResponse() { Succes = result, Message = result ? "Succesfull":"Error" };
        }
    }

}
