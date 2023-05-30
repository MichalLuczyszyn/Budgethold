using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "wallets");

            migrationBuilder.CreateTable(
                name: "wallets",
                schema: "wallets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    WalletType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ArchivedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wallets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "wallets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ArchivedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    WalletId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_wallets_WalletId",
                        column: x => x.WalletId,
                        principalSchema: "wallets",
                        principalTable: "wallets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "repeatableTransactions",
                schema: "wallets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(19,4)", precision: 19, scale: 4, nullable: false),
                    Currency = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ArchivedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    StartsAt = table.Column<DateOnly>(type: "date", nullable: false),
                    Interval = table.Column<short>(type: "smallint", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    WalletId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_repeatableTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_repeatableTransactions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "wallets",
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_repeatableTransactions_wallets_WalletId",
                        column: x => x.WalletId,
                        principalSchema: "wallets",
                        principalTable: "wallets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                schema: "wallets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(19,4)", precision: 19, scale: 4, nullable: false),
                    Currency = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TransactionType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ArchivedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    WalletId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    RepeatableTransactionId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transactions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "wallets",
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_transactions_repeatableTransactions_RepeatableTransactionId",
                        column: x => x.RepeatableTransactionId,
                        principalSchema: "wallets",
                        principalTable: "repeatableTransactions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_transactions_wallets_WalletId",
                        column: x => x.WalletId,
                        principalSchema: "wallets",
                        principalTable: "wallets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_WalletId",
                schema: "wallets",
                table: "Categories",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_repeatableTransactions_CategoryId",
                schema: "wallets",
                table: "repeatableTransactions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_repeatableTransactions_WalletId",
                schema: "wallets",
                table: "repeatableTransactions",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_CategoryId",
                schema: "wallets",
                table: "transactions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_RepeatableTransactionId",
                schema: "wallets",
                table: "transactions",
                column: "RepeatableTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_WalletId",
                schema: "wallets",
                table: "transactions",
                column: "WalletId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactions",
                schema: "wallets");

            migrationBuilder.DropTable(
                name: "repeatableTransactions",
                schema: "wallets");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "wallets");

            migrationBuilder.DropTable(
                name: "wallets",
                schema: "wallets");
        }
    }
}
