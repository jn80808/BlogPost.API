using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogPost.API.Migrations
{
    /// <inheritdoc />
    public partial class AddBlogPostCategoryManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogCategory_BlogCategory_BlogCategoryId",
                table: "BlogCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostT_BlogPostT_BlogPostTId",
                table: "BlogPostT");

            migrationBuilder.DropIndex(
                name: "IX_BlogPostT_BlogPostTId",
                table: "BlogPostT");

            migrationBuilder.DropIndex(
                name: "IX_BlogCategory_BlogCategoryId",
                table: "BlogCategory");

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("3267a5b6-4fdc-4f3b-ab99-2b6b6c920d68"));

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("5eebe1e3-9ec8-4b63-b79b-868afd7b2bec"));

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("af5285e6-ca70-410d-bced-4c764000e980"));

            migrationBuilder.DeleteData(
                table: "BlogPostT",
                keyColumn: "Id",
                keyValue: new Guid("c7cd6a9d-f860-4508-865b-026faf8cf0cc"));

            migrationBuilder.DeleteData(
                table: "BlogPostT",
                keyColumn: "Id",
                keyValue: new Guid("e940637e-ec9a-43f2-8766-8f8eb78c7b8c"));

            migrationBuilder.DeleteData(
                table: "BlogPostT",
                keyColumn: "Id",
                keyValue: new Guid("eaf65822-e4c5-49d1-92ee-48945d12558e"));

            migrationBuilder.DeleteData(
                table: "BlogCategory",
                keyColumn: "Id",
                keyValue: new Guid("4f118e0f-c6d4-449b-9e61-6f5e38df43ec"));

            migrationBuilder.DeleteData(
                table: "BlogCategory",
                keyColumn: "Id",
                keyValue: new Guid("7836b51f-95e3-43d1-9abf-4aca96017328"));

            migrationBuilder.DeleteData(
                table: "BlogCategory",
                keyColumn: "Id",
                keyValue: new Guid("a005d85e-d25c-470d-a841-67a422ab3608"));

            migrationBuilder.DropColumn(
                name: "BlogPostTId",
                table: "BlogPostT");

            migrationBuilder.DropColumn(
                name: "BlogCategoryId",
                table: "BlogCategory");

            migrationBuilder.CreateTable(
                name: "BlogCategoryBlogPostT",
                columns: table => new
                {
                    BlogPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategoryBlogPostT", x => new { x.BlogPostId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_BlogCategoryBlogPostT_BlogCategory_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "BlogCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogCategoryBlogPostT_BlogPostT_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "BlogPostT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BlogCategory",
                columns: new[] { "Id", "Description", "Name", "UrlHandle" },
                values: new object[,]
                {
                    { new Guid("5990b514-e978-40dd-b964-9259e657bda7"), "Money management and investment advice", "Finance", "finance" },
                    { new Guid("898a4e04-8960-445d-a195-4a1215cae0bc"), "Health, wellness, and daily life tips", "Lifestyle", "lifestyle" },
                    { new Guid("b2f9426f-9e29-48a0-96a0-7f74087f08ec"), "Latest tech trends and news", "Technology", "technology" }
                });

            migrationBuilder.InsertData(
                table: "BlogPostT",
                columns: new[] { "Id", "AuthorName", "CategoryId", "Content", "CreatedAt", "FeatureImageUrl", "IsPublished", "IsVisible", "PublishedDate", "ShortDescription", "Title", "UrlHandle" },
                values: new object[,]
                {
                    { new Guid("8149d258-31ba-4c3e-bec8-7ebf8712df47"), "John Doe", new Guid("b2f9426f-9e29-48a0-96a0-7f74087f08ec"), "AI is evolving rapidly...", new DateTime(2025, 4, 15, 14, 19, 50, 575, DateTimeKind.Utc).AddTicks(6859), "ai.jpg", true, true, new DateTime(2025, 4, 15, 14, 19, 50, 575, DateTimeKind.Utc).AddTicks(6853), "Exploring AI advancements", "The Future of AI", "future-of-ai" },
                    { new Guid("ea9101e8-4b79-4456-b8c5-aec8adbf670f"), "Jane Smith", new Guid("898a4e04-8960-445d-a195-4a1215cae0bc"), "Here are some productivity hacks...", new DateTime(2025, 4, 15, 14, 19, 50, 575, DateTimeKind.Utc).AddTicks(6868), "productivity.jpg", true, true, new DateTime(2025, 4, 15, 14, 19, 50, 575, DateTimeKind.Utc).AddTicks(6866), "Increase your efficiency", "Best Productivity Hacks", "best-productivity-hacks" },
                    { new Guid("feab0e53-7180-4679-bda6-77ec4999333c"), "Mark Brown", new Guid("5990b514-e978-40dd-b964-9259e657bda7"), "Managing your finances is important...", new DateTime(2025, 4, 15, 14, 19, 50, 575, DateTimeKind.Utc).AddTicks(6872), "finance.jpg", true, true, new DateTime(2025, 4, 15, 14, 19, 50, 575, DateTimeKind.Utc).AddTicks(6871), "Smart saving tips", "How to Save Money", "how-to-save-money" }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AuthorName", "BlogPostId", "Content", "CreatedAt" },
                values: new object[,]
                {
                    { new Guid("6c3472d4-3f1d-44eb-b191-e4703c1483e5"), "Charlie", new Guid("feab0e53-7180-4679-bda6-77ec4999333c"), "Thanks for the tips!", new DateTime(2025, 4, 15, 14, 19, 50, 575, DateTimeKind.Utc).AddTicks(6918) },
                    { new Guid("a6354e72-c10e-449f-bca3-d5d82d3d99d2"), "Alice", new Guid("8149d258-31ba-4c3e-bec8-7ebf8712df47"), "Great insights on AI!", new DateTime(2025, 4, 15, 14, 19, 50, 575, DateTimeKind.Utc).AddTicks(6910) },
                    { new Guid("dd3752fd-1b39-409b-89b4-c1c82aad411e"), "Bob", new Guid("ea9101e8-4b79-4456-b8c5-aec8adbf670f"), "These hacks really helped!", new DateTime(2025, 4, 15, 14, 19, 50, 575, DateTimeKind.Utc).AddTicks(6915) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategoryBlogPostT_CategoriesId",
                table: "BlogCategoryBlogPostT",
                column: "CategoriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogCategoryBlogPostT");

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("6c3472d4-3f1d-44eb-b191-e4703c1483e5"));

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("a6354e72-c10e-449f-bca3-d5d82d3d99d2"));

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("dd3752fd-1b39-409b-89b4-c1c82aad411e"));

            migrationBuilder.DeleteData(
                table: "BlogPostT",
                keyColumn: "Id",
                keyValue: new Guid("8149d258-31ba-4c3e-bec8-7ebf8712df47"));

            migrationBuilder.DeleteData(
                table: "BlogPostT",
                keyColumn: "Id",
                keyValue: new Guid("ea9101e8-4b79-4456-b8c5-aec8adbf670f"));

            migrationBuilder.DeleteData(
                table: "BlogPostT",
                keyColumn: "Id",
                keyValue: new Guid("feab0e53-7180-4679-bda6-77ec4999333c"));

            migrationBuilder.DeleteData(
                table: "BlogCategory",
                keyColumn: "Id",
                keyValue: new Guid("5990b514-e978-40dd-b964-9259e657bda7"));

            migrationBuilder.DeleteData(
                table: "BlogCategory",
                keyColumn: "Id",
                keyValue: new Guid("898a4e04-8960-445d-a195-4a1215cae0bc"));

            migrationBuilder.DeleteData(
                table: "BlogCategory",
                keyColumn: "Id",
                keyValue: new Guid("b2f9426f-9e29-48a0-96a0-7f74087f08ec"));

            migrationBuilder.AddColumn<Guid>(
                name: "BlogPostTId",
                table: "BlogPostT",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BlogCategoryId",
                table: "BlogCategory",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "BlogCategory",
                columns: new[] { "Id", "BlogCategoryId", "Description", "Name", "UrlHandle" },
                values: new object[,]
                {
                    { new Guid("4f118e0f-c6d4-449b-9e61-6f5e38df43ec"), null, "Health, wellness, and daily life tips", "Lifestyle", "lifestyle" },
                    { new Guid("7836b51f-95e3-43d1-9abf-4aca96017328"), null, "Latest tech trends and news", "Technology", "technology" },
                    { new Guid("a005d85e-d25c-470d-a841-67a422ab3608"), null, "Money management and investment advice", "Finance", "finance" }
                });

            migrationBuilder.InsertData(
                table: "BlogPostT",
                columns: new[] { "Id", "AuthorName", "BlogPostTId", "CategoryId", "Content", "CreatedAt", "FeatureImageUrl", "IsPublished", "IsVisible", "PublishedDate", "ShortDescription", "Title", "UrlHandle" },
                values: new object[,]
                {
                    { new Guid("c7cd6a9d-f860-4508-865b-026faf8cf0cc"), "Mark Brown", null, new Guid("a005d85e-d25c-470d-a841-67a422ab3608"), "Managing your finances is important...", new DateTime(2025, 4, 15, 13, 52, 22, 904, DateTimeKind.Utc).AddTicks(4569), "finance.jpg", true, true, new DateTime(2025, 4, 15, 13, 52, 22, 904, DateTimeKind.Utc).AddTicks(4567), "Smart saving tips", "How to Save Money", "how-to-save-money" },
                    { new Guid("e940637e-ec9a-43f2-8766-8f8eb78c7b8c"), "Jane Smith", null, new Guid("4f118e0f-c6d4-449b-9e61-6f5e38df43ec"), "Here are some productivity hacks...", new DateTime(2025, 4, 15, 13, 52, 22, 904, DateTimeKind.Utc).AddTicks(4564), "productivity.jpg", true, true, new DateTime(2025, 4, 15, 13, 52, 22, 904, DateTimeKind.Utc).AddTicks(4563), "Increase your efficiency", "Best Productivity Hacks", "best-productivity-hacks" },
                    { new Guid("eaf65822-e4c5-49d1-92ee-48945d12558e"), "John Doe", null, new Guid("7836b51f-95e3-43d1-9abf-4aca96017328"), "AI is evolving rapidly...", new DateTime(2025, 4, 15, 13, 52, 22, 904, DateTimeKind.Utc).AddTicks(4558), "ai.jpg", true, true, new DateTime(2025, 4, 15, 13, 52, 22, 904, DateTimeKind.Utc).AddTicks(4552), "Exploring AI advancements", "The Future of AI", "future-of-ai" }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AuthorName", "BlogPostId", "Content", "CreatedAt" },
                values: new object[,]
                {
                    { new Guid("3267a5b6-4fdc-4f3b-ab99-2b6b6c920d68"), "Charlie", new Guid("c7cd6a9d-f860-4508-865b-026faf8cf0cc"), "Thanks for the tips!", new DateTime(2025, 4, 15, 13, 52, 22, 904, DateTimeKind.Utc).AddTicks(4605) },
                    { new Guid("5eebe1e3-9ec8-4b63-b79b-868afd7b2bec"), "Alice", new Guid("eaf65822-e4c5-49d1-92ee-48945d12558e"), "Great insights on AI!", new DateTime(2025, 4, 15, 13, 52, 22, 904, DateTimeKind.Utc).AddTicks(4598) },
                    { new Guid("af5285e6-ca70-410d-bced-4c764000e980"), "Bob", new Guid("e940637e-ec9a-43f2-8766-8f8eb78c7b8c"), "These hacks really helped!", new DateTime(2025, 4, 15, 13, 52, 22, 904, DateTimeKind.Utc).AddTicks(4603) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostT_BlogPostTId",
                table: "BlogPostT",
                column: "BlogPostTId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategory_BlogCategoryId",
                table: "BlogCategory",
                column: "BlogCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogCategory_BlogCategory_BlogCategoryId",
                table: "BlogCategory",
                column: "BlogCategoryId",
                principalTable: "BlogCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostT_BlogPostT_BlogPostTId",
                table: "BlogPostT",
                column: "BlogPostTId",
                principalTable: "BlogPostT",
                principalColumn: "Id");
        }
    }
}
