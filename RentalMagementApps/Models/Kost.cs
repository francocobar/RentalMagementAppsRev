using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalManagementApps.Models
{
    public class Kost
    {
        public int ID { get; set; }
        public int UserID { get; set; } //owner

        [Required(ErrorMessage = "Nama kost wajib diisi")]
        [StringLength(30, ErrorMessage = "Nama kost setidaknya {2} karakter dan maksimal {1} karakter", MinimumLength = 3)]
        public string KostName { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
