using System.ComponentModel.DataAnnotations;

namespace MovieApi.Dtos
{
    public class ResponseAddressDto
    {
        public int id;
        public string street { get; set; }

        public int number { get; set; }

    }
}
