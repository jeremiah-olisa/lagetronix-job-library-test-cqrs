using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class CreateUserFavouriteDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int BookId { get; set; }
    }
}
