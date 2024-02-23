using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ISP_253504_Zhak.Entities
{
    [Table("Cocktails")]
    public class Cocktail
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int Id { get; set; } 
        public string Name { get; set; }

    }
}
