using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Category : BaseDto
    {
        public string Name { get; set; }

        public IList<Book> Books { get; set; }
    }
}
