using ISP_253504_Zhak.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP_253504_Zhak.Services
{
    public interface IDbService
    {
        public IEnumerable<Cocktail> GetAllCocktail();
        public IEnumerable<Ingridient> GetCocktailIngridients(int id);
        public void Init();
    }
}
