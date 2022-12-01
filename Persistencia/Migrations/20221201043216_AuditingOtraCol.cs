using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectosConstruccion.Persistencia.Migrations
{
    public partial class AuditingOtraCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ModifiedOn",
                table: "proyecto",
                type: "datetime",
                nullable: true
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
