using System.ComponentModel.DataAnnotations;

namespace MovieApi.Dtos
{
    public class UpdateAddressDto
    {

        [Required]
        [MaxLength(150)]
        public string street { get; set; }

        [Required]
        public int number { get; set; }

    }
}
