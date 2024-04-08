using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Zhak.Domain.Entities
{
    public class Book : Entity
    {
        private Book() { }
        public Book(string title,  string nameOfImageFile, int id, double? rate = 0)
        {
            Title = title;
            Rate = rate.Value;
            NameOfImageFile = nameOfImageFile;
            Id = id;
        }

        public Book(string title, double rate, string nameOfImageFile, int? authorId)
        {
            Title = title;
            Rate = rate;
            NameOfImageFile = nameOfImageFile;
            AuthorId = authorId;
        }

        public string Title { get; private set; }
        public double Rate { get; private set; }

        public string NameOfImageFile { get; private set; } = "dotnet_bot.png";
        public int? AuthorId {  get; private set; }

        public void AddToAuthor(int authorId) 
        {
            if (AuthorId <= 0) return;
            AuthorId = authorId;
        }
        public void RemoveFromAuthor(int authorId) 
        {  
            AuthorId = 0;
        }
        public void ChangeRate(double rate)
        {
            if (rate < 0 || rate > 10) return;
            Rate = rate;
        }

        public void ChangeTitle(string title)
        {
            if (Title != null)
            Title = title;
        }

    }
}
