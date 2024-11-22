using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models
{
    public class Address
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(150)]
        public string street { get; set; }
        public int number {  get; set; }

        [JsonIgnore]  // Ignorar a referência circular
        public virtual Cine Cine { get; set; }

    }
}
