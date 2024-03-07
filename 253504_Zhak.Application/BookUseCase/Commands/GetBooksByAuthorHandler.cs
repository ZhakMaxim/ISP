using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _253504_Zhak.Application.BookUseCase.Queries;

namespace _253504_Zhak.Application.BookUseCase.Commands
{
    internal class GetBooksByAuthorHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetBooksByAuthorRequest, IEnumerable<Book>>
    {
        public async Task<IEnumerable<Book>> Handle(GetBooksByAuthorRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.BookRepository
            .ListAsync(t => t.AuthorId.Equals(request.Id),
           cancellationToken);
        }
    }
}
