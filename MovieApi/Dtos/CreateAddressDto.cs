using System.ComponentModel.DataAnnotations;

namespace MovieApi.Dtos
{
    public class CreateAddressDto
    {
        [Required]
        [MaxLength(150)]
        public string Street { get; set; }

        [Required]
        public int Number { get; set; }

    }
}
