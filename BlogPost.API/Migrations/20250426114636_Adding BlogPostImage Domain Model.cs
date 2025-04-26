using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogPost.API.Migrations
{
    /// <inheritdoc />
    public partial class AddingBlogPostImageDomainModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "BlogImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogImage", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BlogCategory",
                columns: new[] { "Id", "Description", "Name", "UrlHandle" },
                values: new object[,]
                {
                    { new Guid("6be363c8-0626-4ae8-b617-fe1b2d268503"), "Health, wellness, and daily life tips", "Lifestyle", "lifestyle" },
                    { new Guid("922ad5ce-5f9e-4aec-8f99-49c073f8c27b"), "Money management and investment advice", "Finance", "finance" },
                    { new Guid("d3a60d5f-0f35-432f-b250-813c55a7e4f2"), "Latest tech trends and news", "Technology", "technology" }
                });

            migrationBuilder.InsertData(
                table: "BlogPostT",
                columns: new[] { "Id", "AuthorName", "CategoryId", "Content", "CreatedAt", "FeatureImageUrl", "IsPublished", "IsVisible", "PublishedDate", "ShortDescription", "Title", "UrlHandle" },
                values: new object[,]
                {
                    { new Guid("16f37fe1-f1c4-4e6f-b4d8-1d485d998d20"), "Jane Smith", new Guid("6be363c8-0626-4ae8-b617-fe1b2d268503"), "Here are some productivity hacks...", new DateTime(2025, 4, 26, 11, 46, 36, 61, DateTimeKind.Utc).AddTicks(320), "productivity.jpg", true, true, new DateTime(2025, 4, 26, 11, 46, 36, 61, DateTimeKind.Utc).AddTicks(319), "Increase your efficiency", "Best Productivity Hacks", "best-productivity-hacks" },
                    { new Guid("916e4e61-4646-455a-aa80-6000fd3832d0"), "Mark Brown", new Guid("922ad5ce-5f9e-4aec-8f99-49c073f8c27b"), "Managing your finances is important...", new DateTime(2025, 4, 26, 11, 46, 36, 61, DateTimeKind.Utc).AddTicks(336), "finance.jpg", true, true, new DateTime(2025, 4, 26, 11, 46, 36, 61, DateTimeKind.Utc).AddTicks(335), "Smart saving tips", "How to Save Money", "how-to-save-money" },
                    { new Guid("c1698f11-114b-42c5-930d-8a4c179090ee"), "John Doe", new Guid("d3a60d5f-0f35-432f-b250-813c55a7e4f2"), "AI is evolving rapidly...", new DateTime(2025, 4, 26, 11, 46, 36, 61, DateTimeKind.Utc).AddTicks(313), "ai.jpg", true, true, new DateTime(2025, 4, 26, 11, 46, 36, 61, DateTimeKind.Utc).AddTicks(303), "Exploring AI advancements", "The Future of AI", "future-of-ai" }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AuthorName", "BlogPostId", "Content", "CreatedAt" },
                values: new object[,]
                {
                    { new Guid("096e061f-3b01-40ca-861e-2747139c0d89"), "Charlie", new Guid("916e4e61-4646-455a-aa80-6000fd3832d0"), "Thanks for the tips!", new DateTime(2025, 4, 26, 11, 46, 36, 61, DateTimeKind.Utc).AddTicks(378) },
                    { new Guid("ba986f63-6622-4fd7-bb63-9af75ae415ef"), "Bob", new Guid("16f37fe1-f1c4-4e6f-b4d8-1d485d998d20"), "These hacks really helped!", new DateTime(2025, 4, 26, 11, 46, 36, 61, DateTimeKind.Utc).AddTicks(374) },
                    { new Guid("fcd7c343-dcd1-4af6-8331-82b853455d1d"), "Alice", new Guid("c1698f11-114b-42c5-930d-8a4c179090ee"), "Great insights on AI!", new DateTime(2025, 4, 26, 11, 46, 36, 61, DateTimeKind.Utc).AddTicks(370) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogImage");

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("096e061f-3b01-40ca-861e-2747139c0d89"));

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("ba986f63-6622-4fd7-bb63-9af75ae415ef"));

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("fcd7c343-dcd1-4af6-8331-82b853455d1d"));

            migrationBuilder.DeleteData(
                table: "BlogPostT",
                keyColumn: "Id",
                keyValue: new Guid("16f37fe1-f1c4-4e6f-b4d8-1d485d998d20"));

            migrationBuilder.DeleteData(
                table: "BlogPostT",
                keyColumn: "Id",
                keyValue: new Guid("916e4e61-4646-455a-aa80-6000fd3832d0"));

            migrationBuilder.DeleteData(
                table: "BlogPostT",
                keyColumn: "Id",
                keyValue: new Guid("c1698f11-114b-42c5-930d-8a4c179090ee"));

            migrationBuilder.DeleteData(
                table: "BlogCategory",
                keyColumn: "Id",
                keyValue: new Guid("6be363c8-0626-4ae8-b617-fe1b2d268503"));

            migrationBuilder.DeleteData(
                table: "BlogCategory",
                keyColumn: "Id",
                keyValue: new Guid("922ad5ce-5f9e-4aec-8f99-49c073f8c27b"));

            migrationBuilder.DeleteData(
                table: "BlogCategory",
                keyColumn: "Id",
                keyValue: new Guid("d3a60d5f-0f35-432f-b250-813c55a7e4f2"));

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
        }
    }
}
