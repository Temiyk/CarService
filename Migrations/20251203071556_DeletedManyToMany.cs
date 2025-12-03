using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace coursa4.Migrations
{
    /// <inheritdoc />
    public partial class DeletedManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderEmployees_Employees_EmployeesId",
                table: "OrderEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderEmployees_Orders_OrdersId",
                table: "OrderEmployees");

            migrationBuilder.DropTable(
                name: "OrderServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderEmployees",
                table: "OrderEmployees");

            migrationBuilder.RenameTable(
                name: "OrderEmployees",
                newName: "EmployeeOrder");

            migrationBuilder.RenameIndex(
                name: "IX_OrderEmployees_OrdersId",
                table: "EmployeeOrder",
                newName: "IX_EmployeeOrder_OrdersId");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Services",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeOrder",
                table: "EmployeeOrder",
                columns: new[] { "EmployeesId", "OrdersId" });

            migrationBuilder.CreateIndex(
                name: "IX_Services_OrderId",
                table: "Services",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeOrder_Employees_EmployeesId",
                table: "EmployeeOrder",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeOrder_Orders_OrdersId",
                table: "EmployeeOrder",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Orders_OrderId",
                table: "Services",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeOrder_Employees_EmployeesId",
                table: "EmployeeOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeOrder_Orders_OrdersId",
                table: "EmployeeOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Orders_OrderId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_OrderId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeOrder",
                table: "EmployeeOrder");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Services");

            migrationBuilder.RenameTable(
                name: "EmployeeOrder",
                newName: "OrderEmployees");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeOrder_OrdersId",
                table: "OrderEmployees",
                newName: "IX_OrderEmployees_OrdersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderEmployees",
                table: "OrderEmployees",
                columns: new[] { "EmployeesId", "OrdersId" });

            migrationBuilder.CreateTable(
                name: "OrderServices",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    ServicesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderServices", x => new { x.OrderId, x.ServicesId });
                    table.ForeignKey(
                        name: "FK_OrderServices_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderServices_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderServices_ServicesId",
                table: "OrderServices",
                column: "ServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEmployees_Employees_EmployeesId",
                table: "OrderEmployees",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEmployees_Orders_OrdersId",
                table: "OrderEmployees",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
