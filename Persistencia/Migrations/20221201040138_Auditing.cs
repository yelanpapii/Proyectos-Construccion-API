using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ProyectosConstruccion.Persistencia.Migrations
{
    public partial class Auditing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedOn",
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