using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BELTEXAM.Models {
    public class Participant {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int EventID { get; set; }
        public Event Event { get; set; }
        public User User { get; set; }
    }
}