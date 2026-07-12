using Microsoft.Extensions.Configuration;
using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.DATA.Repository
{
    public class PaymentDapperRepository : DapperRepository<Payment>, IPaymentDapperRepository
    {
        public PaymentDapperRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
