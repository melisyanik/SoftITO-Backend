using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProjectORM.Data.Repository.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        IVehicle Vehicle { get; }
        IVehicleType VehicleType { get; }

        void Save();

    }
}
