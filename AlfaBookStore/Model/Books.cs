using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace AlfaBookStore.model
{
    /* This model was set up so that I could link the table in the databse that handles all the data for the books
       To my project. This way i could extract and insert values to the columns in the database*/
    public class Books
    {
        [Key]
        public int ID { get; set; }
        [StringLength(255)]
        public string Title { get; set; }
        [StringLength(255)]
        public string Author { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
        public byte[]? Image { get; set; }
    }
}

