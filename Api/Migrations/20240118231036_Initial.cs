using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    Password = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    Name = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__A4AE64D8154FFD7E", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Effect",
                columns: table => new
                {
                    EffectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Effect__6B859F23B4842032", x => x.EffectId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePosition",
                columns: table => new
                {
                    EmployeePositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__6FDE90608211D274", x => x.EmployeePositionId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeStatus",
                columns: table => new
                {
                    EmployeeStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__3609932CFFE47B28", x => x.EmployeeStatusId);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    OrderStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderSta__BC674CA10766E817", x => x.OrderStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    Description = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: true),
                    CurrentStock = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<int>(type: "int", nullable: true),
                    EffectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ingredie__BEAEB25AD0ADB01F", x => x.IngredientId);
                    table.ForeignKey(
                        name: "FK__Ingredien__Effec__4222D4EF",
                        column: x => x.EffectId,
                        principalTable: "Effect",
                        principalColumn: "EffectId");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    Password = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    Name = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    DateHired = table.Column<DateOnly>(type: "date", nullable: true),
                    EmployeeStatusId = table.Column<int>(type: "int", nullable: true),
                    EmployeePositionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__7AD04F111E192696", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK__Employee__Employ__3A81B327",
                        column: x => x.EmployeeStatusId,
                        principalTable: "EmployeeStatus",
                        principalColumn: "EmployeeStatusId");
                    table.ForeignKey(
                        name: "FK__Employee__Positi__3B75D760",
                        column: x => x.EmployeePositionId,
                        principalTable: "EmployeePosition",
                        principalColumn: "EmployeePositionId");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    OrderStatusId = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: true),
                    DatePlaced = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order__C3905BCF73F1FB28", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK__Order__CustomerI__46E78A0C",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK__Order__OrderStat__47DBAE45",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "OrderStatusId");
                });

            migrationBuilder.CreateTable(
                name: "Potion",
                columns: table => new
                {
                    PotionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    Description = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: true),
                    CurrentStock = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Potion__37C41B07D900FFC5", x => x.PotionId);
                    table.ForeignKey(
                        name: "FK__Potion__Employee__4E88ABD4",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    ReceiptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptNumber = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    DateFulfilled = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Receipt__CC08C420D945D5F2", x => x.ReceiptId);
                    table.ForeignKey(
                        name: "FK__Receipt__Employe__4AB81AF0",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK__Receipt__OrderId__4BAC3F29",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateTable(
                name: "OrderPotions",
                columns: table => new
                {
                    OrderPotionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PotionId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderPot__492115791E886E61", x => x.OrderPotionId);
                    table.ForeignKey(
                        name: "FK__OrderPoti__Order__5629CD9C",
                        column: x => x.OrderId,
                        principalTable: "Potion",
                        principalColumn: "PotionId");
                    table.ForeignKey(
                        name: "FK__OrderPoti__Potio__5535A963",
                        column: x => x.PotionId,
                        principalTable: "Potion",
                        principalColumn: "PotionId");
                });

            migrationBuilder.CreateTable(
                name: "PotionEffect",
                columns: table => new
                {
                    PotionEffectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PotionId = table.Column<int>(type: "int", nullable: true),
                    EffectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PotionEf__57036DA83F8897E4", x => x.PotionEffectId);
                    table.ForeignKey(
                        name: "FK__PotionEff__Effec__52593CB8",
                        column: x => x.EffectId,
                        principalTable: "Effect",
                        principalColumn: "EffectId");
                    table.ForeignKey(
                        name: "FK__PotionEff__Potio__5165187F",
                        column: x => x.PotionId,
                        principalTable: "Potion",
                        principalColumn: "PotionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeePositionId",
                table: "Employee",
                column: "EmployeePositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeStatusId",
                table: "Employee",
                column: "EmployeeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_EffectId",
                table: "Ingredient",
                column: "EffectId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStatusId",
                table: "Order",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPotions_OrderId",
                table: "OrderPotions",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPotions_PotionId",
                table: "OrderPotions",
                column: "PotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Potion_EmployeeId",
                table: "Potion",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PotionEffect_EffectId",
                table: "PotionEffect",
                column: "EffectId");

            migrationBuilder.CreateIndex(
                name: "IX_PotionEffect_PotionId",
                table: "PotionEffect",
                column: "PotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_EmployeeId",
                table: "Receipt",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_OrderId",
                table: "Receipt",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "OrderPotions");

            migrationBuilder.DropTable(
                name: "PotionEffect");

            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "Effect");

            migrationBuilder.DropTable(
                name: "Potion");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "EmployeeStatus");

            migrationBuilder.DropTable(
                name: "EmployeePosition");
        }
    }
}
