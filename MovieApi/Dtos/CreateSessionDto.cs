using System.ComponentModel.DataAnnotations;

namespace MovieApi.Dtos
{
    public class CreateSessionDto
    {

        [Required]
        public int CineId { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public int MoovieId { get; set; }

        [Required]
        public string Time { get; set; }

    }
}
