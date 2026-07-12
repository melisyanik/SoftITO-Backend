using Microsoft.Extensions.Configuration;
using SmartMunicipality.Data;
using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.DATA.Repository;
using SmartMunicipality.MODEL;
using System;

namespace SmartMunicipality.DATA.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public UnitOfWork(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            Complaint = new ComplaintRepository(_context);
            ComplaintDapper = new ComplaintDapperRepository(_configuration);

            ComplaintCategory = new ComplaintCategoryRepository(_context);
            ComplaintCategoryDapper = new ComplaintCategoryDapperRepository(_configuration);

            ComplaintStatus = new ComplaintStatusRepository(_context);
            ComplaintStatusDapper = new ComplaintStatusDapperRepository(_configuration);

            ComplaintResponse = new ComplaintResponseRepository(_context);
            ComplaintResponseDapper = new ComplaintResponseDapperRepository(_configuration);

            ServiceType = new ServiceTypeRepository(_context);
            ServiceTypeDapper = new ServiceTypeDapperRepository(_configuration);

            Subscription = new SubscriptionRepository(_context);
            SubscriptionDapper = new SubscriptionDapperRepository(_configuration);

            ConsumptionRecord = new ConsumptionRecordRepository(_context);
            ConsumptionRecordDapper = new ConsumptionRecordDapperRepository(_configuration);

            Bill = new BillRepository(_context);
            BillDapper = new BillDapperRepository(_configuration);

            Payment = new PaymentRepository(_context);
            PaymentDapper = new PaymentDapperRepository(_configuration);

            Announcement = new AnnouncementRepository(_context);
            AnnouncementDapper = new AnnouncementDapperRepository(_configuration);

            AIAlert = new AIAlertRepository(_context);
            AIAlertDapper = new AIAlertDapperRepository(_configuration);

            Notification = new NotificationRepository(_context);
            NotificationDapper = new NotificationDapperRepository(_configuration);
        }
        public IComplaintRepository Complaint { get; private set; }
        public IComplaintDapperRepository ComplaintDapper { get; private set; }

        public IComplaintCategoryRepository ComplaintCategory { get; private set; }
        public IComplaintCategoryDapperRepository ComplaintCategoryDapper { get; private set; }

        public IComplaintStatusRepository ComplaintStatus { get; private set; }
        public IComplaintStatusDapperRepository ComplaintStatusDapper { get; private set; }

        public IComplaintResponseRepository ComplaintResponse { get; private set; }
        public IComplaintResponseDapperRepository ComplaintResponseDapper { get; private set; }

        public IServiceTypeRepository ServiceType { get; private set; }
        public IServiceTypeDapperRepository ServiceTypeDapper { get; private set; }

        public ISubscriptionRepository Subscription { get; private set; }
        public ISubscriptionDapperRepository SubscriptionDapper { get; private set; }

        public IConsumptionRecordRepository ConsumptionRecord { get; private set; }
        public IConsumptionRecordDapperRepository ConsumptionRecordDapper { get; private set; }

        public IBillRepository Bill { get; private set; }
        public IBillDapperRepository BillDapper { get; private set; }

        public IPaymentRepository Payment { get; private set; }
        public IPaymentDapperRepository PaymentDapper { get; private set; }

        public IAnnouncementRepository Announcement { get; private set; }
        public IAnnouncementDapperRepository AnnouncementDapper { get; private set; }

        public IAIAlertRepository AIAlert { get; private set; }
        public IAIAlertDapperRepository AIAlertDapper { get; private set; }

        public INotificationRepository Notification { get; private set; }
        public INotificationDapperRepository NotificationDapper { get; private set; }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
