using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserFavourite : BaseDto
    {
        public int UserId { get; set; }
        public int BookId { get; set; }

        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
    }
}
