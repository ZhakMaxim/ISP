using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Zhak.Domain.Entities
{
    public class Author : Entity
    {
        private List<Book> _books = new();
        private Author() { }
        public Author(string name, int age, string writingStyle)
        {
            Name = name;
            Age = age;
            WritingStyle = writingStyle;
        }

        public Author(string name, int age, string writingStyle, int id) 
        {
            Name = name;
            Age = age;
            WritingStyle = writingStyle;
            Id = id;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }

        public string WritingStyle { get; private set; }        //expository, persuasive, narrative, descriptive and creative.

        public IReadOnlyList<Book> Books
        {
            get => _books.AsReadOnly();
        }
        
        public void ChangeName(string name) 
        {
            if(name != null) 
                Name = name;
        }

        public void ChangeAge(int age) 
        {
            Age = age;
        }

        public void ChangeWritingStyle(string writingStyle) 
        {
            if (writingStyle != null)
                WritingStyle = writingStyle;
        }

    }
}
