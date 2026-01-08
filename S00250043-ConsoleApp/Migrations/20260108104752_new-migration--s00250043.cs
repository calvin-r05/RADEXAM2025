using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace S00250043_ConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class newmigrations00250043 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Category_id);
                });

            migrationBuilder.CreateTable(
                name: "OrderData",
                columns: table => new
                {
                    Order_item_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_id = table.Column<int>(type: "int", nullable: false),
                    Collectible_id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Unit_price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderData", x => x.Order_item_id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    Total_price = table.Column<double>(type: "float", nullable: false),
                    Payment_status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Order_id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Collectible_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category_id = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock_quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Collectible_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Category_id", "Name" },
                values: new object[,]
                {
                    { 1, "Trading Cards" },
                    { 2, "Action Figures" }
                });

            migrationBuilder.InsertData(
                table: "OrderData",
                columns: new[] { "Order_item_id", "Collectible_id", "Order_id", "Quantity", "Unit_price" },
                values: new object[,]
                {
                    { 1, 1, 101, 1, 120.0 },
                    { 2, 2, 102, 1, 80.0 },
                    { 3, 3, 102, 1, 95.5 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Order_id", "Order_status", "Payment_status", "Total_price", "User_id" },
                values: new object[,]
                {
                    { 101, "Shipped", "Paid", 120.0, 1 },
                    { 102, "Processing", "Pending", 175.5, 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Collectible_id", "Category_id", "Condition", "Name", "Price", "Stock_quantity" },
                values: new object[,]
                {
                    { 1, 1, "Mint", "Pikachu Holo Card", 120.0, 5 },
                    { 2, 2, "Good", "Batman Figure", 80.0, 3 },
                    { 3, 2, "Near Mint", "Yoda Figure", 95.5, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "User_id", "Email", "Name", "Role" },
                values: new object[,]
                {
                    { 1, "alice@example.com", "Alice Carter", "Customer" },
                    { 2, "bob@example.com", "Bob Nguyen", "Customer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "OrderData");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
