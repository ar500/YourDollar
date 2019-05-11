using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YourDollar.API.Migrations
{
    public partial class AddedExpenseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ExpenseId = table.Column<Guid>(nullable: false),
                    BudgetCategoryCategoryId = table.Column<Guid>(nullable: false),
                    ShortName = table.Column<string>(maxLength: 20, nullable: false),
                    PayoutDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyAccountNumber = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    IsRecurring = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ExpenseId);
                    table.ForeignKey(
                        name: "FK_Expenses_BudgetCategories_BudgetCategoryCategoryId",
                        column: x => x.BudgetCategoryCategoryId,
                        principalTable: "BudgetCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_BudgetCategoryCategoryId",
                table: "Expenses",
                column: "BudgetCategoryCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");
        }
    }
}
