using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartMunicipality.Data;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.EFCoreApi.DataSeeding
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            context.Database.Migrate();

            CreateStoredProcedures(context);

            
            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            if (!await roleManager.RoleExistsAsync("Operator"))
                await roleManager.CreateAsync(new IdentityRole("Operator"));
            if (!await roleManager.RoleExistsAsync("Citizen"))
                await roleManager.CreateAsync(new IdentityRole("Citizen"));

            
            var admin = await userManager.FindByEmailAsync("admin@belediye.bel.tr");
            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = "admin@belediye.bel.tr",
                    Email = "admin@belediye.bel.tr",
                    EmailConfirmed = true,
                    Name = "Ahmet",
                    Surname = "Yılmaz"
                };
                await userManager.CreateAsync(admin, "Admin123!");
                await userManager.AddToRoleAsync(admin, "Admin");
            }
            else
            {
                await userManager.RemovePasswordAsync(admin);
                await userManager.AddPasswordAsync(admin, "Admin123!");
                if (!await userManager.IsInRoleAsync(admin, "Admin"))
                    await userManager.AddToRoleAsync(admin, "Admin");
            }

            
            var opUser = await userManager.FindByEmailAsync("operator@operator.bel.tr");
            if (opUser == null)
            {
                opUser = new ApplicationUser
                {
                    UserName = "operator@operator.bel.tr",
                    Email = "operator@operator.bel.tr",
                    EmailConfirmed = true,
                    Name = "Mehmet",
                    Surname = "Demir"
                };
                await userManager.CreateAsync(opUser, "Operator123!");
                await userManager.AddToRoleAsync(opUser, "Operator");
            }
            else
            {
                await userManager.RemovePasswordAsync(opUser);
                await userManager.AddPasswordAsync(opUser, "Operator123!");
                if (!await userManager.IsInRoleAsync(opUser, "Operator"))
                    await userManager.AddToRoleAsync(opUser, "Operator");
            }

            
            ApplicationUser? citizen = await userManager.FindByEmailAsync("citizen@gmail.com");
            if (citizen == null)
            {
                citizen = new ApplicationUser
                {
                    UserName = "citizen@gmail.com",
                    Email = "citizen@gmail.com",
                    EmailConfirmed = true,
                    Name = "Can",
                    Surname = "Kaya",
                    Address = "Kadıköy, İstanbul",
                    District = "Kadıköy"
                };
                await userManager.CreateAsync(citizen, "Citizen123!");
                await userManager.AddToRoleAsync(citizen, "Citizen");
            }
            else
            {
                await userManager.RemovePasswordAsync(citizen);
                await userManager.AddPasswordAsync(citizen, "Citizen123!");
                if (!await userManager.IsInRoleAsync(citizen, "Citizen"))
                    await userManager.AddToRoleAsync(citizen, "Citizen");
            }

            
            ApplicationUser? melis = await userManager.FindByEmailAsync("melisyanik02@hotmail.com");
            if (melis == null)
            {
                melis = new ApplicationUser
                {
                    UserName = "melisyanik02@hotmail.com",
                    Email = "melisyanik02@hotmail.com",
                    EmailConfirmed = true,
                    Name = "Melis",
                    Surname = "Yanık",
                    Address = "Beşiktaş, İstanbul",
                    District = "Beşiktaş"
                };
                await userManager.CreateAsync(melis, "Citizen123!");
                await userManager.AddToRoleAsync(melis, "Citizen");
            }
            else
            {
                await userManager.RemovePasswordAsync(melis);
                await userManager.AddPasswordAsync(melis, "Citizen123!");
                if (!await userManager.IsInRoleAsync(melis, "Citizen"))
                    await userManager.AddToRoleAsync(melis, "Citizen");
            }

            
            if (!context.Announcements.Any())
            {
                context.Announcements.AddRange(
                    new Announcement { Title = "Lodos Uyarısı", Content = "🔴 İstanbul geneli lodos uyarısı! Lütfen dikkatli olunuz.", PublishDate = DateTime.Now.AddHours(-2), IsActive = true },
                    new Announcement { Title = "Metro Temel Atma Töreni", Content = "🟢 Yeni metro hattı projesi temel atma töreni bu cuma gerçekleşecek.", PublishDate = DateTime.Now.AddDays(-1), IsActive = true },
                    new Announcement { Title = "Akıllı Şehir Portalı", Content = "🔵 Akıllı Şehir Portalımız üzerinden şikayetlerinizi anlık olarak takip edebilirsiniz.", PublishDate = DateTime.Now.AddDays(-3), IsActive = true },
                    new Announcement { Title = "Planlı Bakım", Content = "🟣 E-belediye sistemlerinde hafta sonu planlı bakım çalışması yapılacaktır.", PublishDate = DateTime.Now.AddHours(-5), IsActive = true }
                );
                await context.SaveChangesAsync();
            }

            
            if (!context.ComplaintCategories.Any())
            {
                context.ComplaintCategories.AddRange(
                    new ComplaintCategory { Name = "Altyapı ve Su", Description = "Yol, su, kanalizasyon" },
                    new ComplaintCategory { Name = "Yol ve Ulaşım", Description = "Toplu taşıma, yollar" },
                    new ComplaintCategory { Name = "Çevre ve Temizlik", Description = "Çöp, atık" },
                    new ComplaintCategory { Name = "Diğer", Description = "Diğer şikayetler" }
                );
                await context.SaveChangesAsync();
            }
            else
            {
                var c1 = context.ComplaintCategories.FirstOrDefault(c => c.Id == 1);
                if (c1 != null) { c1.Name = "Altyapı ve Su"; }
                var c2 = context.ComplaintCategories.FirstOrDefault(c => c.Id == 2);
                if (c2 != null) { c2.Name = "Yol ve Ulaşım"; }
                var c3 = context.ComplaintCategories.FirstOrDefault(c => c.Id == 3);
                if (c3 != null) { c3.Name = "Çevre ve Temizlik"; }
                
                if (!context.ComplaintCategories.Any(c => c.Name == "Diğer"))
                {
                    context.ComplaintCategories.Add(new ComplaintCategory { Name = "Diğer", Description = "Diğer şikayetler" });
                }
                await context.SaveChangesAsync();
            }

            if (!context.ComplaintStatuses.Any())
            {
                context.ComplaintStatuses.AddRange(
                    new ComplaintStatus { Name = "Bekliyor" },
                    new ComplaintStatus { Name = "İşlemde" },
                    new ComplaintStatus { Name = "Çözüldü" },
                    new ComplaintStatus { Name = "Reddedildi" }
                );
                await context.SaveChangesAsync();
            }
            else if (!context.ComplaintStatuses.Any(s => s.Name == "Reddedildi"))
            {
                context.ComplaintStatuses.Add(new ComplaintStatus { Name = "Reddedildi" });
                await context.SaveChangesAsync();
            }

            
            if (!context.Complaints.Any())
            {
                var category = context.ComplaintCategories.First();
                var statusResolved = context.ComplaintStatuses.FirstOrDefault(s => s.Name == "Çözüldü");
                var statusPending = context.ComplaintStatuses.FirstOrDefault(s => s.Name == "Bekliyor");

                context.Complaints.AddRange(
                    new Complaint { Title = "Çukur", Description = "Yolda çukur var", CategoryId = category.Id, StatusId = statusResolved?.Id ?? 1, UserId = citizen.Id, Address = "Kadıköy", Latitude = 40.9819, Longitude = 29.0270, CreatedDate = DateTime.Now.AddDays(-1) },
                    new Complaint { Title = "Patlak Boru", Description = "Su sızıyor", CategoryId = category.Id, StatusId = statusPending?.Id ?? 1, UserId = citizen.Id, Address = "Üsküdar", Latitude = 41.0256, Longitude = 29.0170, CreatedDate = DateTime.Now.AddHours(-2) },
                    new Complaint { Title = "Asfalt Çökmesi", Description = "Asfalt çöktü", CategoryId = category.Id, StatusId = statusResolved?.Id ?? 1, UserId = citizen.Id, Address = "Beşiktaş", Latitude = 41.0422, Longitude = 29.0083, CreatedDate = DateTime.Now.AddDays(-5) }
                );
                await context.SaveChangesAsync();
            }

            
            if (!context.ServiceTypes.Any())
            {
                context.ServiceTypes.AddRange(
                    new ServiceType { Name = "Su", Description = "Şebeke Suyu" },
                    new ServiceType { Name = "Doğalgaz", Description = "Doğalgaz Dağıtım" },
                    new ServiceType { Name = "Emlak Vergisi", Description = "Yıllık Emlak Vergisi" }
                );
                await context.SaveChangesAsync();
            }

            
            var citizens = await userManager.GetUsersInRoleAsync("Citizen");
            var suService = context.ServiceTypes.FirstOrDefault(s => s.Name == "Su");
            var dogalgazService = context.ServiceTypes.FirstOrDefault(s => s.Name == "Doğalgaz");
            var emlakService = context.ServiceTypes.FirstOrDefault(s => s.Name == "Emlak Vergisi");
            var rand = new Random();

            foreach (var user in citizens)
            {
                
                if (suService != null && !context.Subscriptions.Any(s => s.UserId == user.Id && s.ServiceTypeId == suService.Id))
                {
                    var subSu = new Subscription
                    {
                        UserId = user.Id,
                        ServiceTypeId = suService.Id,
                        SubscriberNo = "SU-" + rand.Next(100000, 999999).ToString(),
                        MeterNumber = "MTR-" + rand.Next(100000, 999999).ToString(),
                        Address = user.Address ?? "Kadıköy, İstanbul",
                        IsActive = true,
                        CreatedDate = DateTime.Now.AddYears(-1)
                    };
                    context.Subscriptions.Add(subSu);
                    await context.SaveChangesAsync();

                    
                    for (int i = 0; i < 6; i++)
                    {
                        var recordDate = DateTime.Now.AddMonths(-i);
                        var consumption = new ConsumptionRecord
                        {
                            SubscriptionId = subSu.Id,
                            ConsumptionValue = 15.5m + (decimal)(rand.NextDouble() * 10),
                            RecordDate = recordDate
                        };
                        context.ConsumptionRecords.Add(consumption);

                        var bill = new Bill
                        {
                            SubscriptionId = subSu.Id,
                            BillNo = $"FAT-{recordDate:yyyyMM}-SU-{rand.Next(1000, 9999)}",
                            Amount = Math.Round(consumption.ConsumptionValue * 25.5m, 2),
                            DueDate = recordDate.AddDays(15),
                            BillMonth = recordDate.Month,
                            BillYear = recordDate.Year,
                            Status = i == 0 ? "Ödenmedi" : "Ödendi",
                            CreatedDate = recordDate
                        };
                        context.Bills.Add(bill);

                        if (bill.Status == "Ödendi")
                        {
                            context.Payments.Add(new Payment
                            {
                                Bill = bill,
                                Amount = bill.Amount,
                                PaymentDate = recordDate.AddDays(5),
                                PaymentMethod = "Kredi Kartı",
                                TransactionNo = "TRX-" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
                                ReceiptNumber = "REC-" + rand.Next(100000, 999999)
                            });
                        }
                    }
                    await context.SaveChangesAsync();
                }

                
                if (dogalgazService != null && !context.Subscriptions.Any(s => s.UserId == user.Id && s.ServiceTypeId == dogalgazService.Id))
                {
                    var subGaz = new Subscription
                    {
                        UserId = user.Id,
                        ServiceTypeId = dogalgazService.Id,
                        SubscriberNo = "DG-" + rand.Next(100000, 999999).ToString(),
                        MeterNumber = "MTR-" + rand.Next(100000, 999999).ToString(),
                        Address = user.Address ?? "Kadıköy, İstanbul",
                        IsActive = true,
                        CreatedDate = DateTime.Now.AddYears(-1)
                    };
                    context.Subscriptions.Add(subGaz);
                    await context.SaveChangesAsync();

                    
                    for (int i = 0; i < 6; i++)
                    {
                        var recordDate = DateTime.Now.AddMonths(-i);
                        var consumption = new ConsumptionRecord
                        {
                            SubscriptionId = subGaz.Id,
                            ConsumptionValue = 50.5m + (decimal)(rand.NextDouble() * 100),
                            RecordDate = recordDate
                        };
                        context.ConsumptionRecords.Add(consumption);

                        var bill = new Bill
                        {
                            SubscriptionId = subGaz.Id,
                            BillNo = $"FAT-{recordDate:yyyyMM}-DG-{rand.Next(1000, 9999)}",
                            Amount = Math.Round(consumption.ConsumptionValue * 6.5m, 2),
                            DueDate = recordDate.AddDays(15),
                            BillMonth = recordDate.Month,
                            BillYear = recordDate.Year,
                            Status = i == 0 ? "Ödenmedi" : "Ödendi",
                            CreatedDate = recordDate
                        };
                        context.Bills.Add(bill);
                        
                        if (bill.Status == "Ödendi")
                        {
                            context.Payments.Add(new Payment
                            {
                                Bill = bill,
                                Amount = bill.Amount,
                                PaymentDate = recordDate.AddDays(5),
                                PaymentMethod = "Kredi Kartı",
                                TransactionNo = "TRX-" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
                                ReceiptNumber = "REC-" + rand.Next(100000, 999999)
                            });
                        }
                    }
                    await context.SaveChangesAsync();
                }

                
                if (emlakService != null && !context.Subscriptions.Any(s => s.UserId == user.Id && s.ServiceTypeId == emlakService.Id))
                {
                    var subEmlak = new Subscription
                    {
                        UserId = user.Id,
                        ServiceTypeId = emlakService.Id,
                        SubscriberNo = "EV-" + rand.Next(100000, 999999).ToString(),
                        MeterNumber = "N/A",
                        Address = user.Address ?? "Kadıköy, İstanbul",
                        IsActive = true,
                        CreatedDate = DateTime.Now.AddYears(-1)
                    };
                    context.Subscriptions.Add(subEmlak);
                    await context.SaveChangesAsync();

                    for (int i = 0; i < 2; i++)
                    {
                        var recordDate = DateTime.Now.AddMonths(-i * 6);
                        var bill = new Bill
                        {
                            SubscriptionId = subEmlak.Id,
                            BillNo = $"FAT-{recordDate:yyyyMM}-EV-{rand.Next(1000, 9999)}",
                            Amount = 1250.00m + (decimal)rand.Next(100, 500),
                            DueDate = recordDate.AddDays(15),
                            BillMonth = recordDate.Month,
                            BillYear = recordDate.Year,
                            Status = i == 0 ? "Ödenmedi" : "Ödendi",
                            CreatedDate = recordDate
                        };
                        context.Bills.Add(bill);

                        if (bill.Status == "Ödendi")
                        {
                            context.Payments.Add(new Payment
                            {
                                Bill = bill,
                                Amount = bill.Amount,
                                PaymentDate = recordDate.AddDays(5),
                                PaymentMethod = "Kredi Kartı",
                                TransactionNo = "TRX-" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
                                ReceiptNumber = "REC-" + rand.Next(100000, 999999)
                            });
                        }
                    }
                    await context.SaveChangesAsync();
                }

                
                if (!context.Notifications.Any(n => n.UserId == user.Id))
                {
                    context.Notifications.AddRange(
                        new Notification { UserId = user.Id, Title = "Hoş Geldiniz", Message = "Akıllı Şehir Sistemine hoş geldiniz.", CreatedDate = DateTime.Now.AddDays(-10), IsRead = true, NotificationType = "System" },
                        new Notification { UserId = user.Id, Title = "Yeni Fatura", Message = "Bu aya ait faturalarınız kesilmiştir.", CreatedDate = DateTime.Now, IsRead = false, NotificationType = "Bill" }
                    );
                    await context.SaveChangesAsync();
                }
            }
        }

        private static void CreateStoredProcedures(ApplicationDbContext context)
        {
            var db = context.Database;

            
            db.ExecuteSqlRaw(@"
                IF OBJECT_ID('sp_GetDashboardStats', 'P') IS NOT NULL DROP PROCEDURE sp_GetDashboardStats");
            db.ExecuteSqlRaw(@"
                CREATE PROCEDURE sp_GetDashboardStats
                AS
                BEGIN
                    SELECT 
                        (SELECT COUNT(*) FROM AspNetUsers) AS TotalUsers,
                        (SELECT COUNT(*) FROM Complaints) AS TotalComplaints,
                        (SELECT COUNT(*) FROM Complaints WHERE StatusId = 1 OR StatusId = 2) AS PendingComplaints,
                        (SELECT COUNT(*) FROM Complaints WHERE StatusId = 3) AS ResolvedComplaints,
                        (SELECT COUNT(*) FROM Subscriptions WHERE IsActive = 1) AS ActiveSubscriptions,
                        (SELECT COUNT(*) FROM Subscriptions WHERE IsActive = 0) AS PassiveSubscriptions
                END");

            
            db.ExecuteSqlRaw(@"
                IF OBJECT_ID('sp_GetComplaintsByCategory', 'P') IS NOT NULL DROP PROCEDURE sp_GetComplaintsByCategory");
            db.ExecuteSqlRaw(@"
                CREATE PROCEDURE sp_GetComplaintsByCategory
                AS
                BEGIN
                    SELECT c.Name AS CategoryName, COUNT(p.Id) AS ComplaintCount
                    FROM ComplaintCategories c
                    LEFT JOIN Complaints p ON c.Id = p.CategoryId
                    GROUP BY c.Name
                END");

            
            db.ExecuteSqlRaw(@"
                IF OBJECT_ID('sp_GetComplaintsByDistrict', 'P') IS NOT NULL DROP PROCEDURE sp_GetComplaintsByDistrict");
            db.ExecuteSqlRaw(@"
                CREATE PROCEDURE sp_GetComplaintsByDistrict
                AS
                BEGIN
                    SELECT 
                        ISNULL(NULLIF(LTRIM(RTRIM(Address)), ''), 'Belirtilmemiş') AS District,
                        COUNT(*) AS ComplaintCount
                    FROM Complaints
                    GROUP BY ISNULL(NULLIF(LTRIM(RTRIM(Address)), ''), 'Belirtilmemiş')
                    ORDER BY ComplaintCount DESC
                END");

            
            db.ExecuteSqlRaw(@"
                IF OBJECT_ID('sp_GetComplaintsByStatus', 'P') IS NOT NULL DROP PROCEDURE sp_GetComplaintsByStatus");
            db.ExecuteSqlRaw(@"
                CREATE PROCEDURE sp_GetComplaintsByStatus
                AS
                BEGIN
                    SELECT s.Name AS StatusName, COUNT(c.Id) AS ComplaintCount
                    FROM ComplaintStatuses s
                    LEFT JOIN Complaints c ON s.Id = c.StatusId
                    GROUP BY s.Name
                END");

            
            db.ExecuteSqlRaw(@"
                IF OBJECT_ID('sp_GetMonthlyRevenue', 'P') IS NOT NULL DROP PROCEDURE sp_GetMonthlyRevenue");
            db.ExecuteSqlRaw(@"
                CREATE PROCEDURE sp_GetMonthlyRevenue
                AS
                BEGIN
                    SELECT 
                        MONTH(PaymentDate) AS MonthNum,
                        YEAR(PaymentDate) AS YearNum,
                        SUM(Amount) AS TotalRevenue
                    FROM Payments
                    GROUP BY YEAR(PaymentDate), MONTH(PaymentDate)
                    ORDER BY YearNum DESC, MonthNum DESC
                END");

            
            db.ExecuteSqlRaw(@"
                IF OBJECT_ID('sp_GetYearlyRevenue', 'P') IS NOT NULL DROP PROCEDURE sp_GetYearlyRevenue");
            db.ExecuteSqlRaw(@"
                CREATE PROCEDURE sp_GetYearlyRevenue
                AS
                BEGIN
                    SELECT 
                        YEAR(PaymentDate) AS YearNum,
                        SUM(Amount) AS TotalRevenue
                    FROM Payments
                    GROUP BY YEAR(PaymentDate)
                    ORDER BY YearNum DESC
                END");

            
            db.ExecuteSqlRaw(@"
                IF OBJECT_ID('sp_GetHeatMapData', 'P') IS NOT NULL DROP PROCEDURE sp_GetHeatMapData");
            db.ExecuteSqlRaw(@"
                CREATE PROCEDURE sp_GetHeatMapData
                AS
                BEGIN
                    SELECT c.Id, c.Title, c.Latitude, c.Longitude, c.Address,
                           s.Name AS StatusName
                    FROM Complaints c
                    LEFT JOIN ComplaintStatuses s ON c.StatusId = s.Id
                    WHERE c.Latitude <> 0 AND c.Longitude <> 0
                END");
        }
    }
}
