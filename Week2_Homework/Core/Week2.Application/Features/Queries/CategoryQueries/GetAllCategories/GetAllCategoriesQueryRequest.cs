using MediatR;


namespace Week2.Application.Features.Queries.CategoryQueries.GetAllCategories
{
    public class GetAllCategoriesQueryRequest:IRequest<IEnumerable<GetAllCategoriesQueryResponse>> { }

}
