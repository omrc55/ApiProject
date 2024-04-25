using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BtkApiProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CreatedDate", "Description", "IsApproved", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("18130346-e1b7-41d9-ba97-8e414d50457e"), new DateTime(2023, 10, 3, 4, 16, 23, 874, DateTimeKind.Local).AddTicks(1776), "Çorba totam doloremque gördüm layıkıyla molestiae nesciunt.", false, false, "Film", null },
                    { new Guid("18e74e76-934f-4c06-b3ce-643c87c6dcfd"), new DateTime(2024, 4, 13, 13, 4, 4, 734, DateTimeKind.Local).AddTicks(1438), "Gülüyorum quis değirmeni sit ona yaptı gül.", false, false, "Giyim", null },
                    { new Guid("34b395e8-4e60-4e13-9ea9-043c0f10852d"), new DateTime(2023, 8, 4, 18, 40, 35, 812, DateTimeKind.Local).AddTicks(4530), "Dolore biber ut ullam exercitationem kulu quaerat.", false, false, "Müzik", null },
                    { new Guid("80c7de02-40f8-4c82-bd90-212560c06949"), new DateTime(2023, 9, 29, 3, 38, 49, 416, DateTimeKind.Local).AddTicks(9825), "Makinesi ama qui nesciunt consequatur qui cezbelendi makinesi quia tv.", false, false, "Oyun", null },
                    { new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 8, 4, 0, 42, 23, 158, DateTimeKind.Local).AddTicks(550), "Quasi çıktılar eaque.", false, false, "Elektronik", null },
                    { new Guid("95b499c4-34a7-48a2-ac44-bc096de3fc66"), new DateTime(2023, 12, 31, 5, 50, 1, 162, DateTimeKind.Local).AddTicks(6626), "Voluptatem magni voluptatem eve kulu telefonu ışık ea ki aut.", false, false, "Spor", null },
                    { new Guid("b9066e07-91f7-44bb-a30b-7122aa190ecc"), new DateTime(2023, 8, 13, 10, 1, 37, 850, DateTimeKind.Local).AddTicks(5769), "Architecto blanditiis sıradanlıktan.", false, false, "Aksesuar", null },
                    { new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 9, 5, 10, 20, 9, 552, DateTimeKind.Local).AddTicks(3244), "Koyun patlıcan sıla et bilgisayarı sit cezbelendi makinesi.", false, false, "Sanat", null },
                    { new Guid("dd868916-dcde-465f-a89c-313a24d230c6"), new DateTime(2023, 10, 24, 22, 25, 19, 358, DateTimeKind.Local).AddTicks(7304), "Qui düşünüyor et voluptate gördüm ut domates.", false, false, "Kitap", null },
                    { new Guid("eba86dbf-a17a-45e5-bcbf-6aa599af3be1"), new DateTime(2024, 3, 15, 5, 52, 33, 595, DateTimeKind.Local).AddTicks(4450), "Quasi quis laudantium alias autem.", false, false, "Mobilya", null }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "CreatedDate", "IsApproved", "IsDeleted", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("09118505-491b-46cd-b154-2f523567c531"), new DateTime(2024, 1, 31, 22, 38, 6, 696, DateTimeKind.Local).AddTicks(3718), false, false, null },
                    { new Guid("18130346-e1b7-41d9-ba97-8e414d50457e"), new DateTime(2024, 2, 29, 17, 6, 54, 0, DateTimeKind.Local).AddTicks(3796), false, false, null },
                    { new Guid("18e74e76-934f-4c06-b3ce-643c87c6dcfd"), new DateTime(2023, 12, 2, 12, 33, 31, 8, DateTimeKind.Local).AddTicks(8033), false, false, null },
                    { new Guid("34b395e8-4e60-4e13-9ea9-043c0f10852d"), new DateTime(2023, 10, 22, 7, 36, 44, 740, DateTimeKind.Local).AddTicks(7953), false, false, null },
                    { new Guid("4804fa42-5494-4cb0-8c17-f23731b0135d"), new DateTime(2023, 10, 23, 6, 8, 39, 696, DateTimeKind.Local).AddTicks(988), false, false, null },
                    { new Guid("80c7de02-40f8-4c82-bd90-212560c06949"), new DateTime(2024, 2, 2, 15, 20, 31, 667, DateTimeKind.Local).AddTicks(2369), false, false, null },
                    { new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 9, 18, 18, 37, 50, 650, DateTimeKind.Local).AddTicks(2497), false, false, null },
                    { new Guid("9072edf5-43e9-45d6-a04e-60e552ac8b57"), new DateTime(2024, 3, 13, 8, 22, 54, 884, DateTimeKind.Local).AddTicks(4121), false, false, null },
                    { new Guid("95b499c4-34a7-48a2-ac44-bc096de3fc66"), new DateTime(2023, 8, 2, 5, 44, 23, 122, DateTimeKind.Local).AddTicks(1078), false, false, null },
                    { new Guid("a5d13a52-2dc3-4167-8b8c-4c446844898b"), new DateTime(2024, 3, 28, 11, 1, 22, 437, DateTimeKind.Local).AddTicks(8788), false, false, null },
                    { new Guid("b9066e07-91f7-44bb-a30b-7122aa190ecc"), new DateTime(2024, 4, 10, 2, 2, 14, 119, DateTimeKind.Local).AddTicks(9737), false, false, null },
                    { new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 11, 14, 2, 23, 7, 554, DateTimeKind.Local).AddTicks(8928), false, false, null },
                    { new Guid("dd868916-dcde-465f-a89c-313a24d230c6"), new DateTime(2023, 11, 6, 13, 22, 14, 650, DateTimeKind.Local).AddTicks(1149), false, false, null },
                    { new Guid("eba86dbf-a17a-45e5-bcbf-6aa599af3be1"), new DateTime(2023, 9, 24, 5, 53, 11, 806, DateTimeKind.Local).AddTicks(1471), false, false, null },
                    { new Guid("ef773918-5fff-4c25-84cd-f58b43442e21"), new DateTime(2024, 2, 13, 0, 58, 57, 854, DateTimeKind.Local).AddTicks(9647), false, false, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "CreatedDate", "Description", "IsApproved", "IsDeleted", "Name", "Price", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("065bdc51-a618-45a1-90d7-567ef3843841"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2024, 1, 13, 5, 29, 19, 859, DateTimeKind.Local).AddTicks(2650), "Adresini ut beğendim domates minima bilgiyasayarı explicabo aut.", false, false, "Gorgeous Concrete Bike", 106.0, null },
                    { new Guid("09118505-491b-46cd-b154-2f523567c531"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 7, 27, 14, 28, 49, 502, DateTimeKind.Local).AddTicks(5431), "Minima corporis tv gazete et yazın rem non praesentium dağılımı.", false, false, "Handmade Soft Fish", 451.0, null },
                    { new Guid("0d210c85-5f4c-43a6-bcc2-a9546e99601b"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2024, 4, 9, 16, 19, 26, 961, DateTimeKind.Local).AddTicks(3722), "Sinema aut laboriosam koşuyorlar non.", false, false, "Sleek Metal Sausages", 95.0, null },
                    { new Guid("18130346-e1b7-41d9-ba97-8e414d50457e"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2024, 2, 23, 19, 6, 57, 939, DateTimeKind.Local).AddTicks(8737), "Eos deleniti mıknatıslı qui gitti dolorem türemiş.", false, false, "Handmade Metal Pants", 134.0, null },
                    { new Guid("18e74e76-934f-4c06-b3ce-643c87c6dcfd"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 8, 31, 23, 22, 1, 280, DateTimeKind.Local).AddTicks(9890), "Voluptas qui iure amet aut totam doğru.", false, false, "Tasty Concrete Bike", 381.0, null },
                    { new Guid("1cbbd6f1-b054-44ed-805f-920a998aff90"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 11, 5, 23, 2, 30, 542, DateTimeKind.Local).AddTicks(2371), "Yaptı neque sit dicta in illo yaptı architecto dicta.", false, false, "Handmade Concrete Computer", 182.0, null },
                    { new Guid("2993cc3b-48d8-4c3a-8662-9ae328688c9c"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 5, 11, 20, 10, 5, 842, DateTimeKind.Local).AddTicks(2074), "Sokaklarda teldeki kulu dışarı ut öyle doloremque çakıl.", false, false, "Generic Rubber Bike", 328.0, null },
                    { new Guid("32a39a39-0d03-4569-8908-8f0fbd483c65"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2024, 3, 7, 9, 3, 10, 764, DateTimeKind.Local).AddTicks(6078), "Karşıdakine makinesi göze orta modi incidunt türemiş suscipit magni masaya.", false, false, "Handmade Soft Pants", 347.0, null },
                    { new Guid("34b395e8-4e60-4e13-9ea9-043c0f10852d"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2024, 4, 11, 4, 17, 19, 873, DateTimeKind.Local).AddTicks(8438), "Gazete sıfat makinesi mıknatıslı.", false, false, "Sleek Wooden Shirt", 247.0, null },
                    { new Guid("3500e840-e254-4823-90fc-7a8789df67f6"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 9, 6, 12, 47, 5, 790, DateTimeKind.Local).AddTicks(7916), "Et orta için çorba ullam enim ea eius kulu.", false, false, "Ergonomic Soft Towels", 326.0, null },
                    { new Guid("35677582-d7f7-4230-ab73-35d5fdc19a1b"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 6, 28, 5, 49, 47, 994, DateTimeKind.Local).AddTicks(6330), "Ut blanditiis beatae.", false, false, "Small Steel Pants", 74.0, null },
                    { new Guid("388e1e08-a7bd-4552-97c8-b7c0f7b80f11"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 6, 30, 14, 37, 49, 300, DateTimeKind.Local).AddTicks(4760), "Domates et voluptatem şafak consequatur.", false, false, "Gorgeous Cotton Sausages", 219.0, null },
                    { new Guid("3e20bea6-3150-4551-8698-c93bcc384a09"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 6, 13, 17, 58, 0, 737, DateTimeKind.Local).AddTicks(9935), "Olduğu ve ea inventore et minima çobanın çobanın.", false, false, "Incredible Rubber Bike", 130.0, null },
                    { new Guid("4804fa42-5494-4cb0-8c17-f23731b0135d"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 10, 2, 13, 31, 44, 694, DateTimeKind.Local).AddTicks(6595), "Labore gül ötekinden sinema ışık quam aspernatur doloremque.", false, false, "Small Concrete Tuna", 273.0, null },
                    { new Guid("54b58cfa-5b5e-4b2a-88cd-67e340ac758d"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 9, 10, 7, 56, 29, 84, DateTimeKind.Local).AddTicks(9941), "Magnam sıla quia sunt quam anlamsız laboriosam çorba.", false, false, "Ergonomic Concrete Pants", 432.0, null },
                    { new Guid("57fb9bbb-aa3e-4791-94b7-80ea4883613b"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2024, 1, 9, 5, 30, 59, 910, DateTimeKind.Local).AddTicks(3274), "Consequatur esse quam iusto yazın salladı.", false, false, "Sleek Fresh Car", 224.0, null },
                    { new Guid("5e5589fe-77d8-49d2-9bbb-d1a42cba0bf1"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 10, 3, 9, 44, 59, 518, DateTimeKind.Local).AddTicks(3781), "Commodi lambadaki ea magni.", false, false, "Sleek Frozen Car", 275.0, null },
                    { new Guid("5f6ac016-ec06-4c35-8f74-164c3e0724d3"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 7, 31, 3, 51, 18, 232, DateTimeKind.Local).AddTicks(5459), "Mutlu quia et yaptı kalemi.", false, false, "Intelligent Frozen Shirt", 379.0, null },
                    { new Guid("61d00226-a54f-43e4-b94f-ebd81c7acfb0"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 9, 7, 4, 21, 16, 582, DateTimeKind.Local).AddTicks(978), "Quia corporis labore patlıcan ex dolore aliquid voluptatum türemiş consequatur.", false, false, "Handcrafted Frozen Bacon", 185.0, null },
                    { new Guid("61f5f234-13df-4b8e-8558-cccd9b84aab0"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 9, 14, 12, 6, 20, 839, DateTimeKind.Local).AddTicks(4555), "Accusantium nostrum biber aut hesap kapının.", false, false, "Rustic Metal Chips", 35.0, null },
                    { new Guid("65e02ef9-a536-4c6a-9f18-1c6dd9af4fd6"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 11, 7, 2, 48, 53, 304, DateTimeKind.Local).AddTicks(3568), "Yazın sinema koşuyorlar okuma umut neque ad ratione mi.", false, false, "Handcrafted Concrete Car", 58.0, null },
                    { new Guid("6d776c03-bd8a-4ed4-965d-92bd5d196380"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 5, 29, 3, 16, 42, 115, DateTimeKind.Local).AddTicks(8220), "Mıknatıslı quia lambadaki sevindi eius esse sit adanaya.", false, false, "Fantastic Fresh Computer", 279.0, null },
                    { new Guid("7532d41d-4ec0-4c29-9864-25d1e936ccec"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 7, 1, 22, 16, 30, 887, DateTimeKind.Local).AddTicks(9900), "Sit dignissimos sinema tempora autem.", false, false, "Small Frozen Bacon", 495.0, null },
                    { new Guid("7cd76b2b-197a-4ba2-98e1-430b8fd23038"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 10, 11, 18, 45, 25, 806, DateTimeKind.Local).AddTicks(8243), "Değerli teldeki ducimus sed dolor ki kutusu.", false, false, "Unbranded Steel Keyboard", 373.0, null },
                    { new Guid("80c7de02-40f8-4c82-bd90-212560c06949"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2024, 1, 24, 21, 56, 33, 830, DateTimeKind.Local).AddTicks(2584), "Neque duyulmamış için düşünüyor sıradanlıktan ekşili corporis enim.", false, false, "Gorgeous Soft Bike", 466.0, null },
                    { new Guid("866ea2a9-8721-4251-8022-ad988bd22b8c"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2024, 1, 27, 11, 25, 21, 651, DateTimeKind.Local).AddTicks(4650), "Öyle karşıdakine sevindi umut ekşili voluptate voluptate labore.", false, false, "Refined Soft Tuna", 440.0, null },
                    { new Guid("8c4b66b6-8fea-4330-be08-5e548e473a7b"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 5, 2, 22, 53, 45, 550, DateTimeKind.Local).AddTicks(9454), "Dağılımı quia vitae.", false, false, "Tasty Wooden Pants", 492.0, null },
                    { new Guid("8df428ba-1d69-45b8-8d40-40e235c957aa"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 8, 31, 7, 49, 47, 323, DateTimeKind.Local).AddTicks(6910), "Lambadaki sinema ipsum karşıdakine.", false, false, "Handcrafted Cotton Ball", 219.0, null },
                    { new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 11, 26, 19, 55, 50, 439, DateTimeKind.Local).AddTicks(9076), "Gülüyorum et ötekinden et.", false, false, "Handcrafted Metal Shoes", 340.0, null },
                    { new Guid("9072edf5-43e9-45d6-a04e-60e552ac8b57"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 8, 25, 12, 21, 35, 442, DateTimeKind.Local).AddTicks(8785), "Değirmeni eaque gül.", false, false, "Intelligent Granite Table", 147.0, null },
                    { new Guid("95b499c4-34a7-48a2-ac44-bc096de3fc66"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 12, 25, 18, 7, 42, 725, DateTimeKind.Local).AddTicks(5092), "Odio salladı için gidecekmiş gitti.", false, false, "Generic Frozen Fish", 333.0, null },
                    { new Guid("96b78027-3570-45bd-8d74-cdaa23c181b8"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2024, 1, 14, 2, 4, 36, 70, DateTimeKind.Local).AddTicks(4708), "Sıfat quis çobanın.", false, false, "Small Metal Pizza", 409.0, null },
                    { new Guid("99bd8cd0-f4c4-403a-b678-a3c233ed9f7e"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 10, 25, 13, 21, 9, 279, DateTimeKind.Local).AddTicks(4396), "Aspernatur odit için patlıcan aperiam exercitationem aperiam odio.", false, false, "Handmade Frozen Chicken", 290.0, null },
                    { new Guid("9a5c8eee-dfa0-4aee-8e39-c7f34bf24367"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 7, 25, 21, 51, 50, 734, DateTimeKind.Local).AddTicks(3467), "Veniam ducimus sit architecto koştum aut sandalye dicta dolorem.", false, false, "Rustic Metal Bike", 170.0, null },
                    { new Guid("a5d13a52-2dc3-4167-8b8c-4c446844898b"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 5, 11, 21, 49, 0, 877, DateTimeKind.Local).AddTicks(38), "Çorba incidunt voluptatem sit kalemi duyulmamış esse cesurca voluptate.", false, false, "Unbranded Wooden Bacon", 145.0, null },
                    { new Guid("b9066e07-91f7-44bb-a30b-7122aa190ecc"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 12, 11, 20, 44, 12, 584, DateTimeKind.Local).AddTicks(6318), "Voluptatem explicabo nemo lakin gül yazın masaya ut.", false, false, "Small Steel Car", 20.0, null },
                    { new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2024, 4, 3, 15, 34, 33, 72, DateTimeKind.Local).AddTicks(5608), "Doğru filmini enim fugit.", false, false, "Refined Rubber Cheese", 172.0, null },
                    { new Guid("c66915b3-d9f8-4bb6-bd46-828e5a946a61"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 4, 28, 20, 0, 46, 574, DateTimeKind.Local).AddTicks(2027), "Bundan balıkhaneye ipsam tv.", false, false, "Handmade Cotton Shoes", 394.0, null },
                    { new Guid("cb35d17f-0bdb-4237-9cd9-27e6f436cdc4"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2024, 3, 23, 11, 30, 38, 296, DateTimeKind.Local).AddTicks(7040), "Nihil architecto in consequatur ut.", false, false, "Refined Frozen Car", 367.0, null },
                    { new Guid("cd2460aa-cf15-4e44-954a-7f7c4c4e5a4e"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2024, 3, 29, 6, 4, 31, 59, DateTimeKind.Local).AddTicks(256), "Aut reprehenderit dolore çakıl.", false, false, "Refined Cotton Car", 121.0, null },
                    { new Guid("d11c7b91-2e92-4109-9d55-29adc4506f4f"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2024, 3, 2, 12, 24, 9, 273, DateTimeKind.Local).AddTicks(4713), "Adipisci sequi lakin consectetur.", false, false, "Ergonomic Fresh Chair", 311.0, null },
                    { new Guid("d369c607-b40a-4375-a39b-53287b41aabb"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 12, 21, 19, 8, 38, 840, DateTimeKind.Local).AddTicks(2936), "Aut anlamsız koştum modi.", false, false, "Gorgeous Cotton Bacon", 391.0, null },
                    { new Guid("dd868916-dcde-465f-a89c-313a24d230c6"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 5, 23, 5, 16, 19, 351, DateTimeKind.Local).AddTicks(9581), "Koyun ipsum nisi nemo kalemi gazete nostrum aut.", false, false, "Fantastic Granite Pants", 7.0, null },
                    { new Guid("de22d097-5f6c-42bc-947d-5ada70509533"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 6, 6, 19, 22, 17, 143, DateTimeKind.Local).AddTicks(9697), "Ki sequi dolore yapacakmış.", false, false, "Fantastic Soft Cheese", 24.0, null },
                    { new Guid("dfbcdf14-bd61-4f63-847a-969b0c517f12"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 12, 2, 18, 2, 3, 249, DateTimeKind.Local).AddTicks(3858), "Velit reprehenderit okuma iusto öyle teldeki karşıdakine ducimus bilgiyasayarı.", false, false, "Awesome Fresh Chair", 105.0, null },
                    { new Guid("eac29877-cf98-49b2-b092-dabde42b829e"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 10, 24, 7, 45, 9, 258, DateTimeKind.Local).AddTicks(6704), "Blanditiis voluptatem et molestiae sayfası aut.", false, false, "Incredible Plastic Mouse", 127.0, null },
                    { new Guid("eba86dbf-a17a-45e5-bcbf-6aa599af3be1"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 10, 1, 11, 6, 41, 25, DateTimeKind.Local).AddTicks(5057), "Explicabo velit sit incidunt alias göze architecto yapacakmış.", false, false, "Handcrafted Concrete Ball", 487.0, null },
                    { new Guid("ef773918-5fff-4c25-84cd-f58b43442e21"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2024, 3, 15, 0, 4, 0, 186, DateTimeKind.Local).AddTicks(2388), "Yaptı commodi sunt.", false, false, "Intelligent Steel Chicken", 53.0, null },
                    { new Guid("f2cd9efc-1bdb-48ad-ad51-13bb4daff119"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 6, 14, 2, 31, 8, 22, DateTimeKind.Local).AddTicks(3156), "Quaerat magnam layıkıyla patlıcan qui nesciunt amet şafak.", false, false, "Sleek Fresh Computer", 180.0, null },
                    { new Guid("fefc43b4-97a8-4713-8071-51930f12cb76"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2024, 1, 4, 17, 14, 15, 14, DateTimeKind.Local).AddTicks(9050), "Aperiam sed beğendim telefonu inventore illo koyun.", false, false, "Incredible Wooden Fish", 382.0, null }
                });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderID", "ProductID" },
                values: new object[,]
                {
                    { new Guid("09118505-491b-46cd-b154-2f523567c531"), new Guid("d11c7b91-2e92-4109-9d55-29adc4506f4f") },
                    { new Guid("09118505-491b-46cd-b154-2f523567c531"), new Guid("dfbcdf14-bd61-4f63-847a-969b0c517f12") },
                    { new Guid("18130346-e1b7-41d9-ba97-8e414d50457e"), new Guid("18e74e76-934f-4c06-b3ce-643c87c6dcfd") },
                    { new Guid("18130346-e1b7-41d9-ba97-8e414d50457e"), new Guid("b9066e07-91f7-44bb-a30b-7122aa190ecc") },
                    { new Guid("18e74e76-934f-4c06-b3ce-643c87c6dcfd"), new Guid("34b395e8-4e60-4e13-9ea9-043c0f10852d") },
                    { new Guid("18e74e76-934f-4c06-b3ce-643c87c6dcfd"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b") },
                    { new Guid("34b395e8-4e60-4e13-9ea9-043c0f10852d"), new Guid("3e20bea6-3150-4551-8698-c93bcc384a09") },
                    { new Guid("34b395e8-4e60-4e13-9ea9-043c0f10852d"), new Guid("61d00226-a54f-43e4-b94f-ebd81c7acfb0") },
                    { new Guid("4804fa42-5494-4cb0-8c17-f23731b0135d"), new Guid("32a39a39-0d03-4569-8908-8f0fbd483c65") },
                    { new Guid("4804fa42-5494-4cb0-8c17-f23731b0135d"), new Guid("54b58cfa-5b5e-4b2a-88cd-67e340ac758d") },
                    { new Guid("80c7de02-40f8-4c82-bd90-212560c06949"), new Guid("09118505-491b-46cd-b154-2f523567c531") },
                    { new Guid("80c7de02-40f8-4c82-bd90-212560c06949"), new Guid("5e5589fe-77d8-49d2-9bbb-d1a42cba0bf1") },
                    { new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new Guid("18130346-e1b7-41d9-ba97-8e414d50457e") },
                    { new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new Guid("95b499c4-34a7-48a2-ac44-bc096de3fc66") },
                    { new Guid("9072edf5-43e9-45d6-a04e-60e552ac8b57"), new Guid("3500e840-e254-4823-90fc-7a8789df67f6") },
                    { new Guid("9072edf5-43e9-45d6-a04e-60e552ac8b57"), new Guid("866ea2a9-8721-4251-8022-ad988bd22b8c") },
                    { new Guid("95b499c4-34a7-48a2-ac44-bc096de3fc66"), new Guid("80c7de02-40f8-4c82-bd90-212560c06949") },
                    { new Guid("95b499c4-34a7-48a2-ac44-bc096de3fc66"), new Guid("eba86dbf-a17a-45e5-bcbf-6aa599af3be1") },
                    { new Guid("a5d13a52-2dc3-4167-8b8c-4c446844898b"), new Guid("2993cc3b-48d8-4c3a-8662-9ae328688c9c") },
                    { new Guid("a5d13a52-2dc3-4167-8b8c-4c446844898b"), new Guid("8df428ba-1d69-45b8-8d40-40e235c957aa") },
                    { new Guid("b9066e07-91f7-44bb-a30b-7122aa190ecc"), new Guid("4804fa42-5494-4cb0-8c17-f23731b0135d") },
                    { new Guid("b9066e07-91f7-44bb-a30b-7122aa190ecc"), new Guid("ef773918-5fff-4c25-84cd-f58b43442e21") },
                    { new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new Guid("9a5c8eee-dfa0-4aee-8e39-c7f34bf24367") },
                    { new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new Guid("fefc43b4-97a8-4713-8071-51930f12cb76") },
                    { new Guid("dd868916-dcde-465f-a89c-313a24d230c6"), new Guid("8ed24296-d7a3-438b-be89-358a6186a06b") },
                    { new Guid("dd868916-dcde-465f-a89c-313a24d230c6"), new Guid("dd868916-dcde-465f-a89c-313a24d230c6") },
                    { new Guid("eba86dbf-a17a-45e5-bcbf-6aa599af3be1"), new Guid("9072edf5-43e9-45d6-a04e-60e552ac8b57") },
                    { new Guid("eba86dbf-a17a-45e5-bcbf-6aa599af3be1"), new Guid("a5d13a52-2dc3-4167-8b8c-4c446844898b") },
                    { new Guid("ef773918-5fff-4c25-84cd-f58b43442e21"), new Guid("0d210c85-5f4c-43a6-bcc2-a9546e99601b") },
                    { new Guid("ef773918-5fff-4c25-84cd-f58b43442e21"), new Guid("eac29877-cf98-49b2-b092-dabde42b829e") }
                });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "ID", "CreatedDate", "IsApproved", "IsDeleted", "ProductID", "Quantity", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("065bdc51-a618-45a1-90d7-567ef3843841"), new DateTime(2023, 5, 18, 22, 53, 54, 827, DateTimeKind.Local).AddTicks(1037), false, false, new Guid("065bdc51-a618-45a1-90d7-567ef3843841"), 17, null },
                    { new Guid("09118505-491b-46cd-b154-2f523567c531"), new DateTime(2023, 11, 12, 12, 3, 9, 690, DateTimeKind.Local).AddTicks(2751), false, false, new Guid("09118505-491b-46cd-b154-2f523567c531"), 41, null },
                    { new Guid("0d210c85-5f4c-43a6-bcc2-a9546e99601b"), new DateTime(2023, 11, 19, 3, 21, 44, 744, DateTimeKind.Local).AddTicks(2416), false, false, new Guid("0d210c85-5f4c-43a6-bcc2-a9546e99601b"), 23, null },
                    { new Guid("18130346-e1b7-41d9-ba97-8e414d50457e"), new DateTime(2024, 3, 17, 14, 37, 33, 561, DateTimeKind.Local).AddTicks(3692), false, false, new Guid("18130346-e1b7-41d9-ba97-8e414d50457e"), 18, null },
                    { new Guid("18e74e76-934f-4c06-b3ce-643c87c6dcfd"), new DateTime(2023, 4, 30, 12, 26, 36, 675, DateTimeKind.Local).AddTicks(5488), false, false, new Guid("18e74e76-934f-4c06-b3ce-643c87c6dcfd"), 34, null },
                    { new Guid("1cbbd6f1-b054-44ed-805f-920a998aff90"), new DateTime(2023, 5, 22, 8, 47, 59, 383, DateTimeKind.Local).AddTicks(1948), false, false, new Guid("1cbbd6f1-b054-44ed-805f-920a998aff90"), 12, null },
                    { new Guid("2993cc3b-48d8-4c3a-8662-9ae328688c9c"), new DateTime(2024, 2, 20, 6, 11, 49, 105, DateTimeKind.Local).AddTicks(7716), false, false, new Guid("2993cc3b-48d8-4c3a-8662-9ae328688c9c"), 43, null },
                    { new Guid("32a39a39-0d03-4569-8908-8f0fbd483c65"), new DateTime(2023, 6, 16, 15, 8, 55, 451, DateTimeKind.Local).AddTicks(9473), false, false, new Guid("32a39a39-0d03-4569-8908-8f0fbd483c65"), 11, null },
                    { new Guid("34b395e8-4e60-4e13-9ea9-043c0f10852d"), new DateTime(2023, 8, 7, 14, 16, 38, 169, DateTimeKind.Local).AddTicks(6546), false, false, new Guid("34b395e8-4e60-4e13-9ea9-043c0f10852d"), 49, null },
                    { new Guid("3500e840-e254-4823-90fc-7a8789df67f6"), new DateTime(2024, 1, 13, 10, 27, 42, 582, DateTimeKind.Local).AddTicks(9489), false, false, new Guid("3500e840-e254-4823-90fc-7a8789df67f6"), 2, null },
                    { new Guid("35677582-d7f7-4230-ab73-35d5fdc19a1b"), new DateTime(2023, 9, 26, 23, 15, 44, 377, DateTimeKind.Local).AddTicks(7717), false, false, new Guid("35677582-d7f7-4230-ab73-35d5fdc19a1b"), 15, null },
                    { new Guid("388e1e08-a7bd-4552-97c8-b7c0f7b80f11"), new DateTime(2024, 3, 19, 13, 26, 14, 740, DateTimeKind.Local).AddTicks(3660), false, false, new Guid("388e1e08-a7bd-4552-97c8-b7c0f7b80f11"), 13, null },
                    { new Guid("3e20bea6-3150-4551-8698-c93bcc384a09"), new DateTime(2023, 12, 6, 16, 54, 18, 891, DateTimeKind.Local).AddTicks(2721), false, false, new Guid("3e20bea6-3150-4551-8698-c93bcc384a09"), 35, null },
                    { new Guid("4804fa42-5494-4cb0-8c17-f23731b0135d"), new DateTime(2023, 9, 10, 20, 9, 16, 942, DateTimeKind.Local).AddTicks(3441), false, false, new Guid("4804fa42-5494-4cb0-8c17-f23731b0135d"), 50, null },
                    { new Guid("54b58cfa-5b5e-4b2a-88cd-67e340ac758d"), new DateTime(2023, 8, 24, 14, 45, 39, 377, DateTimeKind.Local).AddTicks(3414), false, false, new Guid("54b58cfa-5b5e-4b2a-88cd-67e340ac758d"), 17, null },
                    { new Guid("57fb9bbb-aa3e-4791-94b7-80ea4883613b"), new DateTime(2023, 12, 21, 18, 17, 49, 636, DateTimeKind.Local).AddTicks(8288), false, false, new Guid("57fb9bbb-aa3e-4791-94b7-80ea4883613b"), 3, null },
                    { new Guid("5e5589fe-77d8-49d2-9bbb-d1a42cba0bf1"), new DateTime(2023, 8, 16, 4, 49, 55, 481, DateTimeKind.Local).AddTicks(8014), false, false, new Guid("5e5589fe-77d8-49d2-9bbb-d1a42cba0bf1"), 22, null },
                    { new Guid("5f6ac016-ec06-4c35-8f74-164c3e0724d3"), new DateTime(2023, 9, 10, 19, 43, 47, 969, DateTimeKind.Local).AddTicks(740), false, false, new Guid("5f6ac016-ec06-4c35-8f74-164c3e0724d3"), 1, null },
                    { new Guid("61d00226-a54f-43e4-b94f-ebd81c7acfb0"), new DateTime(2023, 5, 26, 4, 59, 17, 832, DateTimeKind.Local).AddTicks(6720), false, false, new Guid("61d00226-a54f-43e4-b94f-ebd81c7acfb0"), 23, null },
                    { new Guid("61f5f234-13df-4b8e-8558-cccd9b84aab0"), new DateTime(2023, 9, 28, 19, 34, 10, 848, DateTimeKind.Local).AddTicks(6339), false, false, new Guid("61f5f234-13df-4b8e-8558-cccd9b84aab0"), 7, null },
                    { new Guid("65e02ef9-a536-4c6a-9f18-1c6dd9af4fd6"), new DateTime(2023, 5, 5, 15, 50, 27, 583, DateTimeKind.Local).AddTicks(5125), false, false, new Guid("65e02ef9-a536-4c6a-9f18-1c6dd9af4fd6"), 6, null },
                    { new Guid("6d776c03-bd8a-4ed4-965d-92bd5d196380"), new DateTime(2024, 2, 2, 2, 42, 49, 499, DateTimeKind.Local).AddTicks(4043), false, false, new Guid("6d776c03-bd8a-4ed4-965d-92bd5d196380"), 49, null },
                    { new Guid("7532d41d-4ec0-4c29-9864-25d1e936ccec"), new DateTime(2024, 3, 19, 5, 47, 21, 334, DateTimeKind.Local).AddTicks(5236), false, false, new Guid("7532d41d-4ec0-4c29-9864-25d1e936ccec"), 9, null },
                    { new Guid("7cd76b2b-197a-4ba2-98e1-430b8fd23038"), new DateTime(2024, 3, 7, 20, 19, 33, 968, DateTimeKind.Local).AddTicks(114), false, false, new Guid("7cd76b2b-197a-4ba2-98e1-430b8fd23038"), 6, null },
                    { new Guid("80c7de02-40f8-4c82-bd90-212560c06949"), new DateTime(2023, 10, 15, 13, 1, 16, 571, DateTimeKind.Local).AddTicks(8412), false, false, new Guid("80c7de02-40f8-4c82-bd90-212560c06949"), 47, null },
                    { new Guid("866ea2a9-8721-4251-8022-ad988bd22b8c"), new DateTime(2024, 2, 6, 11, 54, 38, 568, DateTimeKind.Local).AddTicks(9959), false, false, new Guid("866ea2a9-8721-4251-8022-ad988bd22b8c"), 29, null },
                    { new Guid("8c4b66b6-8fea-4330-be08-5e548e473a7b"), new DateTime(2023, 9, 18, 22, 37, 49, 440, DateTimeKind.Local).AddTicks(4914), false, false, new Guid("8c4b66b6-8fea-4330-be08-5e548e473a7b"), 30, null },
                    { new Guid("8df428ba-1d69-45b8-8d40-40e235c957aa"), new DateTime(2024, 3, 2, 6, 56, 11, 136, DateTimeKind.Local).AddTicks(9838), false, false, new Guid("8df428ba-1d69-45b8-8d40-40e235c957aa"), 43, null },
                    { new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2024, 2, 26, 7, 34, 8, 103, DateTimeKind.Local).AddTicks(3068), false, false, new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), 29, null },
                    { new Guid("9072edf5-43e9-45d6-a04e-60e552ac8b57"), new DateTime(2023, 8, 6, 10, 51, 8, 157, DateTimeKind.Local).AddTicks(7668), false, false, new Guid("9072edf5-43e9-45d6-a04e-60e552ac8b57"), 8, null },
                    { new Guid("95b499c4-34a7-48a2-ac44-bc096de3fc66"), new DateTime(2024, 3, 16, 4, 50, 16, 728, DateTimeKind.Local).AddTicks(1935), false, false, new Guid("95b499c4-34a7-48a2-ac44-bc096de3fc66"), 48, null },
                    { new Guid("96b78027-3570-45bd-8d74-cdaa23c181b8"), new DateTime(2023, 12, 2, 17, 46, 51, 192, DateTimeKind.Local).AddTicks(9759), false, false, new Guid("96b78027-3570-45bd-8d74-cdaa23c181b8"), 26, null },
                    { new Guid("99bd8cd0-f4c4-403a-b678-a3c233ed9f7e"), new DateTime(2023, 11, 12, 5, 54, 48, 200, DateTimeKind.Local).AddTicks(1284), false, false, new Guid("99bd8cd0-f4c4-403a-b678-a3c233ed9f7e"), 40, null },
                    { new Guid("9a5c8eee-dfa0-4aee-8e39-c7f34bf24367"), new DateTime(2023, 9, 12, 2, 21, 55, 833, DateTimeKind.Local).AddTicks(2070), false, false, new Guid("9a5c8eee-dfa0-4aee-8e39-c7f34bf24367"), 31, null },
                    { new Guid("a5d13a52-2dc3-4167-8b8c-4c446844898b"), new DateTime(2023, 12, 28, 16, 40, 4, 882, DateTimeKind.Local).AddTicks(3553), false, false, new Guid("a5d13a52-2dc3-4167-8b8c-4c446844898b"), 2, null },
                    { new Guid("b9066e07-91f7-44bb-a30b-7122aa190ecc"), new DateTime(2024, 3, 8, 13, 45, 11, 694, DateTimeKind.Local).AddTicks(6300), false, false, new Guid("b9066e07-91f7-44bb-a30b-7122aa190ecc"), 13, null },
                    { new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 9, 29, 5, 0, 34, 533, DateTimeKind.Local).AddTicks(4957), false, false, new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), 49, null },
                    { new Guid("c66915b3-d9f8-4bb6-bd46-828e5a946a61"), new DateTime(2023, 9, 9, 16, 40, 12, 507, DateTimeKind.Local).AddTicks(1503), false, false, new Guid("c66915b3-d9f8-4bb6-bd46-828e5a946a61"), 26, null },
                    { new Guid("cb35d17f-0bdb-4237-9cd9-27e6f436cdc4"), new DateTime(2023, 9, 24, 3, 47, 44, 920, DateTimeKind.Local).AddTicks(3125), false, false, new Guid("cb35d17f-0bdb-4237-9cd9-27e6f436cdc4"), 5, null },
                    { new Guid("cd2460aa-cf15-4e44-954a-7f7c4c4e5a4e"), new DateTime(2023, 7, 22, 21, 42, 12, 296, DateTimeKind.Local).AddTicks(8105), false, false, new Guid("cd2460aa-cf15-4e44-954a-7f7c4c4e5a4e"), 1, null },
                    { new Guid("d11c7b91-2e92-4109-9d55-29adc4506f4f"), new DateTime(2024, 4, 7, 13, 59, 22, 934, DateTimeKind.Local).AddTicks(8720), false, false, new Guid("d11c7b91-2e92-4109-9d55-29adc4506f4f"), 45, null },
                    { new Guid("d369c607-b40a-4375-a39b-53287b41aabb"), new DateTime(2024, 2, 9, 4, 33, 19, 428, DateTimeKind.Local).AddTicks(4072), false, false, new Guid("d369c607-b40a-4375-a39b-53287b41aabb"), 28, null },
                    { new Guid("dd868916-dcde-465f-a89c-313a24d230c6"), new DateTime(2023, 10, 17, 0, 30, 0, 424, DateTimeKind.Local).AddTicks(2888), false, false, new Guid("dd868916-dcde-465f-a89c-313a24d230c6"), 26, null },
                    { new Guid("de22d097-5f6c-42bc-947d-5ada70509533"), new DateTime(2023, 10, 18, 15, 24, 28, 341, DateTimeKind.Local).AddTicks(4331), false, false, new Guid("de22d097-5f6c-42bc-947d-5ada70509533"), 8, null },
                    { new Guid("dfbcdf14-bd61-4f63-847a-969b0c517f12"), new DateTime(2024, 3, 23, 12, 53, 38, 243, DateTimeKind.Local).AddTicks(2028), false, false, new Guid("dfbcdf14-bd61-4f63-847a-969b0c517f12"), 47, null },
                    { new Guid("eac29877-cf98-49b2-b092-dabde42b829e"), new DateTime(2024, 4, 2, 23, 22, 42, 620, DateTimeKind.Local).AddTicks(1040), false, false, new Guid("eac29877-cf98-49b2-b092-dabde42b829e"), 26, null },
                    { new Guid("eba86dbf-a17a-45e5-bcbf-6aa599af3be1"), new DateTime(2023, 12, 6, 3, 16, 7, 108, DateTimeKind.Local).AddTicks(5372), false, false, new Guid("eba86dbf-a17a-45e5-bcbf-6aa599af3be1"), 31, null },
                    { new Guid("ef773918-5fff-4c25-84cd-f58b43442e21"), new DateTime(2023, 9, 4, 23, 22, 13, 891, DateTimeKind.Local).AddTicks(3631), false, false, new Guid("ef773918-5fff-4c25-84cd-f58b43442e21"), 42, null },
                    { new Guid("f2cd9efc-1bdb-48ad-ad51-13bb4daff119"), new DateTime(2023, 6, 23, 3, 4, 31, 328, DateTimeKind.Local).AddTicks(8318), false, false, new Guid("f2cd9efc-1bdb-48ad-ad51-13bb4daff119"), 35, null },
                    { new Guid("fefc43b4-97a8-4713-8071-51930f12cb76"), new DateTime(2023, 5, 15, 7, 47, 36, 25, DateTimeKind.Local).AddTicks(7732), false, false, new Guid("fefc43b4-97a8-4713-8071-51930f12cb76"), 43, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductID",
                table: "OrderProduct",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductID",
                table: "ProductDetails",
                column: "ProductID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
