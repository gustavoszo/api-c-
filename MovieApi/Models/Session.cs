using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models
{
    public class Session
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int CineId { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required] 
        public int MoovieId { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public virtual Cine Cine { get; set; }
        public virtual Room Room { get; set; }
        public virtual Movie Movie { get; set; }

    }
}
