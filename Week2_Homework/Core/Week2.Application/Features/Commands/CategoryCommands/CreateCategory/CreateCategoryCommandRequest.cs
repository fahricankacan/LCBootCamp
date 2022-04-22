using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Application.Features.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
    {
        //public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
