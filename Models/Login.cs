using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BELTEXAM.Models {
    public class Login {
        [Required (ErrorMessage = "Email address required to log in")]
        [Display (Name = "Login Email: ")]
        [DataType (DataType.EmailAddress)]
        [EmailAddress (ErrorMessage = "Hey now, none of that funny business")]
        public string LoginEmail { get; set; }

        [Required (ErrorMessage = "Password required to log in")]
        [Display (Name = "Login Password: ")]
        [DataType (DataType.Password)]
        public string LoginPassword { get; set; }
    }
}