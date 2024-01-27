using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerStatus",
                columns: table => new
                {
                    CustomerStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__7981F974F0CD2871", x => x.CustomerStatusId);
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
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    Password = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    Name = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    CustomerStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__A4AE64D886D2B2B2", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK__Customer__Custom__5EBF139D",
                        column: x => x.CustomerStatusId,
                        principalTable: "CustomerStatus",
                        principalColumn: "CustomerStatusId");
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
                    Image = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    EffectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ingredie__BEAEB25AF7375E9D", x => x.IngredientId);
                    table.ForeignKey(
                        name: "FK__Ingredien__Effec__6FE99F9F",
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
                    EmployeePositionId = table.Column<int>(type: "int", nullable: true),
                    DateTerminated = table.Column<DateOnly>(type: "date", nullable: true)
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
                    table.PrimaryKey("PK__Order__C3905BCF83ECF446", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK__Order__CustomerI__619B8048",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK__Order__OrderStat__628FA481",
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
                name: "OrderIngredient",
                columns: table => new
                {
                    OrderIngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderIng__A3146CFAFE93B5E3", x => x.OrderIngredientId);
                    table.ForeignKey(
                        name: "FK__OrderIngr__Ingre__06CD04F7",
                        column: x => x.IngredientId,
                        principalTable: "Ingredient",
                        principalColumn: "IngredientId");
                    table.ForeignKey(
                        name: "FK__OrderIngr__Order__07C12930",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId");
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
                    table.PrimaryKey("PK__Receipt__CC08C420DB8611F0", x => x.ReceiptId);
                    table.ForeignKey(
                        name: "FK__Receipt__Employe__656C112C",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK__Receipt__OrderId__66603565",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateTable(
                name: "OrderPotion",
                columns: table => new
                {
                    OrderPotionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PotionId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderPot__49211579A05C96F4", x => x.OrderPotionId);
                    table.ForeignKey(
                        name: "FK__OrderPoti__Order__03F0984C",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK__OrderPoti__Potio__02FC7413",
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
                name: "IX_Customer_CustomerStatusId",
                table: "Customer",
                column: "CustomerStatusId");

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
                name: "IX_OrderIngredient_IngredientId",
                table: "OrderIngredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderIngredient_OrderId",
                table: "OrderIngredient",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPotion_OrderId",
                table: "OrderPotion",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPotion_PotionId",
                table: "OrderPotion",
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
                name: "OrderIngredient");

            migrationBuilder.DropTable(
                name: "OrderPotion");

            migrationBuilder.DropTable(
                name: "PotionEffect");

            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Potion");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Effect");

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

            migrationBuilder.DropTable(
                name: "CustomerStatus");
        }
    }
}
