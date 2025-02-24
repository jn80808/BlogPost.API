using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogPost.API.Migrations
{
    /// <inheritdoc />
    public partial class Recreate_BlogPost_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlHandle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogPostT",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeatureImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlHandle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPostT_BlogCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "BlogCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_BlogPostT_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "BlogPostT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BlogCategory",
                columns: new[] { "Id", "Description", "Name", "UrlHandle" },
                values: new object[,]
                {
                    { new Guid("68b08ae7-8c0e-45de-b9e0-655a33ca91a0"), "Money management and investment advice", "Finance", "finance" },
                    { new Guid("86a59b54-90ce-46d9-982e-23635ae8f876"), "Latest tech trends and news", "Technology", "technology" },
                    { new Guid("dbed4bcf-5ea0-4578-bde7-26ee4285ff2a"), "Health, wellness, and daily life tips", "Lifestyle", "lifestyle" }
                });

            migrationBuilder.InsertData(
                table: "BlogPostT",
                columns: new[] { "Id", "AuthorName", "CategoryId", "Content", "CreatedAt", "FeatureImageUrl", "IsPublished", "IsVisible", "PublishedDate", "ShortDescription", "Title", "UrlHandle" },
                values: new object[,]
                {
                    { new Guid("6596baae-f88f-487c-8b2a-3e31f997626e"), "Jane Smith", new Guid("dbed4bcf-5ea0-4578-bde7-26ee4285ff2a"), "Here are some productivity hacks...", new DateTime(2025, 2, 24, 13, 46, 46, 219, DateTimeKind.Utc).AddTicks(3026), "productivity.jpg", true, true, new DateTime(2025, 2, 24, 13, 46, 46, 219, DateTimeKind.Utc).AddTicks(3024), "Increase your efficiency", "Best Productivity Hacks", "best-productivity-hacks" },
                    { new Guid("68e553ab-5417-4e80-b7a0-7c168423e0dc"), "John Doe", new Guid("86a59b54-90ce-46d9-982e-23635ae8f876"), "AI is evolving rapidly...", new DateTime(2025, 2, 24, 13, 46, 46, 219, DateTimeKind.Utc).AddTicks(3019), "ai.jpg", true, true, new DateTime(2025, 2, 24, 13, 46, 46, 219, DateTimeKind.Utc).AddTicks(3014), "Exploring AI advancements", "The Future of AI", "future-of-ai" },
                    { new Guid("84ec1dfb-fb78-4df1-8c3c-0ec0b92042d5"), "Mark Brown", new Guid("68b08ae7-8c0e-45de-b9e0-655a33ca91a0"), "Managing your finances is important...", new DateTime(2025, 2, 24, 13, 46, 46, 219, DateTimeKind.Utc).AddTicks(3043), "finance.jpg", true, true, new DateTime(2025, 2, 24, 13, 46, 46, 219, DateTimeKind.Utc).AddTicks(3042), "Smart saving tips", "How to Save Money", "how-to-save-money" }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AuthorName", "BlogPostId", "Content", "CreatedAt" },
                values: new object[,]
                {
                    { new Guid("18ffc619-9e42-43dc-8538-d1ca22f89fc5"), "Alice", new Guid("68e553ab-5417-4e80-b7a0-7c168423e0dc"), "Great insights on AI!", new DateTime(2025, 2, 24, 13, 46, 46, 219, DateTimeKind.Utc).AddTicks(3077) },
                    { new Guid("4c74cb5f-f619-4896-a8f7-147d46cdd7b8"), "Charlie", new Guid("84ec1dfb-fb78-4df1-8c3c-0ec0b92042d5"), "Thanks for the tips!", new DateTime(2025, 2, 24, 13, 46, 46, 219, DateTimeKind.Utc).AddTicks(3085) },
                    { new Guid("a20c9199-8e52-4698-85da-3d328959efa9"), "Bob", new Guid("6596baae-f88f-487c-8b2a-3e31f997626e"), "These hacks really helped!", new DateTime(2025, 2, 24, 13, 46, 46, 219, DateTimeKind.Utc).AddTicks(3082) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostT_CategoryId",
                table: "BlogPostT",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_BlogPostId",
                table: "Comment",
                column: "BlogPostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "BlogPostT");

            migrationBuilder.DropTable(
                name: "BlogCategory");
        }
    }
}
