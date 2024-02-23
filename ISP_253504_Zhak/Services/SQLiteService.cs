using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISP_253504_Zhak.Entities;
using SQLite;
using RandomString4Net;

namespace ISP_253504_Zhak.Services
{
    public class SQLiteService : IDbService
    {

        SQLiteConnection db;
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "MyData6.db");

        public SQLiteService()
        {

        }

        public IEnumerable<Cocktail> GetAllCoctail()
        {
            return db.Table<Cocktail>().ToList();
        }

        public IEnumerable<Ingridient> GetCoctailIngridients(int id)
        {
            return db.Table<Ingridient>().Where(i => i.CocktailId == id).ToList();
        }

        public void Init()
        {
            if (File.Exists(dbPath))
            {
                db = new SQLiteConnection(dbPath);
            }
            else
            {
                db = new SQLiteConnection(dbPath);

                db.CreateTable<Cocktail>();
                db.CreateTable<Ingridient>();

                int numCocktails = new Random().Next(10,21);

                for (int i = 0; i < numCocktails; i++)
                {
                    string randomCocktailName = RandomString.GetString(Types.ALPHABET_LOWERCASE, new Random().Next(5,11));

                    db.Insert(new Cocktail { Name = randomCocktailName });

                    int numIngredients = new Random().Next(4, 7);

                    for (int j = 0; j < numIngredients; j++)
                    {
                        string randomIngredientName = RandomString.GetString(Types.ALPHABET_LOWERCASE, new Random().Next(5, 11));

                        db.Insert(new Ingridient { Name = randomIngredientName, CocktailId = i + 1 });
                    }

                }
            }
        }
    }
}
