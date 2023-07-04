using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yapılacakİsler.Migrations
{
    public partial class Ilk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Done = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "Deleted", "Done", "Title" },
                values: new object[,]
                {
                    { 1, false, false, "Proje teklifini tamamla" },
                    { 2, false, false, "Sunum slaytlarını hazırla" },
                    { 3, false, true, "Kod değişikliklerini gözden geçir" },
                    { 4, false, true, "Takip e-postalarını gönder" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoItems");
        }
    }
}
