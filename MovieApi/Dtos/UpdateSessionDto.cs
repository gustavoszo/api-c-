using System.ComponentModel.DataAnnotations;

namespace MovieApi.Dtos
{
    public class UpdateSessionDto
    {
       
        [Required]
        public int MoovieId { get; set; }

        [Required]
        public DateTime Time { get; set; }
    }
}
