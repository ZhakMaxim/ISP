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
        public Book(BookAttributes attributes, double? rate = 0)
        {
            Attributes = attributes;
            Rate = rate.Value;
        }

        public BookAttributes Attributes { get; private set; }
        public double Rate { get; private set; }
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

    }
}
