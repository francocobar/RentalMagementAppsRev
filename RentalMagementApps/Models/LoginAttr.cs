using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalManagementApps.Models
{
    public class LoginAttr
    {
        [Required(ErrorMessage = "Email wajib diisi")]
        [StringLength(100, ErrorMessage = "Alamat Email Maksimal 20 karakter")]
        [EmailAddress(ErrorMessage = "Email tidak valid")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Password wajib diisi")]
        [StringLength(100, ErrorMessage = "Password setidaknya {2} karakter dan maksimal {1} karakter", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
