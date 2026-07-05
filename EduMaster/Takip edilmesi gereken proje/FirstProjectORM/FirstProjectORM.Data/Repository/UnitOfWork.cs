using FirstProjectORM.Data.Repository.IRepository;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProjectORM.Data.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

       public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        IVehicle IUnitOfWork.Vehicle => new VehicleRepository(_context);

        IVehicleType IUnitOfWork.VehicleType => new VehicleTypeRepository(_context);

        public void Dispose()
        {
           _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
