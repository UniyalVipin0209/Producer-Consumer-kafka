using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProducerServices.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderRequests",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRequests", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Name", "Pincode" },
                values: new object[,]
                {
                    { 1, "Electronic City, Bangalore", "Pankaj", "560100" },
                    { 2, "HSR, Bangalore", "Alok", "560089" },
                    { 3, "HSR, Bangalore", "Harshita", "560088" },
                    { 4, "Electronic City, Bangalore", "Pankaj", "560100" }
                });

            migrationBuilder.InsertData(
                table: "OrderRequests",
                columns: new[] { "OrderId", "CustomerId", "ProductId", "Quantity", "Status" },
                values: new object[,]
                {
                    { 1, 1, 3, 34, "Delayed" },
                    { 2, 3, 2, 24, "Delayed" },
                    { 3, 2, 2, 34, "Delayed" },
                    { 4, 4, 2, 24, "Delayed" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Perfumes" },
                    { 2, "Jeans Pants" },
                    { 3, "Woman Suits" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "OrderRequests");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
