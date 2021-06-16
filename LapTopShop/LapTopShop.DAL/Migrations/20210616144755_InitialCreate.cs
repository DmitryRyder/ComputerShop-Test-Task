using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LapTopShop.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigurationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConfigurationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configurations_ConfigurationTypes_ConfigurationTypeId",
                        column: x => x.ConfigurationTypeId,
                        principalTable: "ConfigurationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManufacturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laptops_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LaptopConfigurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LaptopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConfigurationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaptopConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaptopConfigurations_Configurations_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "Configurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LaptopConfigurations_Laptops_LaptopId",
                        column: x => x.LaptopId,
                        principalTable: "Laptops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LaptopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Laptops_LaptopId",
                        column: x => x.LaptopId,
                        principalTable: "Laptops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ConfigurationTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("c6536d6b-e9eb-4f60-a0da-66937e1ea5dd"), "Ram" },
                    { new Guid("4ebe08ef-e10e-4443-946a-8c19da907998"), "HDD" },
                    { new Guid("503d743b-c33d-4789-bfa6-608f512f744a"), "Colour" },
                    { new Guid("7a14a4fe-caeb-42cf-a31f-96952636e155"), "Processor" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("654b7573-9501-436a-ad36-94c5696ac28f"), "Dell", 135.11m },
                    { new Guid("0d9ffad1-0149-432b-b94d-3442707160db"), "Toshiba", 135.11m },
                    { new Guid("9c32d6f4-b527-4839-ba4f-1d1b9740dd4b"), "HP", 135.11m },
                    { new Guid("c2e1bb5f-6e45-4881-8d75-c3d6d18358fb"), "Apple", 135.11m }
                });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "ConfigurationTypeId", "Price", "Value" },
                values: new object[,]
                {
                    { new Guid("413e3ddc-7064-404b-8fa5-41f664473177"), new Guid("c6536d6b-e9eb-4f60-a0da-66937e1ea5dd"), 535.21m, "8 GB" },
                    { new Guid("269ed5d8-1273-441b-8839-35f20bb54508"), new Guid("4ebe08ef-e10e-4443-946a-8c19da907998"), 635.21m, "16 GB" },
                    { new Guid("ffbe392e-8812-4831-96c5-dc97b6e79a46"), new Guid("4ebe08ef-e10e-4443-946a-8c19da907998"), 535.21m, "500 GB" },
                    { new Guid("1ad30101-f986-4a53-a11a-db359da3b15e"), new Guid("4ebe08ef-e10e-4443-946a-8c19da907998"), 535.21m, "1 TB" },
                    { new Guid("40f89c10-366e-44b7-b836-130d7ac1471b"), new Guid("503d743b-c33d-4789-bfa6-608f512f744a"), 535.21m, "8 GB" },
                    { new Guid("02c447bc-5093-443e-926a-ead26ef9c92e"), new Guid("503d743b-c33d-4789-bfa6-608f512f744a"), 535.21m, "Red" },
                    { new Guid("c96284ed-2a78-41d6-b888-b437475b774b"), new Guid("503d743b-c33d-4789-bfa6-608f512f744a"), 535.21m, "Blue" }
                });

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "Id", "ManufacturerId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("6307149d-74e1-4baf-8b59-a98895217f65"), new Guid("0d9ffad1-0149-432b-b94d-3442707160db"), "Bysiness laptop", 0m },
                    { new Guid("27ce6a5a-8036-41d8-b4a3-24386fb7c971"), new Guid("9c32d6f4-b527-4839-ba4f-1d1b9740dd4b"), "Gaming laptop", 0m },
                    { new Guid("0b27d46f-4301-4f3f-b480-383f1b297bee"), new Guid("9c32d6f4-b527-4839-ba4f-1d1b9740dd4b"), "Lite laptop", 0m }
                });

            migrationBuilder.InsertData(
                table: "LaptopConfigurations",
                columns: new[] { "Id", "ConfigurationId", "LaptopId" },
                values: new object[] { new Guid("fb000c38-19b8-445d-b23f-be079732af99"), new Guid("413e3ddc-7064-404b-8fa5-41f664473177"), new Guid("6307149d-74e1-4baf-8b59-a98895217f65") });

            migrationBuilder.InsertData(
                table: "LaptopConfigurations",
                columns: new[] { "Id", "ConfigurationId", "LaptopId" },
                values: new object[] { new Guid("f625cf2b-961e-4031-9615-f4b198864957"), new Guid("269ed5d8-1273-441b-8839-35f20bb54508"), new Guid("27ce6a5a-8036-41d8-b4a3-24386fb7c971") });

            migrationBuilder.InsertData(
                table: "LaptopConfigurations",
                columns: new[] { "Id", "ConfigurationId", "LaptopId" },
                values: new object[] { new Guid("45703ceb-c89d-4abb-80a5-d1a5b8a11288"), new Guid("ffbe392e-8812-4831-96c5-dc97b6e79a46"), new Guid("0b27d46f-4301-4f3f-b480-383f1b297bee") });

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_ConfigurationTypeId",
                table: "Configurations",
                column: "ConfigurationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LaptopConfigurations_ConfigurationId",
                table: "LaptopConfigurations",
                column: "ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_LaptopConfigurations_LaptopId",
                table: "LaptopConfigurations",
                column: "LaptopId");

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_ManufacturerId",
                table: "Laptops",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LaptopId",
                table: "Orders",
                column: "LaptopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LaptopConfigurations");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "Laptops");

            migrationBuilder.DropTable(
                name: "ConfigurationTypes");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
