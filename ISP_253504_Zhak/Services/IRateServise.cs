using ISP_253504_Zhak.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ISP_253504_Zhak.Services
{
    public interface IRateServise
    {
        Task<IEnumerable<Rate>> GetRates(DateTime date);
    }
}

