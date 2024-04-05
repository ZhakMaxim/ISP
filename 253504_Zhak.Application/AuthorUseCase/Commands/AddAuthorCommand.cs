using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Zhak.Application.AuthorUseCase.Commands
{
    public sealed record AddAuthorCommand(string Name, int Age, string WritingStyle, int Id) : IRequest<Author>;
}
