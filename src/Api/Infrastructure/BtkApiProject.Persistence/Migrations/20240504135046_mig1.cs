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
                    { new Guid("18130346-e1b7-41d9-ba97-8e414d50457e"), new DateTime(2024, 3, 19, 9, 55, 51, 695, DateTimeKind.Local).AddTicks(2706), "Perspiciatis ut officia aut ipsam sit reiciendis.", false, false, "Movie", null },
                    { new Guid("18e74e76-934f-4c06-b3ce-643c87c6dcfd"), new DateTime(2024, 4, 17, 23, 38, 52, 936, DateTimeKind.Local).AddTicks(708), "Tempora amet eligendi doloremque velit voluptatem.", false, false, "Clothing", null },
                    { new Guid("34b395e8-4e60-4e13-9ea9-043c0f10852d"), new DateTime(2023, 6, 23, 9, 6, 55, 309, DateTimeKind.Local).AddTicks(4546), "Quo quod quia eum.", false, false, "Music", null },
                    { new Guid("80c7de02-40f8-4c82-bd90-212560c06949"), new DateTime(2023, 7, 22, 23, 27, 19, 854, DateTimeKind.Local).AddTicks(932), "Provident dolore et.", false, false, "Game", null },
                    { new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 10, 8, 7, 49, 5, 914, DateTimeKind.Local).AddTicks(3431), "Amet in maiores et vel voluptatem sit rerum.", false, false, "Electronics", null },
                    { new Guid("95b499c4-34a7-48a2-ac44-bc096de3fc66"), new DateTime(2024, 3, 31, 0, 39, 50, 124, DateTimeKind.Local).AddTicks(5227), "Dolorem corrupti sed.", false, false, "Sport", null },
                    { new Guid("b9066e07-91f7-44bb-a30b-7122aa190ecc"), new DateTime(2023, 7, 12, 22, 6, 11, 490, DateTimeKind.Local).AddTicks(5970), "Eos maiores reprehenderit veritatis consectetur quae minus quibusdam.", false, false, "Accessory", null },
                    { new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 6, 12, 0, 18, 10, 768, DateTimeKind.Local).AddTicks(5827), "Mollitia itaque in et accusantium maxime hic ullam dolorem.", false, false, "Art", null },
                    { new Guid("dd868916-dcde-465f-a89c-313a24d230c6"), new DateTime(2023, 5, 8, 16, 11, 32, 318, DateTimeKind.Local).AddTicks(5157), "Non minima repellat nesciunt.", false, false, "Book", null },
                    { new Guid("eba86dbf-a17a-45e5-bcbf-6aa599af3be1"), new DateTime(2023, 6, 10, 9, 25, 24, 645, DateTimeKind.Local).AddTicks(2030), "Nostrum est quod quae.", false, false, "Furniture", null }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "CreatedDate", "IsApproved", "IsDeleted", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("09118505-491b-46cd-b154-2f523567c531"), new DateTime(2024, 4, 25, 3, 13, 28, 678, DateTimeKind.Local).AddTicks(2019), false, false, null },
                    { new Guid("18130346-e1b7-41d9-ba97-8e414d50457e"), new DateTime(2024, 5, 4, 10, 41, 28, 421, DateTimeKind.Local).AddTicks(5904), false, false, null },
                    { new Guid("18e74e76-934f-4c06-b3ce-643c87c6dcfd"), new DateTime(2024, 3, 14, 3, 25, 48, 828, DateTimeKind.Local).AddTicks(2021), false, false, null },
                    { new Guid("34b395e8-4e60-4e13-9ea9-043c0f10852d"), new DateTime(2024, 1, 10, 2, 47, 14, 165, DateTimeKind.Local).AddTicks(6631), false, false, null },
                    { new Guid("4804fa42-5494-4cb0-8c17-f23731b0135d"), new DateTime(2024, 1, 28, 21, 8, 40, 131, DateTimeKind.Local).AddTicks(8251), false, false, null },
                    { new Guid("80c7de02-40f8-4c82-bd90-212560c06949"), new DateTime(2024, 3, 9, 8, 3, 23, 331, DateTimeKind.Local).AddTicks(1311), false, false, null },
                    { new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 11, 17, 18, 13, 58, 487, DateTimeKind.Local).AddTicks(8210), false, false, null },
                    { new Guid("9072edf5-43e9-45d6-a04e-60e552ac8b57"), new DateTime(2023, 11, 4, 3, 23, 12, 450, DateTimeKind.Local).AddTicks(5287), false, false, null },
                    { new Guid("95b499c4-34a7-48a2-ac44-bc096de3fc66"), new DateTime(2023, 9, 16, 15, 55, 31, 201, DateTimeKind.Local).AddTicks(8209), false, false, null },
                    { new Guid("a5d13a52-2dc3-4167-8b8c-4c446844898b"), new DateTime(2024, 1, 29, 22, 27, 14, 741, DateTimeKind.Local).AddTicks(1692), false, false, null },
                    { new Guid("b9066e07-91f7-44bb-a30b-7122aa190ecc"), new DateTime(2023, 7, 12, 16, 1, 40, 178, DateTimeKind.Local).AddTicks(3466), false, false, null },
                    { new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 8, 27, 20, 41, 27, 357, DateTimeKind.Local).AddTicks(2863), false, false, null },
                    { new Guid("dd868916-dcde-465f-a89c-313a24d230c6"), new DateTime(2023, 5, 13, 22, 41, 28, 805, DateTimeKind.Local).AddTicks(166), false, false, null },
                    { new Guid("eba86dbf-a17a-45e5-bcbf-6aa599af3be1"), new DateTime(2023, 5, 19, 16, 53, 38, 247, DateTimeKind.Local).AddTicks(8009), false, false, null },
                    { new Guid("ef773918-5fff-4c25-84cd-f58b43442e21"), new DateTime(2024, 2, 4, 17, 4, 32, 247, DateTimeKind.Local).AddTicks(1861), false, false, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "CreatedDate", "Description", "IsApproved", "IsDeleted", "Name", "Price", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("065bdc51-a618-45a1-90d7-567ef3843841"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2024, 1, 12, 18, 19, 55, 660, DateTimeKind.Local).AddTicks(1609), "Asperiores aperiam molestiae sint voluptatem accusantium aperiam eum aliquam.", false, false, "Rustic Fresh Sausages", 78.0, null },
                    { new Guid("09118505-491b-46cd-b154-2f523567c531"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 12, 7, 5, 2, 52, 770, DateTimeKind.Local).AddTicks(9718), "Facere ut ea dolor a.", false, false, "Tasty Steel Chips", 107.0, null },
                    { new Guid("0d210c85-5f4c-43a6-bcc2-a9546e99601b"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 7, 3, 20, 14, 7, 581, DateTimeKind.Local).AddTicks(3922), "İn rem unde.", false, false, "Handmade Concrete Bike", 231.0, null },
                    { new Guid("18130346-e1b7-41d9-ba97-8e414d50457e"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 12, 10, 11, 20, 41, 669, DateTimeKind.Local).AddTicks(1612), "İste vero et nobis.", false, false, "Ergonomic Wooden Shirt", 341.0, null },
                    { new Guid("18e74e76-934f-4c06-b3ce-643c87c6dcfd"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2024, 1, 28, 14, 35, 29, 716, DateTimeKind.Local).AddTicks(9232), "Et laudantium soluta nulla officia.", false, false, "Handcrafted Frozen Bacon", 142.0, null },
                    { new Guid("1cbbd6f1-b054-44ed-805f-920a998aff90"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 8, 5, 9, 18, 15, 970, DateTimeKind.Local).AddTicks(289), "Nulla quidem vel in debitis.", false, false, "Awesome Plastic Keyboard", 482.0, null },
                    { new Guid("2993cc3b-48d8-4c3a-8662-9ae328688c9c"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 11, 24, 8, 37, 27, 645, DateTimeKind.Local).AddTicks(8302), "Odit commodi facere sint sint similique maiores officiis.", false, false, "Small Granite Shirt", 382.0, null },
                    { new Guid("32a39a39-0d03-4569-8908-8f0fbd483c65"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2024, 3, 26, 3, 15, 41, 582, DateTimeKind.Local).AddTicks(8397), "Sit neque enim animi a recusandae.", false, false, "Ergonomic Steel Ball", 380.0, null },
                    { new Guid("34b395e8-4e60-4e13-9ea9-043c0f10852d"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 7, 5, 14, 33, 30, 169, DateTimeKind.Local).AddTicks(8350), "Sunt voluptates sit quia voluptas.", false, false, "Awesome Plastic Mouse", 412.0, null },
                    { new Guid("3500e840-e254-4823-90fc-7a8789df67f6"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 8, 11, 17, 32, 31, 342, DateTimeKind.Local).AddTicks(4016), "Soluta consequatur consequatur sequi sed numquam voluptates quasi.", false, false, "Handcrafted Frozen Pants", 481.0, null },
                    { new Guid("35677582-d7f7-4230-ab73-35d5fdc19a1b"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 12, 8, 7, 44, 20, 960, DateTimeKind.Local).AddTicks(5258), "Autem dolorem nam cupiditate aut repudiandae et praesentium repellendus praesentium.", false, false, "Refined Rubber Pants", 163.0, null },
                    { new Guid("388e1e08-a7bd-4552-97c8-b7c0f7b80f11"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2024, 1, 16, 21, 30, 34, 407, DateTimeKind.Local).AddTicks(8562), "Qui quo voluptatem explicabo ipsam expedita eius.", false, false, "Tasty Plastic Pizza", 279.0, null },
                    { new Guid("3e20bea6-3150-4551-8698-c93bcc384a09"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 7, 11, 15, 18, 44, 324, DateTimeKind.Local).AddTicks(3085), "Debitis dolores qui velit.", false, false, "Unbranded Fresh Sausages", 135.0, null },
                    { new Guid("4804fa42-5494-4cb0-8c17-f23731b0135d"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 7, 20, 4, 2, 14, 527, DateTimeKind.Local).AddTicks(4603), "Similique totam minus illum exercitationem.", false, false, "Gorgeous Steel Shirt", 453.0, null },
                    { new Guid("54b58cfa-5b5e-4b2a-88cd-67e340ac758d"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2024, 4, 21, 2, 55, 18, 559, DateTimeKind.Local).AddTicks(6495), "Eaque aspernatur assumenda ad aut similique sit commodi molestiae accusantium.", false, false, "Fantastic Wooden Keyboard", 156.0, null },
                    { new Guid("57fb9bbb-aa3e-4791-94b7-80ea4883613b"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 8, 11, 1, 4, 1, 69, DateTimeKind.Local).AddTicks(413), "Eos id aut omnis.", false, false, "Unbranded Wooden Towels", 43.0, null },
                    { new Guid("5e5589fe-77d8-49d2-9bbb-d1a42cba0bf1"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2024, 3, 30, 21, 13, 42, 843, DateTimeKind.Local).AddTicks(1873), "Est aut atque ex cum.", false, false, "Refined Wooden Chips", 487.0, null },
                    { new Guid("5f6ac016-ec06-4c35-8f74-164c3e0724d3"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2024, 3, 27, 18, 0, 58, 146, DateTimeKind.Local).AddTicks(2405), "Amet soluta exercitationem debitis.", false, false, "Refined Concrete Chair", 157.0, null },
                    { new Guid("61d00226-a54f-43e4-b94f-ebd81c7acfb0"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 9, 24, 11, 16, 5, 968, DateTimeKind.Local).AddTicks(490), "Dolor est animi ipsum.", false, false, "Incredible Fresh Cheese", 491.0, null },
                    { new Guid("61f5f234-13df-4b8e-8558-cccd9b84aab0"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 9, 7, 16, 48, 11, 382, DateTimeKind.Local).AddTicks(5774), "Atque qui quo consequatur corrupti voluptatem sunt incidunt non.", false, false, "Small Cotton Cheese", 66.0, null },
                    { new Guid("65e02ef9-a536-4c6a-9f18-1c6dd9af4fd6"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 6, 25, 16, 9, 6, 228, DateTimeKind.Local).AddTicks(7659), "Nam aut suscipit.", false, false, "Generic Soft Chicken", 252.0, null },
                    { new Guid("6d776c03-bd8a-4ed4-965d-92bd5d196380"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2024, 2, 6, 1, 46, 48, 754, DateTimeKind.Local).AddTicks(5195), "Sint blanditiis voluptates est vero magnam autem.", false, false, "Refined Granite Soap", 288.0, null },
                    { new Guid("7532d41d-4ec0-4c29-9864-25d1e936ccec"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2024, 4, 27, 0, 0, 29, 935, DateTimeKind.Local).AddTicks(5006), "Expedita quisquam totam ut et voluptatibus quos.", false, false, "Rustic Soft Tuna", 452.0, null },
                    { new Guid("7cd76b2b-197a-4ba2-98e1-430b8fd23038"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 8, 24, 17, 32, 2, 213, DateTimeKind.Local).AddTicks(8056), "Voluptatum autem quia sapiente dolorum sit molestiae.", false, false, "Handcrafted Soft Soap", 422.0, null },
                    { new Guid("80c7de02-40f8-4c82-bd90-212560c06949"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 9, 19, 1, 48, 24, 588, DateTimeKind.Local).AddTicks(3678), "Vel fuga dignissimos dolore magni consequuntur.", false, false, "Ergonomic Concrete Shirt", 54.0, null },
                    { new Guid("866ea2a9-8721-4251-8022-ad988bd22b8c"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 9, 16, 18, 19, 58, 589, DateTimeKind.Local).AddTicks(6426), "Aut totam numquam quam.", false, false, "Refined Rubber Pizza", 135.0, null },
                    { new Guid("8c4b66b6-8fea-4330-be08-5e548e473a7b"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2024, 4, 1, 7, 30, 2, 817, DateTimeKind.Local).AddTicks(970), "Aliquid neque esse.", false, false, "Incredible Plastic Pants", 28.0, null },
                    { new Guid("8df428ba-1d69-45b8-8d40-40e235c957aa"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2024, 1, 18, 15, 4, 36, 47, DateTimeKind.Local).AddTicks(6376), "Odit doloribus excepturi dolores omnis et unde.", false, false, "Fantastic Concrete Ball", 371.0, null },
                    { new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 5, 25, 3, 39, 8, 661, DateTimeKind.Local).AddTicks(6619), "Facilis in ut beatae est.", false, false, "Tasty Plastic Soap", 113.0, null },
                    { new Guid("9072edf5-43e9-45d6-a04e-60e552ac8b57"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2024, 4, 26, 5, 49, 28, 588, DateTimeKind.Local).AddTicks(5722), "Optio eum corporis harum molestiae pariatur quis.", false, false, "Handcrafted Metal Computer", 205.0, null },
                    { new Guid("95b499c4-34a7-48a2-ac44-bc096de3fc66"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 12, 22, 4, 50, 12, 73, DateTimeKind.Local).AddTicks(1943), "Nulla voluptates rerum provident.", false, false, "Tasty Cotton Cheese", 20.0, null },
                    { new Guid("96b78027-3570-45bd-8d74-cdaa23c181b8"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 10, 5, 6, 28, 43, 456, DateTimeKind.Local).AddTicks(6425), "Eum voluptates placeat.", false, false, "Generic Rubber Shoes", 277.0, null },
                    { new Guid("99bd8cd0-f4c4-403a-b678-a3c233ed9f7e"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 9, 16, 2, 27, 51, 878, DateTimeKind.Local).AddTicks(6309), "Quae aliquam soluta sint iste dolor et sed est.", false, false, "Unbranded Plastic Tuna", 439.0, null },
                    { new Guid("9a5c8eee-dfa0-4aee-8e39-c7f34bf24367"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2024, 4, 27, 18, 51, 48, 911, DateTimeKind.Local).AddTicks(3746), "Soluta voluptatem a minus vel molestiae rem.", false, false, "Fantastic Soft Shoes", 387.0, null },
                    { new Guid("a5d13a52-2dc3-4167-8b8c-4c446844898b"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 9, 4, 9, 0, 29, 186, DateTimeKind.Local).AddTicks(3646), "Est ex sint voluptas numquam.", false, false, "Gorgeous Wooden Chicken", 485.0, null },
                    { new Guid("b9066e07-91f7-44bb-a30b-7122aa190ecc"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 7, 22, 22, 11, 36, 742, DateTimeKind.Local).AddTicks(3921), "Nemo inventore et quisquam veniam.", false, false, "Ergonomic Granite Car", 349.0, null },
                    { new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 9, 2, 3, 53, 3, 439, DateTimeKind.Local).AddTicks(7048), "Molestias qui delectus explicabo provident at sit.", false, false, "Sleek Concrete Chicken", 174.0, null },
                    { new Guid("c66915b3-d9f8-4bb6-bd46-828e5a946a61"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2024, 4, 26, 19, 8, 4, 897, DateTimeKind.Local).AddTicks(5793), "Eligendi nostrum nesciunt ratione ea dolorem.", false, false, "Handmade Wooden Pizza", 492.0, null },
                    { new Guid("cb35d17f-0bdb-4237-9cd9-27e6f436cdc4"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 9, 16, 22, 25, 24, 118, DateTimeKind.Local).AddTicks(2370), "Et ut consequatur ducimus delectus.", false, false, "Refined Cotton Shirt", 26.0, null },
                    { new Guid("cd2460aa-cf15-4e44-954a-7f7c4c4e5a4e"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 11, 30, 19, 42, 56, 448, DateTimeKind.Local).AddTicks(9125), "Voluptatem et illo omnis aperiam.", false, false, "Awesome Frozen Tuna", 325.0, null },
                    { new Guid("d11c7b91-2e92-4109-9d55-29adc4506f4f"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2024, 2, 13, 20, 41, 11, 258, DateTimeKind.Local).AddTicks(6061), "Dolorem quis qui aperiam dolore.", false, false, "Awesome Granite Keyboard", 477.0, null },
                    { new Guid("d369c607-b40a-4375-a39b-53287b41aabb"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2024, 3, 9, 12, 35, 26, 205, DateTimeKind.Local).AddTicks(5710), "Dignissimos aut repellendus labore.", false, false, "Small Metal Bike", 171.0, null },
                    { new Guid("dd868916-dcde-465f-a89c-313a24d230c6"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 11, 11, 20, 30, 32, 894, DateTimeKind.Local).AddTicks(5623), "Dolor blanditiis earum quia excepturi.", false, false, "Incredible Cotton Car", 409.0, null },
                    { new Guid("de22d097-5f6c-42bc-947d-5ada70509533"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 9, 15, 2, 47, 40, 420, DateTimeKind.Local).AddTicks(4580), "Rerum totam cupiditate iure.", false, false, "Intelligent Wooden Bacon", 393.0, null },
                    { new Guid("dfbcdf14-bd61-4f63-847a-969b0c517f12"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 6, 15, 11, 33, 37, 878, DateTimeKind.Local).AddTicks(723), "Architecto libero autem et odio dolor quisquam.", false, false, "Fantastic Concrete Fish", 445.0, null },
                    { new Guid("eac29877-cf98-49b2-b092-dabde42b829e"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 10, 28, 18, 54, 34, 564, DateTimeKind.Local).AddTicks(8856), "Qui at placeat perspiciatis.", false, false, "Handcrafted Frozen Pizza", 154.0, null },
                    { new Guid("eba86dbf-a17a-45e5-bcbf-6aa599af3be1"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 5, 24, 7, 27, 9, 363, DateTimeKind.Local).AddTicks(2607), "Rerum vel voluptate qui ipsum.", false, false, "Licensed Soft Soap", 192.0, null },
                    { new Guid("ef773918-5fff-4c25-84cd-f58b43442e21"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 6, 3, 21, 5, 23, 74, DateTimeKind.Local).AddTicks(5431), "İpsum neque nisi.", false, false, "Handmade Rubber Soap", 154.0, null },
                    { new Guid("f2cd9efc-1bdb-48ad-ad51-13bb4daff119"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 11, 22, 21, 44, 54, 642, DateTimeKind.Local).AddTicks(1999), "Eaque nam corporis.", false, false, "Gorgeous Soft Chips", 127.0, null },
                    { new Guid("fefc43b4-97a8-4713-8071-51930f12cb76"), new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 8, 4, 4, 30, 45, 655, DateTimeKind.Local).AddTicks(724), "Sapiente eos autem eum reiciendis rerum odit.", false, false, "Small Steel Fish", 493.0, null }
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
                    { new Guid("065bdc51-a618-45a1-90d7-567ef3843841"), new DateTime(2024, 3, 26, 9, 44, 21, 91, DateTimeKind.Local).AddTicks(9930), false, false, new Guid("065bdc51-a618-45a1-90d7-567ef3843841"), 45, null },
                    { new Guid("09118505-491b-46cd-b154-2f523567c531"), new DateTime(2023, 6, 9, 3, 1, 14, 774, DateTimeKind.Local).AddTicks(8917), false, false, new Guid("09118505-491b-46cd-b154-2f523567c531"), 5, null },
                    { new Guid("0d210c85-5f4c-43a6-bcc2-a9546e99601b"), new DateTime(2024, 4, 14, 22, 53, 25, 670, DateTimeKind.Local).AddTicks(8944), false, false, new Guid("0d210c85-5f4c-43a6-bcc2-a9546e99601b"), 43, null },
                    { new Guid("18130346-e1b7-41d9-ba97-8e414d50457e"), new DateTime(2023, 9, 14, 5, 23, 38, 201, DateTimeKind.Local).AddTicks(7249), false, false, new Guid("18130346-e1b7-41d9-ba97-8e414d50457e"), 0, null },
                    { new Guid("18e74e76-934f-4c06-b3ce-643c87c6dcfd"), new DateTime(2023, 12, 23, 8, 50, 15, 796, DateTimeKind.Local).AddTicks(1770), false, false, new Guid("18e74e76-934f-4c06-b3ce-643c87c6dcfd"), 25, null },
                    { new Guid("1cbbd6f1-b054-44ed-805f-920a998aff90"), new DateTime(2023, 10, 11, 23, 9, 58, 684, DateTimeKind.Local).AddTicks(8022), false, false, new Guid("1cbbd6f1-b054-44ed-805f-920a998aff90"), 4, null },
                    { new Guid("2993cc3b-48d8-4c3a-8662-9ae328688c9c"), new DateTime(2023, 11, 10, 18, 41, 24, 722, DateTimeKind.Local).AddTicks(712), false, false, new Guid("2993cc3b-48d8-4c3a-8662-9ae328688c9c"), 18, null },
                    { new Guid("32a39a39-0d03-4569-8908-8f0fbd483c65"), new DateTime(2023, 9, 17, 9, 55, 46, 700, DateTimeKind.Local).AddTicks(9918), false, false, new Guid("32a39a39-0d03-4569-8908-8f0fbd483c65"), 10, null },
                    { new Guid("34b395e8-4e60-4e13-9ea9-043c0f10852d"), new DateTime(2024, 1, 15, 16, 21, 30, 702, DateTimeKind.Local).AddTicks(6936), false, false, new Guid("34b395e8-4e60-4e13-9ea9-043c0f10852d"), 46, null },
                    { new Guid("3500e840-e254-4823-90fc-7a8789df67f6"), new DateTime(2023, 10, 14, 14, 55, 39, 471, DateTimeKind.Local).AddTicks(5138), false, false, new Guid("3500e840-e254-4823-90fc-7a8789df67f6"), 13, null },
                    { new Guid("35677582-d7f7-4230-ab73-35d5fdc19a1b"), new DateTime(2023, 9, 22, 8, 55, 34, 540, DateTimeKind.Local).AddTicks(13), false, false, new Guid("35677582-d7f7-4230-ab73-35d5fdc19a1b"), 23, null },
                    { new Guid("388e1e08-a7bd-4552-97c8-b7c0f7b80f11"), new DateTime(2024, 3, 10, 4, 43, 54, 679, DateTimeKind.Local).AddTicks(1902), false, false, new Guid("388e1e08-a7bd-4552-97c8-b7c0f7b80f11"), 32, null },
                    { new Guid("3e20bea6-3150-4551-8698-c93bcc384a09"), new DateTime(2023, 8, 8, 7, 8, 56, 443, DateTimeKind.Local).AddTicks(8487), false, false, new Guid("3e20bea6-3150-4551-8698-c93bcc384a09"), 13, null },
                    { new Guid("4804fa42-5494-4cb0-8c17-f23731b0135d"), new DateTime(2023, 7, 16, 14, 35, 15, 128, DateTimeKind.Local).AddTicks(7626), false, false, new Guid("4804fa42-5494-4cb0-8c17-f23731b0135d"), 36, null },
                    { new Guid("54b58cfa-5b5e-4b2a-88cd-67e340ac758d"), new DateTime(2023, 8, 26, 1, 7, 33, 230, DateTimeKind.Local).AddTicks(196), false, false, new Guid("54b58cfa-5b5e-4b2a-88cd-67e340ac758d"), 20, null },
                    { new Guid("57fb9bbb-aa3e-4791-94b7-80ea4883613b"), new DateTime(2023, 9, 9, 19, 22, 15, 408, DateTimeKind.Local).AddTicks(4284), false, false, new Guid("57fb9bbb-aa3e-4791-94b7-80ea4883613b"), 19, null },
                    { new Guid("5e5589fe-77d8-49d2-9bbb-d1a42cba0bf1"), new DateTime(2023, 8, 19, 0, 26, 0, 97, DateTimeKind.Local).AddTicks(7966), false, false, new Guid("5e5589fe-77d8-49d2-9bbb-d1a42cba0bf1"), 3, null },
                    { new Guid("5f6ac016-ec06-4c35-8f74-164c3e0724d3"), new DateTime(2023, 7, 23, 10, 35, 55, 936, DateTimeKind.Local).AddTicks(4152), false, false, new Guid("5f6ac016-ec06-4c35-8f74-164c3e0724d3"), 35, null },
                    { new Guid("61d00226-a54f-43e4-b94f-ebd81c7acfb0"), new DateTime(2024, 2, 14, 4, 24, 59, 860, DateTimeKind.Local).AddTicks(116), false, false, new Guid("61d00226-a54f-43e4-b94f-ebd81c7acfb0"), 9, null },
                    { new Guid("61f5f234-13df-4b8e-8558-cccd9b84aab0"), new DateTime(2023, 11, 5, 23, 12, 55, 990, DateTimeKind.Local).AddTicks(6405), false, false, new Guid("61f5f234-13df-4b8e-8558-cccd9b84aab0"), 26, null },
                    { new Guid("65e02ef9-a536-4c6a-9f18-1c6dd9af4fd6"), new DateTime(2024, 2, 29, 13, 26, 23, 813, DateTimeKind.Local).AddTicks(1851), false, false, new Guid("65e02ef9-a536-4c6a-9f18-1c6dd9af4fd6"), 39, null },
                    { new Guid("6d776c03-bd8a-4ed4-965d-92bd5d196380"), new DateTime(2024, 1, 26, 0, 20, 15, 436, DateTimeKind.Local).AddTicks(9400), false, false, new Guid("6d776c03-bd8a-4ed4-965d-92bd5d196380"), 22, null },
                    { new Guid("7532d41d-4ec0-4c29-9864-25d1e936ccec"), new DateTime(2024, 4, 10, 6, 43, 18, 994, DateTimeKind.Local).AddTicks(1074), false, false, new Guid("7532d41d-4ec0-4c29-9864-25d1e936ccec"), 12, null },
                    { new Guid("7cd76b2b-197a-4ba2-98e1-430b8fd23038"), new DateTime(2023, 6, 26, 7, 13, 51, 999, DateTimeKind.Local).AddTicks(408), false, false, new Guid("7cd76b2b-197a-4ba2-98e1-430b8fd23038"), 0, null },
                    { new Guid("80c7de02-40f8-4c82-bd90-212560c06949"), new DateTime(2024, 4, 23, 14, 2, 21, 34, DateTimeKind.Local).AddTicks(5872), false, false, new Guid("80c7de02-40f8-4c82-bd90-212560c06949"), 31, null },
                    { new Guid("866ea2a9-8721-4251-8022-ad988bd22b8c"), new DateTime(2023, 12, 14, 10, 18, 31, 325, DateTimeKind.Local).AddTicks(1194), false, false, new Guid("866ea2a9-8721-4251-8022-ad988bd22b8c"), 41, null },
                    { new Guid("8c4b66b6-8fea-4330-be08-5e548e473a7b"), new DateTime(2023, 9, 3, 18, 31, 39, 307, DateTimeKind.Local).AddTicks(491), false, false, new Guid("8c4b66b6-8fea-4330-be08-5e548e473a7b"), 33, null },
                    { new Guid("8df428ba-1d69-45b8-8d40-40e235c957aa"), new DateTime(2024, 2, 16, 5, 30, 18, 416, DateTimeKind.Local).AddTicks(2851), false, false, new Guid("8df428ba-1d69-45b8-8d40-40e235c957aa"), 6, null },
                    { new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), new DateTime(2023, 9, 27, 1, 7, 19, 893, DateTimeKind.Local).AddTicks(1290), false, false, new Guid("8ed24296-d7a3-438b-be89-358a6186a06b"), 1, null },
                    { new Guid("9072edf5-43e9-45d6-a04e-60e552ac8b57"), new DateTime(2024, 1, 27, 23, 51, 30, 692, DateTimeKind.Local).AddTicks(9681), false, false, new Guid("9072edf5-43e9-45d6-a04e-60e552ac8b57"), 9, null },
                    { new Guid("95b499c4-34a7-48a2-ac44-bc096de3fc66"), new DateTime(2024, 1, 28, 9, 40, 23, 986, DateTimeKind.Local).AddTicks(4322), false, false, new Guid("95b499c4-34a7-48a2-ac44-bc096de3fc66"), 8, null },
                    { new Guid("96b78027-3570-45bd-8d74-cdaa23c181b8"), new DateTime(2023, 11, 2, 16, 2, 16, 683, DateTimeKind.Local).AddTicks(5550), false, false, new Guid("96b78027-3570-45bd-8d74-cdaa23c181b8"), 25, null },
                    { new Guid("99bd8cd0-f4c4-403a-b678-a3c233ed9f7e"), new DateTime(2024, 4, 15, 7, 10, 1, 412, DateTimeKind.Local).AddTicks(7056), false, false, new Guid("99bd8cd0-f4c4-403a-b678-a3c233ed9f7e"), 49, null },
                    { new Guid("9a5c8eee-dfa0-4aee-8e39-c7f34bf24367"), new DateTime(2024, 1, 26, 13, 3, 8, 382, DateTimeKind.Local).AddTicks(9912), false, false, new Guid("9a5c8eee-dfa0-4aee-8e39-c7f34bf24367"), 8, null },
                    { new Guid("a5d13a52-2dc3-4167-8b8c-4c446844898b"), new DateTime(2023, 6, 18, 22, 37, 34, 939, DateTimeKind.Local).AddTicks(1864), false, false, new Guid("a5d13a52-2dc3-4167-8b8c-4c446844898b"), 18, null },
                    { new Guid("b9066e07-91f7-44bb-a30b-7122aa190ecc"), new DateTime(2023, 10, 29, 5, 27, 23, 958, DateTimeKind.Local).AddTicks(9554), false, false, new Guid("b9066e07-91f7-44bb-a30b-7122aa190ecc"), 36, null },
                    { new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), new DateTime(2023, 12, 23, 22, 50, 56, 530, DateTimeKind.Local).AddTicks(1892), false, false, new Guid("c398bbac-0820-4456-8f24-bd5bcaf3771b"), 30, null },
                    { new Guid("c66915b3-d9f8-4bb6-bd46-828e5a946a61"), new DateTime(2023, 6, 1, 9, 54, 46, 966, DateTimeKind.Local).AddTicks(9909), false, false, new Guid("c66915b3-d9f8-4bb6-bd46-828e5a946a61"), 2, null },
                    { new Guid("cb35d17f-0bdb-4237-9cd9-27e6f436cdc4"), new DateTime(2024, 2, 6, 23, 31, 12, 699, DateTimeKind.Local).AddTicks(9196), false, false, new Guid("cb35d17f-0bdb-4237-9cd9-27e6f436cdc4"), 13, null },
                    { new Guid("cd2460aa-cf15-4e44-954a-7f7c4c4e5a4e"), new DateTime(2023, 12, 9, 22, 34, 31, 193, DateTimeKind.Local).AddTicks(2258), false, false, new Guid("cd2460aa-cf15-4e44-954a-7f7c4c4e5a4e"), 25, null },
                    { new Guid("d11c7b91-2e92-4109-9d55-29adc4506f4f"), new DateTime(2023, 10, 9, 10, 18, 6, 440, DateTimeKind.Local).AddTicks(3544), false, false, new Guid("d11c7b91-2e92-4109-9d55-29adc4506f4f"), 30, null },
                    { new Guid("d369c607-b40a-4375-a39b-53287b41aabb"), new DateTime(2023, 12, 30, 10, 11, 37, 822, DateTimeKind.Local).AddTicks(8666), false, false, new Guid("d369c607-b40a-4375-a39b-53287b41aabb"), 12, null },
                    { new Guid("dd868916-dcde-465f-a89c-313a24d230c6"), new DateTime(2023, 11, 17, 10, 41, 40, 427, DateTimeKind.Local).AddTicks(2577), false, false, new Guid("dd868916-dcde-465f-a89c-313a24d230c6"), 5, null },
                    { new Guid("de22d097-5f6c-42bc-947d-5ada70509533"), new DateTime(2024, 3, 3, 9, 55, 19, 835, DateTimeKind.Local).AddTicks(2752), false, false, new Guid("de22d097-5f6c-42bc-947d-5ada70509533"), 35, null },
                    { new Guid("dfbcdf14-bd61-4f63-847a-969b0c517f12"), new DateTime(2023, 12, 11, 22, 37, 54, 410, DateTimeKind.Local).AddTicks(6599), false, false, new Guid("dfbcdf14-bd61-4f63-847a-969b0c517f12"), 3, null },
                    { new Guid("eac29877-cf98-49b2-b092-dabde42b829e"), new DateTime(2023, 5, 8, 19, 58, 51, 14, DateTimeKind.Local).AddTicks(211), false, false, new Guid("eac29877-cf98-49b2-b092-dabde42b829e"), 49, null },
                    { new Guid("eba86dbf-a17a-45e5-bcbf-6aa599af3be1"), new DateTime(2023, 7, 9, 2, 47, 8, 487, DateTimeKind.Local).AddTicks(8953), false, false, new Guid("eba86dbf-a17a-45e5-bcbf-6aa599af3be1"), 25, null },
                    { new Guid("ef773918-5fff-4c25-84cd-f58b43442e21"), new DateTime(2024, 2, 11, 13, 42, 10, 836, DateTimeKind.Local).AddTicks(3899), false, false, new Guid("ef773918-5fff-4c25-84cd-f58b43442e21"), 15, null },
                    { new Guid("f2cd9efc-1bdb-48ad-ad51-13bb4daff119"), new DateTime(2023, 10, 27, 17, 44, 43, 148, DateTimeKind.Local).AddTicks(9106), false, false, new Guid("f2cd9efc-1bdb-48ad-ad51-13bb4daff119"), 6, null },
                    { new Guid("fefc43b4-97a8-4713-8071-51930f12cb76"), new DateTime(2023, 8, 28, 4, 33, 38, 214, DateTimeKind.Local).AddTicks(9190), false, false, new Guid("fefc43b4-97a8-4713-8071-51930f12cb76"), 49, null }
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
