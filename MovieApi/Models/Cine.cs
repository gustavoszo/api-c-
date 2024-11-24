using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models
{
    public class Cine
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        [JsonIgnore]  // Ignorar a referência circular
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
