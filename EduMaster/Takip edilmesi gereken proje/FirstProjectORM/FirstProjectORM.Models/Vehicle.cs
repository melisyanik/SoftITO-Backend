using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProjectORM.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string VehicleName { get; set; }
        public string Gear { get; set; }
        public string EnginePower { get; set; }
        public string Barcode  { get; set; }
        public double Price { get; set; }
        public string Photo { get; set; }

        [ForeignKey("VehicleTypeId")]
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }

    }
}
