using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class CreateBookDto
    {
        [Required]
        /// <summary>
        /// The book title
        /// </summary>
        /// <example>Show dog</example>
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string AuthorName { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }
    }
}
