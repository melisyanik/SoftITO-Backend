using SmartMunicipality.MODEL;
using System;

namespace SmartMunicipality.DATA.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IComplaintRepository Complaint { get; }
        IComplaintDapperRepository ComplaintDapper { get; }

        IComplaintCategoryRepository ComplaintCategory { get; }
        IComplaintCategoryDapperRepository ComplaintCategoryDapper { get; }

        IComplaintStatusRepository ComplaintStatus { get; }
        IComplaintStatusDapperRepository ComplaintStatusDapper { get; }

        IComplaintResponseRepository ComplaintResponse { get; }
        IComplaintResponseDapperRepository ComplaintResponseDapper { get; }

        IServiceTypeRepository ServiceType { get; }
        IServiceTypeDapperRepository ServiceTypeDapper { get; }

        ISubscriptionRepository Subscription { get; }
        ISubscriptionDapperRepository SubscriptionDapper { get; }

        IConsumptionRecordRepository ConsumptionRecord { get; }
        IConsumptionRecordDapperRepository ConsumptionRecordDapper { get; }

        IBillRepository Bill { get; }
        IBillDapperRepository BillDapper { get; }

        IPaymentRepository Payment { get; }
        IPaymentDapperRepository PaymentDapper { get; }

        IAnnouncementRepository Announcement { get; }
        IAnnouncementDapperRepository AnnouncementDapper { get; }

        IAIAlertRepository AIAlert { get; }
        IAIAlertDapperRepository AIAlertDapper { get; }

        INotificationRepository Notification { get; }
        INotificationDapperRepository NotificationDapper { get; }
        void Save();
    }
}
