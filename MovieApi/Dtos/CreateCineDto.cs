using System.ComponentModel.DataAnnotations;

namespace MovieApi.Dtos
{
    public class CreateCineDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "O 'Name' deve ter no máximo 50 caracteres")]
        public string Name { get; set; }
        public CreateAddressDto Address { get; set; }
    }
}
