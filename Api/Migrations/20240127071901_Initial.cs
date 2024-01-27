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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                    table.PrimaryKey("PK__Customer__7981F974B86BA1EE", x => x.CustomerStatusId);
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
                    table.PrimaryKey("PK__Effect__6B859F23BED7B681", x => x.EffectId);
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
                    table.PrimaryKey("PK__Employee__6FDE9060D9FF1EAD", x => x.EmployeePositionId);
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
                    table.PrimaryKey("PK__Employee__3609932CB65FC2EC", x => x.EmployeeStatusId);
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
                    table.PrimaryKey("PK__OrderSta__BC674CA1510AA2EE", x => x.OrderStatusId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    LastName = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    CustomerStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__A4AE64D8CBE501C6", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK__Customer__Custom__403A8C7D",
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
                    table.PrimaryKey("PK__Ingredie__BEAEB25AA64D6969", x => x.IngredientId);
                    table.ForeignKey(
                        name: "FK__Ingredien__Effec__44FF419A",
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
                    FirstName = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    LastName = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    EmployeeStatusId = table.Column<int>(type: "int", nullable: true),
                    EmployeePositionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__7AD04F115D99E99C", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK__Employee__Employ__3A81B327",
                        column: x => x.EmployeeStatusId,
                        principalTable: "EmployeeStatus",
                        principalColumn: "EmployeeStatusId");
                    table.ForeignKey(
                        name: "FK__Employee__Employ__3B75D760",
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
                    table.PrimaryKey("PK__Order__C3905BCF1D790DE4", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK__Order__CustomerI__49C3F6B7",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK__Order__OrderStat__4AB81AF0",
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
                    table.PrimaryKey("PK__Potion__37C41B078A21A008", x => x.PotionId);
                    table.ForeignKey(
                        name: "FK__Potion__Employee__5165187F",
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
                    table.PrimaryKey("PK__OrderIng__A3146CFA636D3C59", x => x.OrderIngredientId);
                    table.ForeignKey(
                        name: "FK__OrderIngr__Ingre__5BE2A6F2",
                        column: x => x.IngredientId,
                        principalTable: "Ingredient",
                        principalColumn: "IngredientId");
                    table.ForeignKey(
                        name: "FK__OrderIngr__Order__5CD6CB2B",
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
                    table.PrimaryKey("PK__Receipt__CC08C420FACD8524", x => x.ReceiptId);
                    table.ForeignKey(
                        name: "FK__Receipt__Employe__4D94879B",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK__Receipt__OrderId__4E88ABD4",
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
                    table.PrimaryKey("PK__OrderPot__49211579C8B701A8", x => x.OrderPotionId);
                    table.ForeignKey(
                        name: "FK__OrderPoti__Order__59063A47",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK__OrderPoti__Potio__5812160E",
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
                    table.PrimaryKey("PK__PotionEf__57036DA8465B70FF", x => x.PotionEffectId);
                    table.ForeignKey(
                        name: "FK__PotionEff__Effec__5535A963",
                        column: x => x.EffectId,
                        principalTable: "Effect",
                        principalColumn: "EffectId");
                    table.ForeignKey(
                        name: "FK__PotionEff__Potio__5441852A",
                        column: x => x.PotionId,
                        principalTable: "Potion",
                        principalColumn: "PotionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderIngredient");

            migrationBuilder.DropTable(
                name: "OrderPotion");

            migrationBuilder.DropTable(
                name: "PotionEffect");

            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
