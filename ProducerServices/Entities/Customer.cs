using System.ComponentModel.DataAnnotations;

namespace ProducerServices.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Pincode { get; set; }
    }
}
