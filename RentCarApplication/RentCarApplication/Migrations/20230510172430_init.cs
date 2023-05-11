using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentCarApplication.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Km = table.Column<int>(type: "int", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfManufacture = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rent_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rent_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "22715bdd-ea6e-45a4-b5f1-17a56b79ca7b", "Customer", "CUSTOMER" },
                    { "2", "61929082-1e2c-4950-8d53-3e5c40a50495", "Employee", "EMPLOYEE" },
                    { "3", "e014cb20-e4e9-4d22-afed-f3d0fc837863", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb7", 0, "a056e274-b4a9-40bc-854f-c431a5d6c34e", "florin@gmail.com", true, true, null, "FLORIN@GMAIL.COM", "FLORIN", "AQAAAAEAACcQAAAAEO+rUSo/mS1V7L67CEZWoIUSr/JuHdEnVVHamT8iTL2Ttka0lqRtOS9WM2OZiBMKUA==", null, false, "48a50c30-0074-49bd-b8e3-8296daa96389", false, "Florin" },
                    { "9a27620-a44f-4543-9dk6-0993d048sia7", 0, "5625788d-f231-4591-98a2-38b1215ec8dd", "bogdan@gmail.com", true, true, null, "BOGDAN@GMAIL.COM", "BOGDAN", "AQAAAAEAACcQAAAAEOncLywomw9UObmg9l8JAcDpPLKObxbI+dK+NHJ9A9RQOidQVdyd8BydaaUgchVdRw==", null, false, "d9323393-f874-431f-b311-fd235b886a43", false, "Bogdan" },
                    { "9c44780-a24d-4543-9cc6-0993d048aacu7", 0, "70465eea-9591-4a02-8298-97eef3efb65c", "alin@gmail.com", true, true, null, "ALIN@GMAIL.COM", "ALIN", "AQAAAAEAACcQAAAAEBHc3eqs8HpsgYtpffHwUo/LiKtOakSNny7D10IAnDcgxDkNO+oK3w3c+RUCs+xSkw==", null, false, "b64f6ffe-7bfe-412c-95f3-0eb0210b8930", false, "Alin" }
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "Brand", "DateOfManufacture", "Km", "Price", "RegistrationNumber", "Type" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(2022, 6, 21, 1, 14, 14, 87, DateTimeKind.Local).AddTicks(1102), 131, 67, "6953PG3D2YTO49432", 1 },
                    { 2, 10, new DateTime(2022, 8, 30, 11, 16, 52, 254, DateTimeKind.Local).AddTicks(5874), 663, 99, "5J39QZ3KLPPM42935", 0 },
                    { 3, 2, new DateTime(2022, 9, 15, 17, 6, 56, 973, DateTimeKind.Local).AddTicks(1655), 356, 26, "6HIJ2XPFJ8I358524", 0 },
                    { 4, 3, new DateTime(2022, 7, 21, 4, 3, 40, 970, DateTimeKind.Local).AddTicks(9273), 975, 71, "JKTP6ZEDY8SM44881", 1 },
                    { 5, 10, new DateTime(2023, 3, 22, 21, 32, 20, 361, DateTimeKind.Local).AddTicks(7064), 645, 10, "21VKXPEII9PZ72371", 1 },
                    { 6, 7, new DateTime(2022, 7, 2, 10, 1, 0, 251, DateTimeKind.Local).AddTicks(4692), 753, 87, "ALT4MSEAXWFD98743", 1 },
                    { 7, 10, new DateTime(2022, 12, 13, 5, 36, 34, 665, DateTimeKind.Local).AddTicks(8824), 66, 77, "HJ2YE0YA1LGO85694", 1 },
                    { 8, 1, new DateTime(2022, 8, 21, 12, 40, 18, 909, DateTimeKind.Local).AddTicks(1331), 273, 34, "R038BM2OZTHR80740", 0 },
                    { 9, 0, new DateTime(2022, 8, 4, 22, 1, 42, 704, DateTimeKind.Local).AddTicks(4842), 206, 98, "7II96EUXFVBW55387", 1 },
                    { 10, 7, new DateTime(2022, 11, 22, 22, 45, 40, 536, DateTimeKind.Local).AddTicks(7320), 783, 89, "HG7IMIQKI6FX84258", 3 },
                    { 11, 2, new DateTime(2022, 11, 23, 1, 8, 0, 574, DateTimeKind.Local).AddTicks(9111), 117, 49, "C8YBXLFFQCAG38575", 2 },
                    { 12, 3, new DateTime(2022, 9, 18, 4, 43, 38, 134, DateTimeKind.Local).AddTicks(7449), 327, 60, "YNTCWRVU31YQ64406", 3 },
                    { 13, 6, new DateTime(2022, 8, 4, 15, 23, 29, 121, DateTimeKind.Local).AddTicks(6579), 125, 79, "GKPODHXSDUXH89312", 3 },
                    { 14, 8, new DateTime(2022, 11, 22, 4, 8, 10, 318, DateTimeKind.Local).AddTicks(9706), 628, 57, "J9HSE6496OJK57148", 2 },
                    { 15, 2, new DateTime(2022, 5, 17, 3, 24, 58, 385, DateTimeKind.Local).AddTicks(1), 714, 89, "ZOI7T2UFMSKI62273", 1 },
                    { 16, 3, new DateTime(2022, 10, 9, 7, 28, 12, 277, DateTimeKind.Local).AddTicks(9486), 795, 45, "007X7S5N09QV74878", 1 },
                    { 17, 9, new DateTime(2022, 10, 18, 20, 47, 48, 513, DateTimeKind.Local).AddTicks(7078), 636, 22, "2FVGLM1DGYGQ83838", 2 },
                    { 18, 9, new DateTime(2022, 12, 31, 7, 45, 39, 793, DateTimeKind.Local).AddTicks(6299), 865, 96, "7EA2VL1EUPW740255", 0 },
                    { 19, 11, new DateTime(2023, 2, 13, 17, 35, 11, 838, DateTimeKind.Local).AddTicks(655), 748, 18, "DAFMPHJL7GE985759", 0 },
                    { 20, 10, new DateTime(2023, 3, 24, 8, 54, 23, 459, DateTimeKind.Local).AddTicks(9337), 746, 96, "N4Q8NMOJMUB695778", 0 },
                    { 21, 2, new DateTime(2023, 1, 26, 14, 12, 40, 288, DateTimeKind.Local).AddTicks(1821), 928, 54, "XU4UI6F8DAHT52832", 2 },
                    { 22, 9, new DateTime(2023, 3, 6, 11, 34, 55, 967, DateTimeKind.Local).AddTicks(2828), 111, 95, "DUF29OA3SJXH99664", 2 },
                    { 23, 6, new DateTime(2022, 7, 13, 7, 34, 42, 977, DateTimeKind.Local).AddTicks(3883), 176, 64, "CIKJSBB0HLVB64874", 3 },
                    { 24, 3, new DateTime(2022, 8, 29, 11, 55, 46, 884, DateTimeKind.Local).AddTicks(3168), 501, 64, "IYA2JXVYSMKU74792", 2 },
                    { 25, 11, new DateTime(2022, 11, 22, 8, 22, 35, 652, DateTimeKind.Local).AddTicks(231), 123, 98, "H2FY31WCU1UM36177", 0 },
                    { 26, 8, new DateTime(2022, 7, 16, 14, 48, 46, 690, DateTimeKind.Local).AddTicks(6905), 603, 14, "AZIGQIQTHGDU41956", 2 },
                    { 27, 9, new DateTime(2022, 7, 22, 15, 13, 6, 645, DateTimeKind.Local).AddTicks(9735), 532, 4, "KIRKY1A8J7H538409", 1 },
                    { 28, 1, new DateTime(2023, 1, 22, 1, 14, 58, 684, DateTimeKind.Local).AddTicks(4384), 297, 69, "IDFMLDB0DEED49099", 1 },
                    { 29, 1, new DateTime(2022, 10, 8, 23, 18, 46, 804, DateTimeKind.Local).AddTicks(7132), 403, 38, "GD82URW9XEVL85978", 2 },
                    { 30, 9, new DateTime(2022, 7, 8, 14, 43, 8, 375, DateTimeKind.Local).AddTicks(8141), 336, 55, "I085KIYQAWCL15424", 3 },
                    { 31, 6, new DateTime(2022, 7, 11, 11, 47, 28, 384, DateTimeKind.Local).AddTicks(3568), 329, 50, "8TGWPP28W1E756001", 2 },
                    { 32, 0, new DateTime(2022, 7, 2, 19, 59, 28, 502, DateTimeKind.Local).AddTicks(668), 491, 82, "CDDJA2M4FGLQ45089", 1 },
                    { 33, 10, new DateTime(2022, 12, 30, 8, 45, 24, 878, DateTimeKind.Local).AddTicks(95), 339, 27, "VUHWPHPPR4KX66590", 2 },
                    { 34, 9, new DateTime(2022, 5, 15, 21, 25, 34, 260, DateTimeKind.Local).AddTicks(6869), 568, 75, "0Q4OL8R3RWCP98033", 2 },
                    { 35, 10, new DateTime(2023, 1, 11, 21, 9, 56, 993, DateTimeKind.Local).AddTicks(6134), 849, 99, "T87ON8XMXMIX80152", 3 },
                    { 36, 1, new DateTime(2023, 2, 10, 1, 46, 39, 4, DateTimeKind.Local).AddTicks(3101), 645, 13, "83YAFZ3A5OF517540", 2 }
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "Brand", "DateOfManufacture", "Km", "Price", "RegistrationNumber", "Type" },
                values: new object[,]
                {
                    { 37, 9, new DateTime(2023, 1, 25, 12, 26, 21, 6, DateTimeKind.Local).AddTicks(7635), 188, 45, "DFIOE7E7RPOA21210", 3 },
                    { 38, 3, new DateTime(2022, 7, 15, 12, 13, 47, 820, DateTimeKind.Local).AddTicks(5943), 799, 72, "RO7SH8CMFCIK47237", 3 },
                    { 39, 7, new DateTime(2022, 9, 5, 9, 20, 40, 236, DateTimeKind.Local).AddTicks(9977), 569, 54, "2DSJKWD5P9FX87796", 2 },
                    { 40, 5, new DateTime(2022, 11, 24, 15, 8, 19, 510, DateTimeKind.Local).AddTicks(5231), 640, 8, "MVF0WL2VOYXA38937", 0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "8e445865-a24d-4543-a6c6-9443d048cdb7" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3", "9a27620-a44f-4543-9dk6-0993d048sia7" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2", "9c44780-a24d-4543-9cc6-0993d048aacu7" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rent_CarId",
                table: "Rent",
                column: "CarId",
                unique: true,
                filter: "[CarId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Rent_UserId",
                table: "Rent",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Rent");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Car");
        }
    }
}
