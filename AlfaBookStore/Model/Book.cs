using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace AlfaBookStore.model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Title { get; set; }
        [StringLength(255)]
        public string Author { get; set; }
        [StringLength(255)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        public Nullable<decimal> Price { get; set; }
        public byte[]? Image { get; set; }
    }
}

