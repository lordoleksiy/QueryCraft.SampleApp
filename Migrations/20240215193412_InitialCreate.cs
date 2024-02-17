using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QueryCraft.SampleApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ProductCategory_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), "Electronics" },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), "Books" },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), "Clothing" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IsActive", "Name", "Price", "ReleaseDate", "StockQuantity" },
                values: new object[,]
                {
                    { new Guid("018a8a51-64c3-435e-92c7-c0fc58eaeae0"), "This is a great Novel!", false, "Novel", 322m, new DateTime(2023, 5, 11, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9118), 11 },
                    { new Guid("02ffdeca-2d10-4bca-9644-99c1c4c1d931"), "This is a great Smartphone!", false, "Smartphone", 910m, new DateTime(2023, 5, 6, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9183), 14 },
                    { new Guid("047d508e-2167-4ca3-8d91-38ab4691ea37"), "This is a great Thriller!", true, "Thriller", 538m, new DateTime(2023, 12, 13, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9427), 13 },
                    { new Guid("0672763c-ca61-476b-b0e6-db764348a698"), "This is a great Laptop!", false, "Laptop", 410m, new DateTime(2024, 2, 7, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9318), 34 },
                    { new Guid("06e30e1e-6423-4216-9ced-6824d997e672"), "This is a great Thriller!", true, "Thriller", 469m, new DateTime(2023, 12, 28, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9215), 20 },
                    { new Guid("06f5b2ee-b58c-48b0-ada4-f54c34405d9f"), "This is a great Smartphone!", true, "Smartphone", 110m, new DateTime(2023, 8, 2, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9057), 36 },
                    { new Guid("0aa7f93d-e33f-4aec-91f3-5f7946162ff0"), "This is a great Novel!", true, "Novel", 346m, new DateTime(2023, 9, 30, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(8952), 28 },
                    { new Guid("0bdb7f29-0b54-48ee-b443-4554e526b5ea"), "This is a great Novel!", true, "Novel", 363m, new DateTime(2023, 3, 10, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9444), 47 },
                    { new Guid("0dd9fb23-b065-4cb0-917f-67998b805a24"), "This is a great Novel!", true, "Novel", 318m, new DateTime(2023, 3, 10, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9716), 16 },
                    { new Guid("0eaa5bc1-1364-4403-bf1c-87e6031b3ff6"), "This is a great Thriller!", true, "Thriller", 159m, new DateTime(2023, 6, 8, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9276), 36 },
                    { new Guid("108db650-fbe8-416e-ac7b-2af139f76732"), "This is a great T-Shirt!", false, "T-Shirt", 467m, new DateTime(2023, 7, 28, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9313), 43 },
                    { new Guid("1563dd10-3704-4644-90e3-758825d64189"), "This is a great Thriller!", false, "Thriller", 507m, new DateTime(2023, 10, 6, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(8928), 12 },
                    { new Guid("16eb32a7-1cec-4344-be45-ea3e46e0d205"), "This is a great Jacket!", false, "Jacket", 446m, new DateTime(2023, 6, 23, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9720), 18 },
                    { new Guid("199989cf-b202-400e-a20d-5453d49ac9df"), "This is a great Thriller!", false, "Thriller", 406m, new DateTime(2023, 11, 8, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9358), 12 },
                    { new Guid("1cc62a04-ac87-4ae3-9952-08c3c8963bf3"), "This is a great Novel!", false, "Novel", 989m, new DateTime(2024, 2, 1, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(8851), 11 },
                    { new Guid("2194017e-62cd-41f5-85b9-9b709010f87f"), "This is a great T-Shirt!", false, "T-Shirt", 624m, new DateTime(2024, 2, 8, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9510), 18 },
                    { new Guid("2219470f-d23a-4c35-9b08-9567b0191a48"), "This is a great Novel!", false, "Novel", 831m, new DateTime(2023, 11, 6, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(8902), 40 },
                    { new Guid("2308bfbd-78b6-4a01-a062-ed48e3a88ae7"), "This is a great Thriller!", true, "Thriller", 678m, new DateTime(2023, 9, 6, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9124), 31 },
                    { new Guid("256cdc05-111e-4d24-8b53-8ff256c16ac7"), "This is a great Smartphone!", false, "Smartphone", 85m, new DateTime(2023, 3, 13, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9372), 21 },
                    { new Guid("27c7f78c-113e-4d09-a1c2-bce8dc37dd91"), "This is a great Jacket!", true, "Jacket", 921m, new DateTime(2023, 2, 24, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9188), 32 },
                    { new Guid("29788545-4f0f-4fae-9489-9c27de7821b2"), "This is a great Laptop!", true, "Laptop", 463m, new DateTime(2023, 3, 17, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9270), 19 },
                    { new Guid("2b6ce2f3-f882-428e-86f8-3f2bc36823c3"), "This is a great Laptop!", true, "Laptop", 438m, new DateTime(2023, 12, 7, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9638), 20 },
                    { new Guid("2e431c7d-5215-48c1-8e1c-4a9dcbf62f10"), "This is a great Novel!", true, "Novel", 760m, new DateTime(2024, 1, 1, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(8841), 24 },
                    { new Guid("32c3085c-a29a-4b46-9f06-9e3c74afe348"), "This is a great Jacket!", false, "Jacket", 259m, new DateTime(2023, 9, 30, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9504), 15 },
                    { new Guid("3397e792-cfe5-4010-a324-e0234732c723"), "This is a great Novel!", false, "Novel", 457m, new DateTime(2023, 7, 29, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9303), 25 },
                    { new Guid("3998bb73-468a-4796-9be9-937f783d02ac"), "This is a great Jacket!", true, "Jacket", 595m, new DateTime(2023, 2, 27, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9533), 27 },
                    { new Guid("3e63fa84-8624-4f24-ba56-0ddd4454305f"), "This is a great Thriller!", true, "Thriller", 187m, new DateTime(2023, 5, 10, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9177), 28 },
                    { new Guid("424d9ea2-9521-4f1a-abef-7fca4c04e1b2"), "This is a great Jacket!", true, "Jacket", 29m, new DateTime(2023, 6, 1, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(8946), 13 },
                    { new Guid("428829b3-91dc-41ba-b704-9012a01f1c29"), "This is a great Novel!", false, "Novel", 494m, new DateTime(2023, 2, 17, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9542), 26 },
                    { new Guid("42ac4fd0-9f40-475a-af82-3e3f97175306"), "This is a great Novel!", false, "Novel", 530m, new DateTime(2023, 6, 28, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9282), 23 },
                    { new Guid("458fd740-28dd-42ad-8603-705ecd8d7e0f"), "This is a great Smartphone!", true, "Smartphone", 146m, new DateTime(2023, 2, 26, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9016), 22 },
                    { new Guid("45d61401-d21c-4db9-8d77-564fb055bb7e"), "This is a great Jacket!", true, "Jacket", 827m, new DateTime(2023, 11, 13, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9612), 10 },
                    { new Guid("466a499d-1dc0-4d55-9f88-9eee973f8e5d"), "This is a great T-Shirt!", false, "T-Shirt", 507m, new DateTime(2023, 8, 3, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9288), 43 },
                    { new Guid("477e12a1-9ce8-4ad0-8edf-3a0ef1b373a3"), "This is a great T-Shirt!", true, "T-Shirt", 592m, new DateTime(2023, 9, 8, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9194), 38 },
                    { new Guid("4c0530c0-8e65-44be-8f0a-e0fd5140e906"), "This is a great Novel!", false, "Novel", 396m, new DateTime(2023, 10, 11, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9628), 20 },
                    { new Guid("5197b475-593f-46fb-8a10-552a45ff9a25"), "This is a great Laptop!", false, "Laptop", 44m, new DateTime(2023, 9, 15, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9363), 29 },
                    { new Guid("524ce5d5-a7f9-4fde-ab3a-5d0828da0898"), "This is a great Laptop!", false, "Laptop", 489m, new DateTime(2023, 3, 19, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9623), 19 },
                    { new Guid("5280da7d-c447-4752-93ba-f770f3e32623"), "This is a great Novel!", false, "Novel", 859m, new DateTime(2023, 12, 16, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9062), 16 },
                    { new Guid("56d1122a-2b5e-48d1-9b5f-556f0adbc5c5"), "This is a great Novel!", true, "Novel", 471m, new DateTime(2023, 4, 19, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9422), 47 },
                    { new Guid("59205ff6-be39-4571-aaf5-f271b877e100"), "This is a great Thriller!", false, "Thriller", 78m, new DateTime(2023, 12, 28, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9220), 48 },
                    { new Guid("5be514b4-f6b9-4067-a0bb-3028672c3f5c"), "This is a great Novel!", false, "Novel", 251m, new DateTime(2023, 10, 14, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9103), 36 },
                    { new Guid("5dd669f1-4e13-411e-929f-2fd706c67260"), "This is a great Smartphone!", true, "Smartphone", 271m, new DateTime(2023, 6, 5, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(8958), 48 },
                    { new Guid("61f93a9d-dcf2-4b92-9179-bfcb14b34626"), "This is a great T-Shirt!", false, "T-Shirt", 41m, new DateTime(2023, 11, 3, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9438), 18 },
                    { new Guid("627d539b-da1f-46ac-9583-dea89c2ae05e"), "This is a great Novel!", false, "Novel", 121m, new DateTime(2023, 9, 19, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9368), 47 },
                    { new Guid("63e2fb7d-d3b6-4b6a-b6a0-d0037573e423"), "This is a great T-Shirt!", true, "T-Shirt", 859m, new DateTime(2023, 6, 2, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9617), 38 },
                    { new Guid("67c84af0-e3f0-4741-aee3-e9678c2a8526"), "This is a great Jacket!", true, "Jacket", 529m, new DateTime(2024, 2, 11, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9547), 19 },
                    { new Guid("69226be5-f2f4-4f70-b20e-a09bbc24b88e"), "This is a great Jacket!", false, "Jacket", 691m, new DateTime(2023, 3, 7, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9705), 20 },
                    { new Guid("69be7f56-da99-46d3-a83a-565d04423eff"), "This is a great Jacket!", true, "Jacket", 487m, new DateTime(2023, 9, 19, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9041), 46 },
                    { new Guid("6a76390e-6d2f-4e8e-8b2d-f72d9ad3a200"), "This is a great Jacket!", true, "Jacket", 598m, new DateTime(2023, 8, 2, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9398), 45 },
                    { new Guid("7075686b-9fa9-475b-bcd3-9c5f87a85d82"), "This is a great Thriller!", false, "Thriller", 243m, new DateTime(2023, 8, 25, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9449), 15 },
                    { new Guid("71a69f28-9008-4161-93a5-669d06ebd80c"), "This is a great Thriller!", false, "Thriller", 815m, new DateTime(2023, 5, 29, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9650), 22 },
                    { new Guid("752fa4a9-e6e8-4458-b515-d36ccd6ac81e"), "This is a great Laptop!", true, "Laptop", 66m, new DateTime(2023, 8, 20, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9205), 46 },
                    { new Guid("75a9729e-25a8-45db-9be1-6abf0ffd07a1"), "This is a great Thriller!", false, "Thriller", 186m, new DateTime(2023, 10, 15, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9595), 24 },
                    { new Guid("77164ae6-89fa-4dec-8e71-29083c12c7bf"), "This is a great Smartphone!", false, "Smartphone", 934m, new DateTime(2023, 9, 5, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(8934), 21 },
                    { new Guid("7aa3ce93-631a-44c2-a662-7fa76eee4871"), "This is a great Jacket!", true, "Jacket", 485m, new DateTime(2023, 8, 19, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9454), 13 },
                    { new Guid("7af9b388-2cff-4be3-a687-e09b07dddb59"), "This is a great Jacket!", true, "Jacket", 826m, new DateTime(2023, 4, 19, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9230), 15 },
                    { new Guid("7b6c1a1a-f48b-430e-874c-982133dd7064"), "This is a great Jacket!", true, "Jacket", 583m, new DateTime(2023, 6, 19, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(8906), 38 },
                    { new Guid("7d37837c-f4de-40e9-9447-c7d67282a952"), "This is a great Jacket!", true, "Jacket", 97m, new DateTime(2023, 8, 4, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9035), 47 },
                    { new Guid("7d7f3eed-f54f-42c9-9558-70d125fa364e"), "This is a great Novel!", false, "Novel", 588m, new DateTime(2023, 2, 24, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9293), 43 },
                    { new Guid("7fa595a8-92cf-4d79-800d-55e2a139331a"), "This is a great Laptop!", false, "Laptop", 838m, new DateTime(2023, 4, 23, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(8941), 26 },
                    { new Guid("8012cdc7-10b5-493f-b53b-f821f706bb12"), "This is a great Laptop!", false, "Laptop", 925m, new DateTime(2023, 9, 13, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9108), 21 },
                    { new Guid("80e2af48-56a3-43cf-8f4a-e70efcbd2143"), "This is a great Jacket!", false, "Jacket", 579m, new DateTime(2023, 12, 26, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9432), 37 },
                    { new Guid("8122fe85-8315-4566-be58-61ca5769e97b"), "This is a great Novel!", true, "Novel", 942m, new DateTime(2023, 7, 16, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9463), 13 },
                    { new Guid("817f527b-a792-49da-849f-0e14498b26d4"), "This is a great Thriller!", true, "Thriller", 772m, new DateTime(2023, 8, 22, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9141), 13 },
                    { new Guid("85051083-f17e-40b5-9460-ce6aa57b40a7"), "This is a great Smartphone!", true, "Smartphone", 229m, new DateTime(2023, 9, 16, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9645), 48 },
                    { new Guid("8891a0b2-abe5-4fe0-b700-5e6816708309"), "This is a great Thriller!", false, "Thriller", 150m, new DateTime(2023, 4, 27, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9199), 24 },
                    { new Guid("89dfdd58-9602-46e3-b527-641d5016f45c"), "This is a great Novel!", false, "Novel", 498m, new DateTime(2023, 3, 13, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9552), 47 },
                    { new Guid("8d35efe0-ac0a-402c-80b3-55b215b80c28"), "This is a great Smartphone!", true, "Smartphone", 910m, new DateTime(2023, 9, 5, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9378), 46 },
                    { new Guid("8d63dcbf-5f35-4ac9-927f-bbbe8d0218ec"), "This is a great T-Shirt!", true, "T-Shirt", 510m, new DateTime(2023, 10, 6, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(8722), 14 },
                    { new Guid("9a943d8c-4402-401a-9bba-9b7e45a4d0d2"), "This is a great Novel!", false, "Novel", 993m, new DateTime(2023, 12, 19, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9210), 32 },
                    { new Guid("a0e83922-d529-4af5-8ffa-a426c656611c"), "This is a great Smartphone!", false, "Smartphone", 788m, new DateTime(2024, 2, 7, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9298), 42 },
                    { new Guid("a36bd4ac-fc59-4f7c-9019-6092c64a108c"), "This is a great Smartphone!", false, "Smartphone", 107m, new DateTime(2023, 11, 5, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9068), 21 },
                    { new Guid("a81c8d62-0df6-4364-8ab7-e6e8e5abcdd7"), "This is a great Jacket!", false, "Jacket", 529m, new DateTime(2023, 10, 27, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9608), 12 },
                    { new Guid("af82d7ad-2ec6-46c5-a628-e307703d93c8"), "This is a great Smartphone!", false, "Smartphone", 858m, new DateTime(2023, 11, 9, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9382), 10 },
                    { new Guid("b0909486-08be-417f-b7f2-b3f279e7ca9c"), "This is a great Thriller!", false, "Thriller", 885m, new DateTime(2023, 6, 29, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9324), 22 },
                    { new Guid("b2de8db0-d347-4724-b784-d297d23ddc5b"), "This is a great Laptop!", false, "Laptop", 699m, new DateTime(2024, 1, 26, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9047), 22 },
                    { new Guid("b2ec5cfd-8262-4e35-bb8f-3de9ed72c8c0"), "This is a great Thriller!", true, "Thriller", 135m, new DateTime(2023, 9, 5, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9632), 12 },
                    { new Guid("b65de807-7ce9-4696-b60f-ef15551e869e"), "This is a great Thriller!", false, "Thriller", 38m, new DateTime(2023, 7, 6, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9029), 35 },
                    { new Guid("c1886afe-8e7b-4a04-9f31-f47cebb3f3c5"), "This is a great Jacket!", true, "Jacket", 563m, new DateTime(2023, 4, 10, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9224), 21 },
                    { new Guid("c74819ae-1907-476c-a2a9-2f81ee5a3d15"), "This is a great Thriller!", true, "Thriller", 597m, new DateTime(2023, 12, 17, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(8922), 18 },
                    { new Guid("c98cc0ea-38f6-4a80-88aa-c51eb3a41e5d"), "This is a great T-Shirt!", false, "T-Shirt", 991m, new DateTime(2023, 10, 4, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9523), 20 },
                    { new Guid("ca5de21d-c7a4-4f48-98fd-1eb5cc43ff03"), "This is a great Smartphone!", false, "Smartphone", 478m, new DateTime(2023, 2, 24, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9114), 47 },
                    { new Guid("cd7482b0-24df-403a-a055-edaa10b93062"), "This is a great Jacket!", false, "Jacket", 891m, new DateTime(2024, 1, 7, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9393), 44 },
                    { new Guid("d0b88306-58f3-4991-be31-a47b0ede16ea"), "This is a great Smartphone!", false, "Smartphone", 490m, new DateTime(2023, 3, 3, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9146), 48 },
                    { new Guid("d0b9bf92-65f4-48dc-a66d-79c7eef03b60"), "This is a great T-Shirt!", false, "T-Shirt", 706m, new DateTime(2023, 4, 20, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9388), 32 },
                    { new Guid("d3a20db1-8d1c-4822-bcf7-da37e573fe10"), "This is a great Thriller!", true, "Thriller", 664m, new DateTime(2023, 3, 2, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(8915), 23 },
                    { new Guid("d4c42c29-b0f1-47ad-8d69-5a79194d9d76"), "This is a great Thriller!", true, "Thriller", 212m, new DateTime(2024, 1, 24, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9023), 15 },
                    { new Guid("de601fa9-d231-475a-adf0-521434f46744"), "This is a great Novel!", false, "Novel", 485m, new DateTime(2023, 12, 12, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9710), 29 },
                    { new Guid("e0b7a410-51ef-4ad9-a78a-af7d2016c5ad"), "This is a great Smartphone!", false, "Smartphone", 180m, new DateTime(2023, 12, 2, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9602), 19 },
                    { new Guid("e88edee9-5c05-4d6e-943f-57c28abb8cd8"), "This is a great T-Shirt!", false, "T-Shirt", 914m, new DateTime(2023, 6, 30, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9516), 22 },
                    { new Guid("eb40d6ac-fa0a-4a71-a578-2c15864fe9f9"), "This is a great Novel!", false, "Novel", 504m, new DateTime(2023, 5, 6, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9136), 12 },
                    { new Guid("ed349a5b-034e-4b48-9c9f-1b1996037b3d"), "This is a great Thriller!", true, "Thriller", 750m, new DateTime(2023, 6, 4, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9537), 37 },
                    { new Guid("ee8128f6-0c56-413f-9700-424854c92d49"), "This is a great Thriller!", true, "Thriller", 37m, new DateTime(2023, 7, 9, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9052), 14 },
                    { new Guid("f16a6f09-bdb3-4eff-9003-ae6045a64d4d"), "This is a great Smartphone!", false, "Smartphone", 563m, new DateTime(2023, 7, 25, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9307), 15 },
                    { new Guid("f569f2fd-92d5-4967-849e-c6c8af19bd9a"), "This is a great Novel!", true, "Novel", 275m, new DateTime(2023, 11, 16, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9528), 49 },
                    { new Guid("f75f64be-5206-4c52-9522-12efcf1bebeb"), "This is a great Laptop!", false, "Laptop", 806m, new DateTime(2023, 3, 16, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9097), 48 },
                    { new Guid("fcdeb121-59e2-4115-80c4-221ab15573df"), "This is a great Thriller!", false, "Thriller", 905m, new DateTime(2024, 2, 4, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9459), 15 },
                    { new Guid("fd501d5b-04e1-450c-aec6-da8a003423b5"), "This is a great Novel!", true, "Novel", 650m, new DateTime(2023, 10, 15, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9500), 34 },
                    { new Guid("fd56d843-348e-4f39-8500-4ff9da3c55e2"), "This is a great Thriller!", false, "Thriller", 653m, new DateTime(2023, 4, 9, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9353), 26 },
                    { new Guid("fea335d4-b8ae-452e-95df-b0cea1c79037"), "This is a great Thriller!", true, "Thriller", 370m, new DateTime(2024, 2, 8, 21, 34, 12, 60, DateTimeKind.Local).AddTicks(9129), 46 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoriesId", "ProductsId" },
                values: new object[,]
                {
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("018a8a51-64c3-435e-92c7-c0fc58eaeae0") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("02ffdeca-2d10-4bca-9644-99c1c4c1d931") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("047d508e-2167-4ca3-8d91-38ab4691ea37") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("06e30e1e-6423-4216-9ced-6824d997e672") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("0aa7f93d-e33f-4aec-91f3-5f7946162ff0") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("0dd9fb23-b065-4cb0-917f-67998b805a24") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("108db650-fbe8-416e-ac7b-2af139f76732") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("1563dd10-3704-4644-90e3-758825d64189") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("2194017e-62cd-41f5-85b9-9b709010f87f") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("256cdc05-111e-4d24-8b53-8ff256c16ac7") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("27c7f78c-113e-4d09-a1c2-bce8dc37dd91") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("29788545-4f0f-4fae-9489-9c27de7821b2") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("2b6ce2f3-f882-428e-86f8-3f2bc36823c3") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("2e431c7d-5215-48c1-8e1c-4a9dcbf62f10") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("32c3085c-a29a-4b46-9f06-9e3c74afe348") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("3e63fa84-8624-4f24-ba56-0ddd4454305f") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("424d9ea2-9521-4f1a-abef-7fca4c04e1b2") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("428829b3-91dc-41ba-b704-9012a01f1c29") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("42ac4fd0-9f40-475a-af82-3e3f97175306") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("466a499d-1dc0-4d55-9f88-9eee973f8e5d") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("4c0530c0-8e65-44be-8f0a-e0fd5140e906") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("524ce5d5-a7f9-4fde-ab3a-5d0828da0898") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("56d1122a-2b5e-48d1-9b5f-556f0adbc5c5") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("61f93a9d-dcf2-4b92-9179-bfcb14b34626") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("627d539b-da1f-46ac-9583-dea89c2ae05e") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("63e2fb7d-d3b6-4b6a-b6a0-d0037573e423") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("69226be5-f2f4-4f70-b20e-a09bbc24b88e") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("69be7f56-da99-46d3-a83a-565d04423eff") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("7075686b-9fa9-475b-bcd3-9c5f87a85d82") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("71a69f28-9008-4161-93a5-669d06ebd80c") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("77164ae6-89fa-4dec-8e71-29083c12c7bf") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("7b6c1a1a-f48b-430e-874c-982133dd7064") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("7d37837c-f4de-40e9-9447-c7d67282a952") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("7d7f3eed-f54f-42c9-9558-70d125fa364e") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("7fa595a8-92cf-4d79-800d-55e2a139331a") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("817f527b-a792-49da-849f-0e14498b26d4") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("85051083-f17e-40b5-9460-ce6aa57b40a7") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("8891a0b2-abe5-4fe0-b700-5e6816708309") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("89dfdd58-9602-46e3-b527-641d5016f45c") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("8d35efe0-ac0a-402c-80b3-55b215b80c28") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("8d63dcbf-5f35-4ac9-927f-bbbe8d0218ec") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("a81c8d62-0df6-4364-8ab7-e6e8e5abcdd7") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("b2de8db0-d347-4724-b784-d297d23ddc5b") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("b2ec5cfd-8262-4e35-bb8f-3de9ed72c8c0") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("b65de807-7ce9-4696-b60f-ef15551e869e") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("c1886afe-8e7b-4a04-9f31-f47cebb3f3c5") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("c74819ae-1907-476c-a2a9-2f81ee5a3d15") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("c98cc0ea-38f6-4a80-88aa-c51eb3a41e5d") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("cd7482b0-24df-403a-a055-edaa10b93062") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("d0b9bf92-65f4-48dc-a66d-79c7eef03b60") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("d3a20db1-8d1c-4822-bcf7-da37e573fe10") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("e0b7a410-51ef-4ad9-a78a-af7d2016c5ad") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("e88edee9-5c05-4d6e-943f-57c28abb8cd8") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("eb40d6ac-fa0a-4a71-a578-2c15864fe9f9") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("ed349a5b-034e-4b48-9c9f-1b1996037b3d") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("f16a6f09-bdb3-4eff-9003-ae6045a64d4d") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("f75f64be-5206-4c52-9522-12efcf1bebeb") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("fcdeb121-59e2-4115-80c4-221ab15573df") },
                    { new Guid("2eacf57d-f189-43a5-9024-1ba1c3675af7"), new Guid("fd501d5b-04e1-450c-aec6-da8a003423b5") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("018a8a51-64c3-435e-92c7-c0fc58eaeae0") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("02ffdeca-2d10-4bca-9644-99c1c4c1d931") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("047d508e-2167-4ca3-8d91-38ab4691ea37") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("06e30e1e-6423-4216-9ced-6824d997e672") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("06f5b2ee-b58c-48b0-ada4-f54c34405d9f") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("0eaa5bc1-1364-4403-bf1c-87e6031b3ff6") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("1563dd10-3704-4644-90e3-758825d64189") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("16eb32a7-1cec-4344-be45-ea3e46e0d205") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("2194017e-62cd-41f5-85b9-9b709010f87f") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("2219470f-d23a-4c35-9b08-9567b0191a48") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("2308bfbd-78b6-4a01-a062-ed48e3a88ae7") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("256cdc05-111e-4d24-8b53-8ff256c16ac7") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("27c7f78c-113e-4d09-a1c2-bce8dc37dd91") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("29788545-4f0f-4fae-9489-9c27de7821b2") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("2b6ce2f3-f882-428e-86f8-3f2bc36823c3") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("2e431c7d-5215-48c1-8e1c-4a9dcbf62f10") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("32c3085c-a29a-4b46-9f06-9e3c74afe348") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("3e63fa84-8624-4f24-ba56-0ddd4454305f") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("424d9ea2-9521-4f1a-abef-7fca4c04e1b2") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("428829b3-91dc-41ba-b704-9012a01f1c29") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("42ac4fd0-9f40-475a-af82-3e3f97175306") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("458fd740-28dd-42ad-8603-705ecd8d7e0f") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("45d61401-d21c-4db9-8d77-564fb055bb7e") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("477e12a1-9ce8-4ad0-8edf-3a0ef1b373a3") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("4c0530c0-8e65-44be-8f0a-e0fd5140e906") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("5197b475-593f-46fb-8a10-552a45ff9a25") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("524ce5d5-a7f9-4fde-ab3a-5d0828da0898") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("5280da7d-c447-4752-93ba-f770f3e32623") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("59205ff6-be39-4571-aaf5-f271b877e100") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("5be514b4-f6b9-4067-a0bb-3028672c3f5c") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("5dd669f1-4e13-411e-929f-2fd706c67260") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("61f93a9d-dcf2-4b92-9179-bfcb14b34626") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("63e2fb7d-d3b6-4b6a-b6a0-d0037573e423") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("69226be5-f2f4-4f70-b20e-a09bbc24b88e") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("69be7f56-da99-46d3-a83a-565d04423eff") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("6a76390e-6d2f-4e8e-8b2d-f72d9ad3a200") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("71a69f28-9008-4161-93a5-669d06ebd80c") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("752fa4a9-e6e8-4458-b515-d36ccd6ac81e") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("75a9729e-25a8-45db-9be1-6abf0ffd07a1") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("77164ae6-89fa-4dec-8e71-29083c12c7bf") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("7b6c1a1a-f48b-430e-874c-982133dd7064") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("7d37837c-f4de-40e9-9447-c7d67282a952") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("7fa595a8-92cf-4d79-800d-55e2a139331a") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("8012cdc7-10b5-493f-b53b-f821f706bb12") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("80e2af48-56a3-43cf-8f4a-e70efcbd2143") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("8122fe85-8315-4566-be58-61ca5769e97b") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("85051083-f17e-40b5-9460-ce6aa57b40a7") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("8d63dcbf-5f35-4ac9-927f-bbbe8d0218ec") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("a0e83922-d529-4af5-8ffa-a426c656611c") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("b0909486-08be-417f-b7f2-b3f279e7ca9c") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("b2de8db0-d347-4724-b784-d297d23ddc5b") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("b2ec5cfd-8262-4e35-bb8f-3de9ed72c8c0") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("b65de807-7ce9-4696-b60f-ef15551e869e") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("c1886afe-8e7b-4a04-9f31-f47cebb3f3c5") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("c74819ae-1907-476c-a2a9-2f81ee5a3d15") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("c98cc0ea-38f6-4a80-88aa-c51eb3a41e5d") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("ca5de21d-c7a4-4f48-98fd-1eb5cc43ff03") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("cd7482b0-24df-403a-a055-edaa10b93062") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("d0b88306-58f3-4991-be31-a47b0ede16ea") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("d0b9bf92-65f4-48dc-a66d-79c7eef03b60") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("d4c42c29-b0f1-47ad-8d69-5a79194d9d76") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("de601fa9-d231-475a-adf0-521434f46744") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("e88edee9-5c05-4d6e-943f-57c28abb8cd8") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("ed349a5b-034e-4b48-9c9f-1b1996037b3d") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("ee8128f6-0c56-413f-9700-424854c92d49") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("f16a6f09-bdb3-4eff-9003-ae6045a64d4d") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("f569f2fd-92d5-4967-849e-c6c8af19bd9a") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("f75f64be-5206-4c52-9522-12efcf1bebeb") },
                    { new Guid("6c650047-6b46-48ab-856c-bc08aae987d1"), new Guid("fea335d4-b8ae-452e-95df-b0cea1c79037") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("018a8a51-64c3-435e-92c7-c0fc58eaeae0") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("047d508e-2167-4ca3-8d91-38ab4691ea37") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("0672763c-ca61-476b-b0e6-db764348a698") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("06e30e1e-6423-4216-9ced-6824d997e672") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("06f5b2ee-b58c-48b0-ada4-f54c34405d9f") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("0aa7f93d-e33f-4aec-91f3-5f7946162ff0") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("0bdb7f29-0b54-48ee-b443-4554e526b5ea") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("108db650-fbe8-416e-ac7b-2af139f76732") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("1563dd10-3704-4644-90e3-758825d64189") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("199989cf-b202-400e-a20d-5453d49ac9df") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("1cc62a04-ac87-4ae3-9952-08c3c8963bf3") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("2194017e-62cd-41f5-85b9-9b709010f87f") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("256cdc05-111e-4d24-8b53-8ff256c16ac7") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("29788545-4f0f-4fae-9489-9c27de7821b2") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("2b6ce2f3-f882-428e-86f8-3f2bc36823c3") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("2e431c7d-5215-48c1-8e1c-4a9dcbf62f10") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("32c3085c-a29a-4b46-9f06-9e3c74afe348") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("3397e792-cfe5-4010-a324-e0234732c723") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("3998bb73-468a-4796-9be9-937f783d02ac") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("3e63fa84-8624-4f24-ba56-0ddd4454305f") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("424d9ea2-9521-4f1a-abef-7fca4c04e1b2") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("428829b3-91dc-41ba-b704-9012a01f1c29") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("45d61401-d21c-4db9-8d77-564fb055bb7e") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("466a499d-1dc0-4d55-9f88-9eee973f8e5d") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("477e12a1-9ce8-4ad0-8edf-3a0ef1b373a3") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("5197b475-593f-46fb-8a10-552a45ff9a25") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("524ce5d5-a7f9-4fde-ab3a-5d0828da0898") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("5280da7d-c447-4752-93ba-f770f3e32623") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("5be514b4-f6b9-4067-a0bb-3028672c3f5c") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("5dd669f1-4e13-411e-929f-2fd706c67260") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("67c84af0-e3f0-4741-aee3-e9678c2a8526") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("69226be5-f2f4-4f70-b20e-a09bbc24b88e") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("6a76390e-6d2f-4e8e-8b2d-f72d9ad3a200") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("7075686b-9fa9-475b-bcd3-9c5f87a85d82") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("71a69f28-9008-4161-93a5-669d06ebd80c") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("752fa4a9-e6e8-4458-b515-d36ccd6ac81e") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("75a9729e-25a8-45db-9be1-6abf0ffd07a1") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("77164ae6-89fa-4dec-8e71-29083c12c7bf") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("7aa3ce93-631a-44c2-a662-7fa76eee4871") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("7af9b388-2cff-4be3-a687-e09b07dddb59") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("7b6c1a1a-f48b-430e-874c-982133dd7064") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("7fa595a8-92cf-4d79-800d-55e2a139331a") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("8012cdc7-10b5-493f-b53b-f821f706bb12") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("8d63dcbf-5f35-4ac9-927f-bbbe8d0218ec") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("9a943d8c-4402-401a-9bba-9b7e45a4d0d2") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("a36bd4ac-fc59-4f7c-9019-6092c64a108c") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("af82d7ad-2ec6-46c5-a628-e307703d93c8") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("b0909486-08be-417f-b7f2-b3f279e7ca9c") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("b2de8db0-d347-4724-b784-d297d23ddc5b") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("b2ec5cfd-8262-4e35-bb8f-3de9ed72c8c0") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("c1886afe-8e7b-4a04-9f31-f47cebb3f3c5") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("c74819ae-1907-476c-a2a9-2f81ee5a3d15") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("c98cc0ea-38f6-4a80-88aa-c51eb3a41e5d") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("ca5de21d-c7a4-4f48-98fd-1eb5cc43ff03") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("cd7482b0-24df-403a-a055-edaa10b93062") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("d4c42c29-b0f1-47ad-8d69-5a79194d9d76") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("de601fa9-d231-475a-adf0-521434f46744") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("e0b7a410-51ef-4ad9-a78a-af7d2016c5ad") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("e88edee9-5c05-4d6e-943f-57c28abb8cd8") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("f16a6f09-bdb3-4eff-9003-ae6045a64d4d") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("f75f64be-5206-4c52-9522-12efcf1bebeb") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("fd56d843-348e-4f39-8500-4ff9da3c55e2") },
                    { new Guid("c57e344b-9ee6-4000-858e-6278697f1ab3"), new Guid("fea335d4-b8ae-452e-95df-b0cea1c79037") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductsId",
                table: "ProductCategory",
                column: "ProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
