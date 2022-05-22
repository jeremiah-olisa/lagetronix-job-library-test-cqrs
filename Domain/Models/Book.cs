using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Book : BaseDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string AuthorName { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        public virtual Category Category { get; set; }
        public virtual IList<UserFavourite> LikedBy { get; set; }
    }
}
