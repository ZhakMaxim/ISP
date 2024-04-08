using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Zhak.Application.AuthorUseCase.Commands
{
    public class EditAuthorCommandHandler : IRequestHandler<EditAuthorCommand, Author>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Author> Handle(EditAuthorCommand request, CancellationToken cancellationToken)
        {
            Author existingAuthor =
                await _unitOfWork.AuthorRepository.GetByIdAsync(request.SelectedAuthorId, cancellationToken);

            existingAuthor.ChangeName(request.Name);
            existingAuthor.ChangeAge(request.Age);
            existingAuthor.ChangeWritingStyle(request.WritingStyle);
            existingAuthor.Id = request.SelectedAuthorId;

            await _unitOfWork.AuthorRepository.UpdateAsync(existingAuthor, cancellationToken);
            await _unitOfWork.SaveAllAsync();

            return existingAuthor;
        }
    }
}
