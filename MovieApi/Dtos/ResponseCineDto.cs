using System.ComponentModel.DataAnnotations;

namespace MovieApi.Dtos
{
    public class ResponseCineDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ResponseAddressDto Address;
    }
}
