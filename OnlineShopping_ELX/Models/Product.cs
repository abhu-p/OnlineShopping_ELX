using System.ComponentModel.DataAnnotations;
namespace OnlineShopping_ELX.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Title cannot be blank")]
        [StringLength(20,ErrorMessage ="Title cannot be greater than 20")]
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string? ProductImage { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }  
    }
}
