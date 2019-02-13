using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetGram.Migrations
{
    public partial class initial : Migration
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
                columns: new[] { "ID", "Description", "Image", "Author" },
                values: new object[,]
                {
                    { 1, "Placeholder One", "https://via.placeholder.com/150", "Clari" },
                    { 2, "Placeholder Two", "https://via.placeholder.com/150", "Nate" },
                    { 3, "Placeholder Three", "https://via.placeholder.com/150", "Mike" },
                    { 4, "Placeholder Four", "https://via.placeholder.com/150", "Xia" },
                    { 5, "Placeholder Five", "https://via.placeholder.com/150", "Mike G." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
