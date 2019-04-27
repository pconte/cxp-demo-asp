using Microsoft.EntityFrameworkCore.Migrations;

namespace KnowledgeBaseApi2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleId);
                });

            migrationBuilder.CreateTable(
                name: "Suggestions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SearchString = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    IsSelected = table.Column<bool>(nullable: false),
                    IsInitSelected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTag",
                columns: table => new
                {
                    ArticleId = table.Column<long>(nullable: false),
                    TagId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTag", x => new { x.ArticleId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ArticleTag_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleId", "Summary", "Title", "Url" },
                values: new object[] { 1L, "", "Article1", "website.com/path" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleId", "Summary", "Title", "Url" },
                values: new object[] { 2L, "", "Article2", "website.com/path" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "IsInitSelected", "IsSelected", "Name" },
                values: new object[] { 1L, false, false, "Tag1" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "IsInitSelected", "IsSelected", "Name" },
                values: new object[] { 2L, false, false, "Tag2" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "IsInitSelected", "IsSelected", "Name" },
                values: new object[] { 3L, false, false, "Tag3" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "IsInitSelected", "IsSelected", "Name" },
                values: new object[] { 4L, false, false, "Tag4" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "IsInitSelected", "IsSelected", "Name" },
                values: new object[] { 5L, false, false, "Tag5" });

            migrationBuilder.InsertData(
                table: "ArticleTag",
                columns: new[] { "ArticleId", "TagId" },
                values: new object[] { 1L, 1L });

            migrationBuilder.InsertData(
                table: "ArticleTag",
                columns: new[] { "ArticleId", "TagId" },
                values: new object[] { 2L, 2L });

            migrationBuilder.InsertData(
                table: "ArticleTag",
                columns: new[] { "ArticleId", "TagId" },
                values: new object[] { 1L, 3L });

            migrationBuilder.InsertData(
                table: "ArticleTag",
                columns: new[] { "ArticleId", "TagId" },
                values: new object[] { 2L, 4L });

            migrationBuilder.InsertData(
                table: "ArticleTag",
                columns: new[] { "ArticleId", "TagId" },
                values: new object[] { 1L, 5L });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTag_TagId",
                table: "ArticleTag",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleTag");

            migrationBuilder.DropTable(
                name: "Suggestions");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
