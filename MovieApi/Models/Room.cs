using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models
{
    public class Room
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int CineId { get; set; }


        public virtual Cine Cine { get; set; }

    }
}
