using System.ComponentModel.DataAnnotations;

namespace ProducerServices.Entities
{
    public class OrderRequest
    {
        [Key]
        public int OrderId{ get; set; }
        [Required]
        public int ProductId{ get; set; }

        [Required]
        public int CustomerId{ get; set; }

        public int Quantity { get; set; }

        public string Status{ get; set; }
    }
}
