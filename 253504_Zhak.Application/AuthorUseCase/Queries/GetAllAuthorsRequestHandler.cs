using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Zhak.Application.AuthorUseCase.Queries
{
    internal class GetAllAuthorsRequestHandler : IRequestHandler<GetAllAuthorsRequest, IEnumerable<Author>>
    {
        private IRepository<Author> _AuthorRepository;

        public GetAllAuthorsRequestHandler(IRepository<Author> AuthorRepository)
        {
            _AuthorRepository = AuthorRepository;
        }

        public async Task<IEnumerable<Author>> Handle(GetAllAuthorsRequest request, CancellationToken cancellationToken)
        {
            var Authors = await _AuthorRepository.ListAllAsync(cancellationToken);
            return Authors;
        }
    }
}
