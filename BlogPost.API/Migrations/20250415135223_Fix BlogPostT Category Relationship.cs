using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogPost.API.Migrations
{
    /// <inheritdoc />
    public partial class FixBlogPostTCategoryRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_BlogPostT_BlogCategory_CategoryId",
            //    table: "BlogPostT");

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("18ffc619-9e42-43dc-8538-d1ca22f89fc5"));

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("4c74cb5f-f619-4896-a8f7-147d46cdd7b8"));

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("a20c9199-8e52-4698-85da-3d328959efa9"));

            migrationBuilder.DeleteData(
                table: "BlogPostT",
                keyColumn: "Id",
                keyValue: new Guid("6596baae-f88f-487c-8b2a-3e31f997626e"));

            migrationBuilder.DeleteData(
                table: "BlogPostT",
                keyColumn: "Id",
                keyValue: new Guid("68e553ab-5417-4e80-b7a0-7c168423e0dc"));

            migrationBuilder.DeleteData(
                table: "BlogPostT",
                keyColumn: "Id",
                keyValue: new Guid("84ec1dfb-fb78-4df1-8c3c-0ec0b92042d5"));

            migrationBuilder.DeleteData(
                table: "BlogCategory",
                keyColumn: "Id",
                keyValue: new Guid("68b08ae7-8c0e-45de-b9e0-655a33ca91a0"));

            migrationBuilder.DeleteData(
                table: "BlogCategory",
                keyColumn: "Id",
                keyValue: new Guid("86a59b54-90ce-46d9-982e-23635ae8f876"));

            migrationBuilder.DeleteData(
                table: "BlogCategory",
                keyColumn: "Id",
                keyValue: new Guid("dbed4bcf-5ea0-4578-bde7-26ee4285ff2a"));

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
                name: "FK_BlogPostT_BlogCategory_CategoryId",
                table: "BlogPostT",
                column: "CategoryId",
                principalTable: "BlogCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostT_BlogPostT_BlogPostTId",
                table: "BlogPostT",
                column: "BlogPostTId",
                principalTable: "BlogPostT",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogCategory_BlogCategory_BlogCategoryId",
                table: "BlogCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostT_BlogCategory_CategoryId",
                table: "BlogPostT");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostT_BlogCategory_CategoryId",
                table: "BlogPostT",
                column: "CategoryId",
                principalTable: "BlogCategory",
                principalColumn: "Id");
        }
    }
}
