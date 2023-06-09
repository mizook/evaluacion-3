using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eval_3.Models {
    public class BookReservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string code { get; set; }
        [Required]
        public DateTime date_reserve { get; set; }
        [ForeignKey("user")]
        public int user_id { get; set; }
        public virtual User user { get; set; }
        [ForeignKey("book")]
        public int book_id { get; set; }
        public virtual Book book { get; set; }
    }
}