using System.ComponentModel.DataAnnotations;

namespace MovieApi.Dtos
{
    public class CreateRoomDto
    {
        [Required]
        public int CineId { get; set; }
        
    }
}
