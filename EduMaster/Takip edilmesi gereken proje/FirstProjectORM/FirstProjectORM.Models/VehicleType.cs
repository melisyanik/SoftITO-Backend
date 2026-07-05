using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProjectORM.Models
{
    public class VehicleType
    {
        [Key]
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string Explanation { get; set; }
    }
}
