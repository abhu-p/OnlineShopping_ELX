namespace OnlineShopping_ELX.Models
{
    public class BuyProduct
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        
    }
}
