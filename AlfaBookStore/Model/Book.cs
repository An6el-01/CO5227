using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace AlfaBookStore.model
{
    public class Book
    {
        [Key]
        public int id { get; set; }
        [StringLength(30)]
        public string title { get; set; }
        [StringLength(255)]
        public string author { get; set; }
        [StringLength(255)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        public Nullable<decimal> price { get; set; }
    }
}

