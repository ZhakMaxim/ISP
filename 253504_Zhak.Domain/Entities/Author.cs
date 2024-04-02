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
        public Author(string name, int age, string writingStyle, string nameOfimageFile, int id) 
        {
            Name = name;
            Age = age;
            WritingStyle = writingStyle;
            NameOfImageFile = nameOfimageFile;
            Id = id;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public string NameOfImageFile { get; set; } = "dotnet_bot.png";

        public string WritingStyle { get; set; }        //expository, persuasive, narrative, descriptive and creative.

        public IReadOnlyList<Book> Books
        {
            get => _books.AsReadOnly();
        }

    }
}
