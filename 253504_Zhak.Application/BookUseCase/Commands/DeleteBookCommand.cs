using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Zhak.Application.BookUseCase.Commands
{
    public sealed record DeleteBookCommand(int SelectedTaskId) : IRequest<Book>;
}
