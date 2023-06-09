using System.Collections.Generic;
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
        [ForeignKey("user_id")]
        public int user_id { get; set; }
        [ForeignKey("book_id")]
        public int book_id { get; set; }
        public DateTime? date_reserve { get; set; }
        public virtual User? user { get; set; }
        public virtual Book? book { get; set; }
    }
}