using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eval_3.Models {
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string faculty { get; set; }
        public DateTime? date_last_reserve { get; set; }
        public int? cant_reserves_last_mont { get; set; }
        public virtual ICollection<BookReservation>? reserves { get; set; }
    }
}
