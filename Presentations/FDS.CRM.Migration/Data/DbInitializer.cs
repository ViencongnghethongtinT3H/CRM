using Bogus;
using FDS.CRM.Domain.Entities;
using FDS.CRM.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FDS.CRM.Domain.Enums;

namespace FDS.CRM.Migration.Data;

public static class DbInitializer
{
    private static readonly string DefaultPassword = "Abc@123";
    private static readonly PasswordHasher<User> PasswordHasher = new();
    private static readonly Faker Faker = new("vi");

    public static async Task Initialize(CrmDbContext context, ILogger<CrmDbContext> logger)
    {
        try
        {
            await context.Database.MigrateAsync();
            // Changed order: CommonSetting -> Department -> Position (with Department) -> Roles -> Users -> UserRoles -> Pipelines -> PipelineStages -> Companies -> Contacts -> Addresses
            await SeedCommonSettings(context, logger);
            var departments = await SeedDepartments(context, logger);
            await SeedPositions(context, departments, logger);
            var roles = await SeedRoles(context, logger);
            var users = await SeedUsers(context, departments, logger);
            await SeedUserRoles(context, users, roles, logger);
            var pipelines = await SeedPipelines(context, logger);
            await SeedPipelineStages(context, pipelines, logger);
            var companies = await SeedCompanies(context, users, logger);
            var contacts = await SeedContacts(context, users, companies, logger);
            var paymentTerms = await SeedPaymentTerms(context, logger);
            var paymentMethods = await SeedPaymentMethods(context, logger);
            await SeedPurchaseTransactions(context, contacts, paymentMethods, paymentTerms, users, logger);
            await SeedAddresses(context, contacts, companies, logger);
            await SeedActivities(context, contacts, companies, users, logger);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    private static async Task SeedCommonSettings(CrmDbContext context, ILogger<CrmDbContext> logger)
    {
        if (await context.CommonSettings.AnyAsync())
            return;

        logger.LogInformation("Seeding common settings...");
        var settings = new List<CommonSetting>
        {
            new() {
               
                Name = "Industry",
                Value = "Tài chính",
                Description = "Lĩnh vực tài chính",
                CreatedDateTime = DateTime.Now,
                UserNameCreated = "System",
                IsDeleted = false,
                SettingType = Domain.Enums.SettingType.Industry
            },
            new() {

                Name = "Industry",
                Value = "CNTT",
                Description = "Lĩnh vực CNTT",
                CreatedDateTime = DateTime.Now,
                UserNameCreated = "System",
                IsDeleted = false,
                SettingType = Domain.Enums.SettingType.Industry
            },
            new() {

                Name = "Industry",
                Value = "Giáo dục",
                Description = "Lĩnh vực giáo dục",
                CreatedDateTime = DateTime.Now,
                UserNameCreated = "System",
                IsDeleted = false,
                SettingType = Domain.Enums.SettingType.Industry
            },
            new() {

                Name = "Industry",
                Value = "Xây dưng dân dụng",
                Description = "Lĩnh vực Xây dưng dân dụng",
                CreatedDateTime = DateTime.Now,
                UserNameCreated = "System",
                IsDeleted = false,
                SettingType = Domain.Enums.SettingType.Industry
            },
             new() {

                Name = "Industry",
                Value = "Kỹ thuật cơ khí",
                Description = "Lĩnh vực  Kỹ thuật cơ khí",
                CreatedDateTime = DateTime.Now,
                UserNameCreated = "System",
                IsDeleted = false,
                SettingType = Domain.Enums.SettingType.Industry
            },
             new() {

                Name = "Industry",
                Value = "Kỹ thuật điện",
                Description = "Lĩnh vực  Kỹ thuật cơ khí",
                CreatedDateTime = DateTime.Now,
                UserNameCreated = "System",
                IsDeleted = false,
                SettingType = Domain.Enums.SettingType.Industry
            }
        };

        await context.CommonSettings.AddRangeAsync(settings);
        await context.SaveChangesAsync();
    }

    private static async Task<List<Department>> SeedDepartments(CrmDbContext context, ILogger<CrmDbContext> logger)
    {
        if (await context.Departments.AnyAsync())
            return await context.Departments.ToListAsync();

        logger.LogInformation("Seeding departments...");
        var departments = new List<Department>
        {
            CreateDepartment("Ban giám đốc", "BGD", "Điều hành công ty"),
            CreateDepartment("Phòng Hành chính", "HC", "Quản lý hành chính"),
            CreateDepartment("Phòng Nhân sự", "NS", "Quản lý nhân sự"),
            CreateDepartment("Phòng Kế toán", "KT", "Quản lý tài chính"),
            CreateDepartment("Phòng Kinh doanh", "KD", "Phát triển kinh doanh"),
            CreateDepartment("Phòng Kỹ thuật", "KT", "Phát triển sản phẩm")
        };

        await context.Departments.AddRangeAsync(departments);
        await context.SaveChangesAsync();
        return departments;
    }

    private static async Task SeedPositions(CrmDbContext context, List<Department> departments, ILogger<CrmDbContext> logger)
    {
        if (await context.Positions.AnyAsync())
            return;

        logger.LogInformation("Seeding positions...");
        var positions = new List<Position>();

        // Seed positions for each department
        foreach (var dept in departments)
        {
            positions.AddRange(new[]
            {
                CreatePosition("Giám đốc", "Quản lý cao cấp", dept.Id),
                CreatePosition("Trưởng phòng", "Quản lý phòng ban", dept.Id),
                CreatePosition("Phó phòng", "Phó quản lý phòng ban", dept.Id),
                CreatePosition("Nhân viên", "Nhân viên chính thức", dept.Id),
                CreatePosition("Thực tập sinh", "Nhân viên thử việc", dept.Id)
            });
        }

        await context.Positions.AddRangeAsync(positions);
        await context.SaveChangesAsync();
    }

    private static async Task<List<Role>> SeedRoles(CrmDbContext context, ILogger<CrmDbContext> logger)
    {
        if (await context.Roles.AnyAsync())
            return await context.Roles.ToListAsync();

        logger.LogInformation("Seeding roles...");
        var roles = new List<Role>
        {
            new Role { Name = "SuperAdmin", ConcurrencyStamp = Guid.NewGuid().ToString(), NormalizedName = "SuperAdmin", CreatedDateTime = DateTime.Now, UserNameCreated = "System", IsDeleted = false },
            new Role { Name = "Admin", ConcurrencyStamp = Guid.NewGuid().ToString(), NormalizedName = "Admin", CreatedDateTime = DateTime.Now, UserNameCreated = "System", IsDeleted = false },
            new Role { Name = "Manager",ConcurrencyStamp = Guid.NewGuid().ToString(), NormalizedName = "Manager", CreatedDateTime = DateTime.Now, UserNameCreated = "System", IsDeleted = false },
            new Role { Name = "Employee",ConcurrencyStamp = Guid.NewGuid().ToString(), NormalizedName = "Employee", CreatedDateTime = DateTime.Now, UserNameCreated = "System", IsDeleted = false },
            new Role { Name = "Sales", ConcurrencyStamp = Guid.NewGuid().ToString(), NormalizedName = "Sales", CreatedDateTime = DateTime.Now, UserNameCreated = "System", IsDeleted = false },
            new Role { Name = "Marketing",ConcurrencyStamp = Guid.NewGuid().ToString(), NormalizedName = "Marketing", CreatedDateTime = DateTime.Now, UserNameCreated = "System", IsDeleted = false }
        };

        await context.Roles.AddRangeAsync(roles);
        await context.SaveChangesAsync();
        return roles;
    }

    private static async Task<List<User>> SeedUsers(CrmDbContext context, List<Department> departments, ILogger<CrmDbContext> logger)
    {
        if (await context.Users.AnyAsync())
            return await context.Users.ToListAsync();

        logger.LogInformation("Seeding users...");
        var users = new List<User> { CreateAdminUser(departments[0].Id) }; // Admin thuộc Ban giám đốc
        users.AddRange(CreateManagerUsers(departments.Skip(1).ToList())); // Mỗi manager cho một phòng còn lại

        await context.Users.AddRangeAsync(users);
        await context.SaveChangesAsync();
        return users;
    }

    private static async Task SeedUserRoles(CrmDbContext context, List<User> users, List<Role> roles, ILogger<CrmDbContext> logger)
    {
        if (await context.UserRoles.AnyAsync())
            return;

        logger.LogInformation("Seeding user roles...");
        var userRoles = new List<UserRole>();
        {
            new UserRole { UserId = users[0].Id, RoleId = roles.First(r => r.Name == "SuperAdmin").Id };
        };

        for (int i = 1; i < users.Count; i++)
        {
            userRoles.Add(new UserRole{ UserId = users[i].Id, RoleId = roles.First(r => r.Name == "Manager").Id }); // Các manager là Manager
        }

        await context.UserRoles.AddRangeAsync(userRoles);
        await context.SaveChangesAsync();
    }

    private static async Task<List<Pipeline>> SeedPipelines(CrmDbContext context, ILogger<CrmDbContext> logger)
    {
        if (await context.Pipelines.AnyAsync())
            return await context.Pipelines.ToListAsync();

        logger.LogInformation("Seeding pipelines...");
        var pipelines = new List<Pipeline>
        {
            new Pipeline
            {
                Name = "Quy trình bán hàng",
                Description = "Quy trình bán hàng chuẩn cho sản phẩm mới",
                CreatedDateTime = DateTime.Now,
                UserNameCreated = "System",
                IsDeleted = false
            },
            new Pipeline
            {
                Name = "Quy trình chăm sóc khách hàng",
                Description = "Quy trình theo dõi và chăm sóc khách hàng",
                CreatedDateTime = DateTime.Now,
                UserNameCreated = "System",
                IsDeleted = false
            },
            new Pipeline
            {
                Name = "Quy trình tư vấn giải pháp",
                Description = "Quy trình tư vấn giải pháp cho khách hàng doanh nghiệp",
                CreatedDateTime = DateTime.Now,
                UserNameCreated = "System",
                IsDeleted = false
            }
        };

        await context.Pipelines.AddRangeAsync(pipelines);
        await context.SaveChangesAsync();
        return pipelines;
    }

    private static async Task SeedPipelineStages(CrmDbContext context, List<Pipeline> pipelines, ILogger<CrmDbContext> logger)
    {
        if (await context.PipelineStages.AnyAsync())
            return;

        logger.LogInformation("Seeding pipeline stages...");
        var stages = new List<PipelineStage>
        {
            // Các giai đoạn cho quy trình bán hàng
            new PipelineStage { Name = "Cơ hội mới", Sort = 1, PipelineId = pipelines[0].Id, Description = "Bước đầu tiếp cận khách hàng tiềm năng", UserNameCreated = "System", IsDeleted = false },
            new PipelineStage { Name = "Đã đánh giá chất lượng", Sort = 2, PipelineId = pipelines[0].Id, Description = "Tìm hiểu và đánh giá nhu cầu khách hàng", UserNameCreated = "System", IsDeleted = false },
            new PipelineStage { Name = "Đàm Phán", Sort = 3, PipelineId = pipelines[0].Id, Description = "Đề xuất giải pháp phù hợp", UserNameCreated = "System", IsDeleted = false },
            new PipelineStage { Name = "Cơ hội thắng", Sort = 4, PipelineId = pipelines[0].Id, Description = "Thương lượng về giá cả và điều khoản", UserNameCreated = "System", IsDeleted = false },
            new PipelineStage { Name = "Cơ hội thất bại", Sort = 5, PipelineId = pipelines[0].Id, Description = "Hoàn tất thương vụ", UserNameCreated = "System", IsDeleted = false },

            // Các giai đoạn cho quy trình chăm sóc khách hàng
            new PipelineStage { Name = "Mới", Sort = 1, PipelineId = pipelines[1].Id, Description = "Tiếp nhận yêu cầu hỗ trợ từ khách hàng", UserNameCreated = "System", IsDeleted = false },
            new PipelineStage { Name = "Đang xử lý", Sort = 2, PipelineId = pipelines[1].Id, Description = "Phân loại và đánh giá mức độ ưu tiên", UserNameCreated = "System", IsDeleted = false },
            new PipelineStage { Name = "Đã xử lý", Sort = 3, PipelineId = pipelines[1].Id, Description = "Tiến hành xử lý yêu cầu của khách hàng", UserNameCreated = "System", IsDeleted = false },
            new PipelineStage { Name = "Đã hủy", Sort = 4, PipelineId = pipelines[1].Id, Description = "Theo dõi và đánh giá kết quả xử lý", UserNameCreated = "System", IsDeleted = false },
            new PipelineStage { Name = "Tạm dừng", Sort = 5, PipelineId = pipelines[1].Id, Description = "Theo dõi và đánh giá kết quả xử lý", UserNameCreated = "System", IsDeleted = false },
        };

        await context.PipelineStages.AddRangeAsync(stages);
        await context.SaveChangesAsync();
    }

    private static async Task<List<Company>> SeedCompanies(CrmDbContext context, List<User> users, ILogger<CrmDbContext> logger)
    {
        if (await context.Companies.AnyAsync())
            return await context.Companies.ToListAsync();

        logger.LogInformation("Seeding companies...");

        var industries = await context.CommonSettings
            .Where(cs => cs.SettingType == Domain.Enums.SettingType.Industry)
            .ToListAsync();

        var companies = new List<Company>();
        var faker = new Faker("vi");

        for (int i = 0; i < 20; i++)
        {
            var company = Company.Create(
                name: faker.Company.CompanyName(),
                description: faker.Company.CatchPhrase(),
                website: faker.Internet.Url(),
                taxCode: faker.Random.Number(1000000000, 999999999).ToString(),
                annualRevenue: faker.Random.Double(100000000, 1000000000),
                numberOfEmployees: faker.Random.Number(10, 1000),
                companyOwnerId: null,
                industryId: faker.PickRandom(industries).Id,
                companyType: faker.PickRandom<CompanyType>(),
                ownerId: faker.PickRandom(users).Id
            );

            company.CreatedDateTime = DateTime.Now;
            company.UserNameCreated = "System";
            company.IsDeleted = false;

            companies.Add(company);
        }

        await context.Companies.AddRangeAsync(companies);
        await context.SaveChangesAsync();
        return companies;
    }

    private static async Task<List<Contact>> SeedContacts(CrmDbContext context, List<User> users, List<Company> companies, ILogger<CrmDbContext> logger)
    {
        if (await context.Contacts.AnyAsync())
            return await context.Contacts.ToListAsync();

        logger.LogInformation("Seeding contacts...");

        var positions = await context.Positions.ToListAsync();
        var industries = await context.CommonSettings
            .Where(cs => cs.SettingType == Domain.Enums.SettingType.Industry)
            .ToListAsync();

        var contacts = new List<Contact>();
        var faker = new Faker("vi");

        foreach (var company in companies)
        {
            // Create 2-5 contacts for each company
            var numContacts = faker.Random.Number(2, 5);
            for (int i = 0; i < numContacts; i++)
            {
                var name = faker.Name.FullName();
                var code = $"CT{faker.Random.Number(10000, 99999)}";
                var contact = Contact.Create(
                    name: name,
                    code: code,
                    contactOwnerId: faker.PickRandom(users).Id,
                    positionId: faker.PickRandom(positions).Id,
                    leadStatus: faker.PickRandom<LeadStatusEnum>(),
                    lifecycleStageEnum: faker.PickRandom<LifecycleStageEnum>(),
                    customerSource: faker.PickRandom<CustomerSource>(),
                    companyId: company.Id,
                    industry: faker.PickRandom(industries).Id,
                    leadScored: faker.Random.Number(0, 100),
                    avatar: CrossCuttingConcerns.Helper.StringHelpers.GetRandomColor()
                );

                // Set audit fields
                contact.CreatedDateTime = DateTime.Now;
                contact.UserNameCreated = "System";
                contact.IsDeleted = false;

                contacts.Add(contact);
            }
        }

        await context.Contacts.AddRangeAsync(contacts);
        await context.SaveChangesAsync();
        return contacts;
    }

    private static async Task SeedAddresses(CrmDbContext context, List<Contact> contacts, List<Company> companies, ILogger<CrmDbContext> logger)
    {
        if (await context.Address.AnyAsync()) // Sửa Address thành Addresses
            return;

        logger.LogInformation("Seeding addresses...");

        var addresses = new List<Address>();
        var faker = new Faker("vi");

        foreach (var company in companies)
        {
            var address = await CreateRandomAddress(context, faker, AddressType.ContactAddress, null, company.Id);
            if (address != null)
            {
                addresses.Add(address);
            }
        }

        foreach (var contact in contacts)
        {
            var address = await CreateRandomAddress(context, faker, AddressType.ShippingAddress, contact.Id, null);
            if (address != null)
            {
                addresses.Add(address);
            }
        }

        if (addresses.Any())
        {
            await context.Address.AddRangeAsync(addresses);
            await context.SaveChangesAsync();
        }
    }

    private static async Task<Address?> CreateRandomAddress(CrmDbContext context, Faker faker, AddressType addressType, Guid? contactId, Guid? companyId)
    {
        var province = await context.Provinces
            .Include(p => p.Districts)
                .ThenInclude(d => d.Wards)
            .OrderBy(r => Guid.NewGuid())
            .FirstOrDefaultAsync();
        
        if (province == null) return null;

        var district = province.Districts.OrderBy(r => Guid.NewGuid()).FirstOrDefault();
        if (district == null) return null;

        var ward = district.Wards.OrderBy(r => Guid.NewGuid()).FirstOrDefault();
        if (ward == null) return null;

        return Address.Create(
            addressName: $"{faker.Address.StreetAddress()}",
            country: "Việt Nam",
            addressType: addressType,
            contactId: contactId,
            companyId: companyId,
            wardId: ward.Id,
            districtId: district.Id,
            provinceId: province.Id
        );
    }

    private static async Task<List<PaymentTerm>> SeedPaymentTerms(CrmDbContext context, ILogger<CrmDbContext> logger)
    {
        if (await context.PaymentTerms.AnyAsync())
            return await context.PaymentTerms.ToListAsync();

        logger.LogInformation("Seeding payment terms...");
        var paymentTerms = new List<PaymentTerm>
        {
            PaymentTerm.Create("Thanh toán ngay", 1),
            PaymentTerm.Create("Thanh toán trong vòng 15 ngày", 2),
            PaymentTerm.Create("Thanh toán trong vòng 30 ngày", 3),
            PaymentTerm.Create("Thanh toán trong vòng 45 ngày", 4),
            PaymentTerm.Create("Thanh toán trong vòng 60 ngày", 5)
        };

        foreach (var term in paymentTerms)
        {
            term.CreatedDateTime = DateTime.Now;
            term.UserNameCreated = "System";
            term.IsDeleted = false;
        }

        await context.PaymentTerms.AddRangeAsync(paymentTerms);
        await context.SaveChangesAsync();
        return paymentTerms;
    }

    private static async Task<List<PaymentMethod>> SeedPaymentMethods(CrmDbContext context, ILogger<CrmDbContext> logger)
    {
        if (await context.PaymentMethods.AnyAsync())
            return await context.PaymentMethods.ToListAsync();

        logger.LogInformation("Seeding payment methods...");
        var paymentMethods = new List<PaymentMethod>
        {
            PaymentMethod.Create(
                "Tiền mặt",
                "Thanh toán trực tiếp bằng tiền mặt"
            ),
            PaymentMethod.Create(
                "Chuyển khoản ngân hàng",
                "Chuyển khoản qua tài khoản ngân hàng"
            ),
            PaymentMethod.Create(
                "Ví MoMo",
                "Thanh toán qua ví điện tử MoMo"
            ),
            PaymentMethod.Create(
                "VNPay",
                "Thanh toán qua cổng thanh toán VNPay"
            ),
            PaymentMethod.Create(
                "Thẻ tín dụng",
                "Thanh toán bằng thẻ Visa/Master/JCB"
            )
        };      

        await context.PaymentMethods.AddRangeAsync(paymentMethods);
        await context.SaveChangesAsync();
        return paymentMethods;
    }

    private static async Task SeedPurchaseTransactions(CrmDbContext context, List<Contact> contacts, 
        List<PaymentMethod> paymentMethods, List<PaymentTerm> paymentTerms, List<User> users, ILogger<CrmDbContext> logger)
    {
        if (await context.PurchaseTransactions.AnyAsync())
            return;

        logger.LogInformation("Seeding purchase transactions...");
        var faker = new Faker("vi");
        var transactions = new List<PurchaseTransaction>();

        // Create 1-3 transactions for each contact
        foreach (var contact in contacts)
        {
            var transactionCount = faker.Random.Number(1, 3);
            for (int i = 0; i < transactionCount; i++)
            {
                var transaction = PurchaseTransaction.Create(
                    contactId: contact.Id,
                    buyPaymentMethodId: faker.PickRandom(paymentMethods).Id,
                    buyPaymentTermId: faker.PickRandom(paymentTerms).Id,
                    saleId: faker.PickRandom(users).Id
                );             

                transactions.Add(transaction);
            }
        }

        await context.PurchaseTransactions.AddRangeAsync(transactions);
        await context.SaveChangesAsync();
    }

    private static async Task SeedActivities(CrmDbContext context, List<Contact> contacts, 
        List<Company> companies, List<User> users, ILogger<CrmDbContext> logger)
    {
        if (await context.Activities.AnyAsync())
            return;

        logger.LogInformation("Seeding activities...");
        var activities = new List<Activity>();
        var activityAppointments = new List<ActivityAppointment>();
        var activityCalls = new List<ActivityCall>();
        var activityNotes = new List<ActivityNote>();
        var activityReminders = new List<ActivityReminder>();
        var activityTasks = new List<ActivityTask>();
        var activitySms = new List<ActivitySms>();

        foreach (var contact in contacts.Take(10))
        {
            // Cuộc hẹn
            var appointmentActivity = Activity.Create(
                $"Hẹn gặp khách hàng {contact.Name}",
                contact.ContactOwnerId.Value,
                ActivityType.Appointment,
                contact.Id
            );
            activities.Add(appointmentActivity);

            var appointment = ActivityAppointment.Create(
                appointmentActivity.Id,
                $"Trao đổi về hợp đồng mới với khách hàng {contact.Name}",
                false,
                "Văn phòng công ty",
                DateTime.Now.AddDays(Faker.Random.Number(1, 7)),
                DateTime.Now.AddDays(Faker.Random.Number(1, 7)).AddHours(2),
                ActivityStatus.Inprogress
            );
            activityAppointments.Add(appointment);

            // Cuộc gọi
            var callActivity = Activity.Create(
                $"Gọi điện cho {contact.Name}",
                contact.ContactOwnerId.Value,
                ActivityType.Call,
                contact.Id
            );
            activities.Add(callActivity);

            var call = ActivityCall.Create(
                callActivity.Id,
                Faker.Random.Number(5, 30),
                "Khách hàng quan tâm đến sản phẩm và đồng ý sắp xếp cuộc hẹn"
            );
            activityCalls.Add(call);

            // Ghi chú
            var noteActivity = Activity.Create(
                $"Ghi chú về {contact.Name}",
                contact.ContactOwnerId.Value,
                ActivityType.Note,
                contact.Id
            );
            activities.Add(noteActivity);

            var note = ActivityNote.Create(
                noteActivity.Id,
                $"Khách hàng {contact.Name} có nhu cầu về giải pháp phần mềm quản lý. Cần theo dõi và chăm sóc thường xuyên."
            );
            activityNotes.Add(note);

            // Nhắc nhở
            var reminderActivity = Activity.Create(
                $"Nhắc nhở theo dõi {contact.Name}",
                contact.ContactOwnerId.Value,
                ActivityType.Note,
                contact.Id
            );
            activities.Add(reminderActivity);

            var reminder = ActivityReminder.Create(
                reminderActivity.Id,
                reminderActivity.Id,
                NotificationType.Email,
                DateTime.Now.AddDays(7),
                $"Đến hạn theo dõi và liên hệ lại với khách hàng {contact.Name}"
            );
            activityReminders.Add(reminder);

            // Task
            var taskActivity = Activity.Create(
                $"Công việc liên quan đến {contact.Name}",
                contact.ContactOwnerId.Value,
                ActivityType.Task,
                contact.Id
            );
            activities.Add(taskActivity);

            var task = ActivityTask.Create(
                taskActivity.Id,
                $"Chuẩn bị tài liệu demo và báo giá cho khách hàng {contact.Name}",
                Priority.High,
                null,
                DateTime.Now.AddDays(3),
                ActivityTaskType.DemoProduct
            );
            activityTasks.Add(task);

            // SMS
            var smsActivity = Activity.Create(
                $"Gửi SMS cho {contact.Name}",
                contact.ContactOwnerId.Value,
                ActivityType.SMS,
                contact.Id
            );
            activities.Add(smsActivity);

            var sms = ActivitySms.Create(
                smsActivity.Id,
                $"Kính gửi {contact.Name}, FDS trân trọng thông báo lịch demo sản phẩm vào lúc 14h ngày mai. Xin vui lòng xác nhận tham dự.",
                contact.User?.PhoneNumber ?? "0900000000",
                DateTime.Now,
                SmsStatus.Delivered
            );
            activitySms.Add(sms);
        }

        foreach (var item in activities)
        {
            item.CreatedDateTime = DateTime.Now;
            item.UserNameCreated = "System";
            item.IsDeleted = false;
        }

        await context.Activities.AddRangeAsync(activities);
        await context.ActivityAppointments.AddRangeAsync(activityAppointments);
        await context.ActivityCalls.AddRangeAsync(activityCalls);
        await context.ActivityNotes.AddRangeAsync(activityNotes);
        await context.ActivityReminders.AddRangeAsync(activityReminders);
        await context.ActivityTasks.AddRangeAsync(activityTasks);
        await context.ActivitySms.AddRangeAsync(activitySms);
        await context.SaveChangesAsync();
    }

    #region Helper Methods

    private static Position CreatePosition(string name, string description, Guid departmentId) => new()
    {        
        Title = name,
        Description = description,
        DepartmentID = departmentId,
        CreatedDateTime = DateTime.Now,
        UserNameCreated = "System",
        IsDeleted = false
    };

    private static Department CreateDepartment(string name, string code, string description) => new()
    {
        Name = name,        
        Description = description,
        CreatedDateTime = DateTime.Now,
        UserNameCreated = "System",
        IsDeleted = false
    };

    private static User CreateAdminUser(Guid departmentId)
    {
        var user = new User
        {           
            UserName = "admin",
            Email = "admin@system.com",
            FullName = "System Administrator",
            PhoneNumber = "0900000000",
            DepartmentId = departmentId,
            CreatedDateTime = DateTime.Now,
            UserNameCreated = "System",
            IsDeleted = false,
            SecurityStamp = Guid.NewGuid().ToString(),
            NormalizedEmail = "ADMIN@SYSTEM.COM",
            NormalizedUserName = "ADMIN",
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            AzureAdB2CUserId = "System",
            ColorAvatar = CrossCuttingConcerns.Helper.StringHelpers.GetRandomColor()
        };
        user.PasswordHash = PasswordHasher.HashPassword(user, DefaultPassword);
        return user;
    }

    private static List<User> CreateManagerUsers(List<Department> departments) =>
        departments.Select(dept => CreateManagerUser(dept.Id)).ToList();

    private static User CreateManagerUser(Guid departmentId)
    {
        var user = new User
        {
           
            UserName = Faker.Internet.UserName(),
            Email = Faker.Internet.Email(),
            FullName = Faker.Name.FullName(),
            PhoneNumber = Faker.Phone.PhoneNumber("0#########"),
            DepartmentId = departmentId,
            CreatedDateTime = DateTime.Now,
            UserNameCreated = "System",
            IsDeleted = false,
            SecurityStamp = Guid.NewGuid().ToString(),
            NormalizedEmail = Faker.Internet.Email().ToUpper(),
            NormalizedUserName = Faker.Internet.UserName().ToUpper(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            AzureAdB2CUserId = "System",
            ColorAvatar = CrossCuttingConcerns.Helper.StringHelpers.GetRandomColor()
        };
        user.PasswordHash = PasswordHasher.HashPassword(user, DefaultPassword);
        return user;
    }

    #endregion
}
