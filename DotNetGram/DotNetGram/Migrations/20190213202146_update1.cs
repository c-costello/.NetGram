using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetGram.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "ID", "Author", "Description", "Image" },
                values: new object[,]
                {
                    { 1, "Clari", "Placeholder One", "https://via.placeholder.com/150" },
                    { 2, "Nate", "Placeholder Two", "https://via.placeholder.com/150" },
                    { 3, "Mike", "Placeholder Three", "https://via.placeholder.com/150" },
                    { 4, "Xia", "Placeholder Four", "https://via.placeholder.com/150" },
                    { 5, "Mike G.", "Placeholder Five", "https://via.placeholder.com/150" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
