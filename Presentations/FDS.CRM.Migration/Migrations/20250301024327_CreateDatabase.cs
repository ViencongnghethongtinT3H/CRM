using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FDS.CRM.Migration.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdministrativeUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnglishFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnglishShortName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrativeUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommonSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsSensitive = table.Column<bool>(type: "bit", nullable: false),
                    SettingType = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataProtectionKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendlyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xml = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataProtectionKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ParentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentMethodName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pipelines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pipelines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PipelineStages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PipelineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Probability = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelineStages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuoteStatus = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentTermId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Tax = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TicketStatus = table.Column<int>(type: "int", nullable: false),
                    AssignedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PipelineStageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PipelineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ClosedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "province",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    english_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    english_full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    custom_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    administrative_unit_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_province", x => x.Id);
                    table.ForeignKey(
                        name: "FK_province_AdministrativeUnit_administrative_unit_id",
                        column: x => x.administrative_unit_id,
                        principalTable: "AdministrativeUnit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DepartmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    Auth0UserId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AzureAdB2CUserId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ColorAvatar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuoreRelations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelationshipType = table.Column<int>(type: "int", nullable: false),
                    QuotesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoreRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuoreRelations_Quotes_QuotesId",
                        column: x => x.QuotesId,
                        principalTable: "Quotes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    Vat = table.Column<int>(type: "int", nullable: false),
                    IsCheckInventoty = table.Column<bool>(type: "bit", nullable: false),
                    ProductUnit = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketRelations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelationshipType = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketRelations_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "district",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    province_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    province_id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    english_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    english_full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    custom_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    administrative_unit_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_district", x => x.Id);
                    table.ForeignKey(
                        name: "FK_district_AdministrativeUnit_administrative_unit_id",
                        column: x => x.administrative_unit_id,
                        principalTable: "AdministrativeUnit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_district_province_province_id",
                        column: x => x.province_id,
                        principalTable: "province",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActivityOwnerRelations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityType = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityOwnerRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityOwnerRelations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AnnualRevenue = table.Column<double>(type: "float", nullable: true),
                    NumberOfEmployees = table.Column<int>(type: "int", nullable: true),
                    CompanyOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndustryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyType = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PredictedRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PipelineStageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PipelineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DealType = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    RevenuePrediction = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deals_PipelineStages_PipelineStageId",
                        column: x => x.PipelineStageId,
                        principalTable: "PipelineStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deals_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PasswordHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasswordHistory_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TokenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TokenValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuoteItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuotesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuoteItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuoteItems_Quotes_QuotesId",
                        column: x => x.QuotesId,
                        principalTable: "Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ward",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    district_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    district_id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    english_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    english_full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    custom_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    administrative_unit_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ward", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ward_AdministrativeUnit_administrative_unit_id",
                        column: x => x.administrative_unit_id,
                        principalTable: "AdministrativeUnit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ward_district_district_id",
                        column: x => x.district_id,
                        principalTable: "district",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyRelations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelationshipType = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyRelations_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeadStatus = table.Column<int>(type: "int", nullable: false),
                    LifecycleStageEnum = table.Column<int>(type: "int", nullable: false),
                    CustomerSource = table.Column<int>(type: "int", nullable: false),
                    Industry = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CommonSettingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LeadScored = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_CommonSettings_CommonSettingId",
                        column: x => x.CommonSettingId,
                        principalTable: "CommonSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contacts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacts_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contacts_Users_ContactOwnerId",
                        column: x => x.ContactOwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DealRelations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelationshipType = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DealRelations_Deals_DealId",
                        column: x => x.DealId,
                        principalTable: "Deals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DealId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityType = table.Column<int>(type: "int", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    IsPinned = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Activities_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Activities_Deals_DealId",
                        column: x => x.DealId,
                        principalTable: "Deals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Activities_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WardId = table.Column<string>(type: "nvarchar(26)", nullable: true),
                    DistrictId = table.Column<string>(type: "nvarchar(26)", nullable: true),
                    ProvinceId = table.Column<string>(type: "nvarchar(26)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressType = table.Column<int>(type: "int", nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Address_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_district_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "district",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Address_province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "province",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Address_ward_WardId",
                        column: x => x.WardId,
                        principalTable: "ward",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AssociatedInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObjectReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssociatedInfoType = table.Column<int>(type: "int", nullable: false),
                    ObjectType = table.Column<int>(type: "int", nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociatedInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssociatedInfo_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContactRelations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RelationshipType = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactRelations_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderConfigs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllowPayment = table.Column<bool>(type: "bit", nullable: false),
                    SendEmailType = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderConfigs_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuyPaymentMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuyPaymentTermId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseTransactions_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseTransactions_Users_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityAppointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    IsAllDay = table.Column<bool>(type: "bit", maxLength: 500, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityStatus = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityAppointments_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityAppointments_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityCalls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CallDuration = table.Column<int>(type: "int", nullable: false),
                    CallResult = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityCalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityCalls_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityCalls_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityEmails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EmailTo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Bcc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityEmails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityEmails_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityNotes_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityReminders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationType = table.Column<int>(type: "int", nullable: false),
                    RemindAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSent = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityReminders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityReminders_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivitySms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmsStatus = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitySms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivitySms_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityTask",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityTaskType = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityTask_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderRelations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelationshipType = table.Column<int>(type: "int", nullable: false),
                    OrderConfigId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderRelations_OrderConfigs_OrderConfigId",
                        column: x => x.OrderConfigId,
                        principalTable: "OrderConfigs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CompanyId",
                table: "Activities",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ContactId",
                table: "Activities",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DealId",
                table: "Activities",
                column: "DealId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_OwnerId",
                table: "Activities",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityAppointments_ActivityId",
                table: "ActivityAppointments",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityAppointments_OwnerId",
                table: "ActivityAppointments",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityCalls_ActivityId",
                table: "ActivityCalls",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityCalls_OwnerId",
                table: "ActivityCalls",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityEmails_ActivityId",
                table: "ActivityEmails",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityNotes_ActivityId",
                table: "ActivityNotes",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityOwnerRelations_UserId",
                table: "ActivityOwnerRelations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityReminders_ActivityId",
                table: "ActivityReminders",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySms_ActivityId",
                table: "ActivitySms",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTask_ActivityId",
                table: "ActivityTask",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CompanyId",
                table: "Address",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ContactId",
                table: "Address",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_DistrictId",
                table: "Address",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ProvinceId",
                table: "Address",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_WardId",
                table: "Address",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_AssociatedInfo_ContactId",
                table: "AssociatedInfo",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_OwnerId",
                table: "Companies",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRelations_CompanyId",
                table: "CompanyRelations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactRelations_ContactId",
                table: "ContactRelations",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CommonSettingId",
                table: "Contacts",
                column: "CommonSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CompanyId",
                table: "Contacts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactOwnerId",
                table: "Contacts",
                column: "ContactOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_PositionId",
                table: "Contacts",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_DealRelations_DealId",
                table: "DealRelations",
                column: "DealId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_OwnerId",
                table: "Deals",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_PipelineStageId",
                table: "Deals",
                column: "PipelineStageId");

            migrationBuilder.CreateIndex(
                name: "IX_district_administrative_unit_id",
                table: "district",
                column: "administrative_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_district_province_id",
                table: "district",
                column: "province_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderConfigs_ContactId",
                table: "OrderConfigs",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRelations_OrderConfigId",
                table: "OrderRelations",
                column: "OrderConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordHistory_UserId",
                table: "PasswordHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_DepartmentID",
                table: "Positions",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_province_administrative_unit_id",
                table: "province",
                column: "administrative_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransactions_ContactId",
                table: "PurchaseTransactions",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransactions_SaleId",
                table: "PurchaseTransactions",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoreRelations_QuotesId",
                table: "QuoreRelations",
                column: "QuotesId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteItems_ProductId",
                table: "QuoteItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteItems_QuotesId",
                table: "QuoteItems",
                column: "QuotesId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketRelations_TicketId",
                table: "TicketRelations",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId",
                table: "UserTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ward_administrative_unit_id",
                table: "ward",
                column: "administrative_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_ward_district_id",
                table: "ward",
                column: "district_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityAppointments");

            migrationBuilder.DropTable(
                name: "ActivityCalls");

            migrationBuilder.DropTable(
                name: "ActivityEmails");

            migrationBuilder.DropTable(
                name: "ActivityNotes");

            migrationBuilder.DropTable(
                name: "ActivityOwnerRelations");

            migrationBuilder.DropTable(
                name: "ActivityReminders");

            migrationBuilder.DropTable(
                name: "ActivitySms");

            migrationBuilder.DropTable(
                name: "ActivityTask");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "AssociatedInfo");

            migrationBuilder.DropTable(
                name: "CompanyRelations");

            migrationBuilder.DropTable(
                name: "ContactRelations");

            migrationBuilder.DropTable(
                name: "DataProtectionKeys");

            migrationBuilder.DropTable(
                name: "DealRelations");

            migrationBuilder.DropTable(
                name: "OrderRelations");

            migrationBuilder.DropTable(
                name: "PasswordHistory");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Pipelines");

            migrationBuilder.DropTable(
                name: "PurchaseTransactions");

            migrationBuilder.DropTable(
                name: "QuoreRelations");

            migrationBuilder.DropTable(
                name: "QuoteItems");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "TicketRelations");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "ward");

            migrationBuilder.DropTable(
                name: "OrderConfigs");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Deals");

            migrationBuilder.DropTable(
                name: "district");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "PipelineStages");

            migrationBuilder.DropTable(
                name: "province");

            migrationBuilder.DropTable(
                name: "CommonSettings");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "AdministrativeUnit");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
