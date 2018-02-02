using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalManagementApps.Models
{
    public class Room
    {
        public int ID { get; set; }

        public int KostID { get; set; }

        [Required(ErrorMessage = "Nama Kamar Wajib Diisi")]
        public string RoomName { get; set; }

        [Required(ErrorMessage = "Lebar Kamar Wajib Diisi")]
        public int RoomWidth { get; set; }

        [Required(ErrorMessage = "Lebar Kamar Wajib Diisi")]
        public int RoomLength { get; set; }

        [Required(ErrorMessage = "Biaya Wajib Diisi")]
        public int MonthlyFee { get; set; }

        public bool IsNowAvailable { get; set; }

        public Kost Kost { get; set; }
    }
}
