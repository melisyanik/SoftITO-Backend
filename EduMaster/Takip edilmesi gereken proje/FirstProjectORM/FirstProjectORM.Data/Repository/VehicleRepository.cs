using FirstProjectORM.Data.Repository.IRepository;
using FirstProjectORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProjectORM.Data.Repository
{
    public class VehicleRepository : Repository<Vehicle>, IVehicle
    {
        private ApplicationDbContext _context;

        public VehicleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
