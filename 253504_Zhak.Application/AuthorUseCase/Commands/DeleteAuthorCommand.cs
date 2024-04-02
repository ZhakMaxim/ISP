using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Zhak.Application.AuthorUseCase.Commands
{
    public sealed record DeleteAuthorCommand(int Id) : IRequest<Author>;
}
