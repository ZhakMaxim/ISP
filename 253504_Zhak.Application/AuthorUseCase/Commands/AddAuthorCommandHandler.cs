using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Zhak.Application.AuthorUseCase.Commands
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, Author>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Author> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            Author newAuthor = new Author(request.Name, request.Age, request.WritingStyle, request.Id);

            await _unitOfWork.AuthorRepository.AddAsync(newAuthor);
            await _unitOfWork.SaveAllAsync();
            return newAuthor;
        }
    }
}
