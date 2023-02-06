using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderInformation.Repository.Migrations
{
    /// <inheritdoc />
    public partial class OrderInformationAppMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerOrderNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SystemOrderNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutputAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    QuantityUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    WeightUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderStatu = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Code", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "KLM001", new DateTime(2023, 2, 4, 14, 12, 14, 621, DateTimeKind.Local).AddTicks(913), "Kurşun Kalem", null },
                    { 2, "KLM002", new DateTime(2023, 2, 4, 14, 12, 14, 621, DateTimeKind.Local).AddTicks(915), "Tükenmez Kalem", null }
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 4, 14, 12, 14, 621, DateTimeKind.Local).AddTicks(740), "Sipariş Alındı", null },
                    { 2, new DateTime(2023, 2, 4, 14, 12, 14, 621, DateTimeKind.Local).AddTicks(754), "Yola Çıktı", null },
                    { 3, new DateTime(2023, 2, 4, 14, 12, 14, 621, DateTimeKind.Local).AddTicks(755), "Dağıtım Merkezinde", null },
                    { 4, new DateTime(2023, 2, 4, 14, 12, 14, 621, DateTimeKind.Local).AddTicks(756), "Dağıtıma Çıktı", null },
                    { 5, new DateTime(2023, 2, 4, 14, 12, 14, 621, DateTimeKind.Local).AddTicks(757), "Teslim Edildi", null },
                    { 6, new DateTime(2023, 2, 4, 14, 12, 14, 621, DateTimeKind.Local).AddTicks(758), "Teslim Edilemedi", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "OrderInfos");

            migrationBuilder.DropTable(
                name: "OrderStatuses");
        }
    }
}
