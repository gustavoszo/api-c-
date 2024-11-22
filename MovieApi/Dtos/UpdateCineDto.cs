using System.ComponentModel.DataAnnotations;

namespace MovieApi.Dtos
{
    public class UpdateCineDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "O 'Name' deve ter no máximo 50 caracteres")]
        public string Name { get; set; }
    }
}
