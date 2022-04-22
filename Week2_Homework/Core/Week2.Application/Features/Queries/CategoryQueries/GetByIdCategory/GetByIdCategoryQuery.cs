using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Repositories.CategoryRepository;

namespace Week2.Application.Features.Queries.CategoryQueries.GetByIdCategory
{

    public class GetByIdCategoryQuery : IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryQueryResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;

        public GetByIdCategoryQuery(ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            
            var category =await _categoryReadRepository.GetByIdAsync(request.Id);

            return _mapper.Map<GetByIdCategoryQueryResponse>(category);
        }
    }
}
