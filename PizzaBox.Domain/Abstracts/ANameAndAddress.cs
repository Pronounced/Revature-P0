using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class ANameAndAddress
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Address2 { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }
    }
}