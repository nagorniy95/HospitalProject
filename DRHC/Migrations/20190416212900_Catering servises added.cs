using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DRHC.Migrations
{
    public partial class Cateringservisesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumberOfGuest = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestID);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemName = table.Column<string>(maxLength: 255, nullable: false),
                    Price = table.Column<string>(maxLength: 255, nullable: false),
                    Type = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    GuestID = table.Column<int>(nullable: false),
                    NonVeg = table.Column<float>(maxLength: 255, nullable: false),
                    Number = table.Column<string>(maxLength: 255, nullable: false),
                    Time = table.Column<string>(maxLength: 255, nullable: false),
                    UserFName = table.Column<string>(maxLength: 255, nullable: false),
                    UserLName = table.Column<string>(maxLength: 255, nullable: false),
                    Veg = table.Column<float>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Guests_GuestID",
                        column: x => x.GuestID,
                        principalTable: "Guests",
                        principalColumn: "GuestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderXMenus",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false),
                    ItemID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderXMenus", x => new { x.OrderID, x.ItemID });
                    table.ForeignKey(
                        name: "FK_OrderXMenus_Menus_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Menus",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderXMenus_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_GuestID",
                table: "Orders",
                column: "GuestID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderXMenus_ItemID",
                table: "OrderXMenus",
                column: "ItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderXMenus");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Guests");
        }
    }
}
