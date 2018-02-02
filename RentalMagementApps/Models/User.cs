using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalManagementApps.Models
{
    public class User
    {
        public int ID { get; set; }

        [StringLength(20, ErrorMessage = "Nama Belakang Maksimal 20 karakter", MinimumLength = 0)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Nama depan wajib diisi")]
        [StringLength(20, ErrorMessage = "Nama Depan Maksimal 20 karakter")]
        public string FirstMidName { get; set; }

        [Required(ErrorMessage = "Email wajib diisi")]
        [StringLength(100, ErrorMessage = "Alamat Email Maksimal 20 karakter")]
        [EmailAddress(ErrorMessage = "Email tidak valid")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password wajib diisi")]
        [StringLength(100, ErrorMessage = "Password setidaknya {2} karakter dan maksimal {1} karakter", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Konfirmasi Password tidak sama")]
        public string ConfirmPassword { get; set; }
    }
}
