using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SurfBreaks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Break = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurfBreaks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SurfBreaks",
                columns: new[] { "Id", "Break", "Location", "Name" },
                values: new object[] { 100, 1, "Oaxaca", "Puerto Escondido" });

            migrationBuilder.InsertData(
                table: "SurfBreaks",
                columns: new[] { "Id", "Break", "Location", "Name" },
                values: new object[] { 101, 3, "Costa Rica", "Santa Teresa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurfBreaks");
        }
    }
}
