using System.ComponentModel.DataAnnotations;

namespace AlfaBookStore.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public decimal Price { get; set; }

       //Next step is to load database on SQL look at the indian guy video minute 58:41
       //Had to stop bc VPN for the school wont recognize that im connected to WI-FI
    }
}
