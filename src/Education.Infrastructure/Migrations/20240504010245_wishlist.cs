using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class wishlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Coupons_CouponId",
                table: "Courses");

            migrationBuilder.AlterColumn<Guid>(
                name: "CouponId",
                table: "Courses",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "WishListId",
                table: "Courses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WishListId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WishList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishList", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_WishListId",
                table: "Courses",
                column: "WishListId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WishListId",
                table: "AspNetUsers",
                column: "WishListId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_WishList_WishListId",
                table: "AspNetUsers",
                column: "WishListId",
                principalTable: "WishList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Coupons_CouponId",
                table: "Courses",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_WishList_WishListId",
                table: "Courses",
                column: "WishListId",
                principalTable: "WishList",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_WishList_WishListId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Coupons_CouponId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_WishList_WishListId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "WishList");

            migrationBuilder.DropIndex(
                name: "IX_Courses_WishListId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WishListId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WishListId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "WishListId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "CouponId",
                table: "Courses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Coupons_CouponId",
                table: "Courses",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
