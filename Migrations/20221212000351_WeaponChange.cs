﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRPGBackend.Migrations
{
    /// <inheritdoc />
    public partial class WeaponChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Weapons",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Weapons");
        }
    }
}
