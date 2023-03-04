using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tank.Migrations
{
    /// <inheritdoc />
    public partial class Teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Character");

            migrationBuilder.EnsureSchema(
                name: "Item");

            migrationBuilder.EnsureSchema(
                name: "Server");

            migrationBuilder.CreateTable(
                name: "Cards",
                schema: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterCards",
                schema: "Character",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    Place = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CharacterRanks",
                schema: "Character",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    RankId = table.Column<int>(type: "int", nullable: false),
                    AcquisitionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                schema: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharactersFriends",
                schema: "Character",
                columns: table => new
                {
                    CharacterId1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CharacterId2 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemsCategoryId = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Agility = table.Column<int>(type: "int", nullable: false),
                    Luck = table.Column<int>(type: "int", nullable: false),
                    Hp = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Guard = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    MinLevel = table.Column<int>(type: "int", nullable: true),
                    IsStrengthenable = table.Column<bool>(type: "bit", nullable: false),
                    IsComposable = table.Column<bool>(type: "bit", nullable: false),
                    IsDroppable = table.Column<bool>(type: "bit", nullable: false),
                    IsEquipable = table.Column<bool>(type: "bit", nullable: false),
                    IsUsable = table.Column<bool>(type: "bit", nullable: false),
                    ItemBindTypeId = table.Column<int>(type: "int", nullable: true),
                    Hole1Id = table.Column<int>(type: "int", nullable: true),
                    Hole2Id = table.Column<int>(type: "int", nullable: true),
                    Hole3Id = table.Column<int>(type: "int", nullable: true),
                    Hole4Id = table.Column<int>(type: "int", nullable: true),
                    Hole5Id = table.Column<int>(type: "int", nullable: true),
                    Hole6Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemBindTypes",
                schema: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBindTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemHoleTypes",
                schema: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemHoleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemsCategories",
                schema: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Place = table.Column<int>(type: "int", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                schema: "Character",
                columns: table => new
                {
                    Level = table.Column<int>(type: "int", nullable: false),
                    Xp = table.Column<long>(type: "bigint", nullable: false),
                    Blood = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Level);
                });

            migrationBuilder.CreateTable(
                name: "Ranks",
                schema: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Agility = table.Column<int>(type: "int", nullable: false),
                    Luck = table.Column<int>(type: "int", nullable: false),
                    Hp = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Guard = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServerConfig",
                schema: "Server",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerConfig", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servers",
                schema: "Server",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    ServerStateId = table.Column<int>(type: "int", nullable: false),
                    TotalCharacters = table.Column<int>(type: "int", nullable: false),
                    TotalRooms = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowedLevel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServerStates",
                schema: "Server",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerStates", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Item",
                table: "ItemBindTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 0, null, "Bind 0" },
                    { 1, null, "Bind 1" },
                    { 2, null, "Bind 2" }
                });

            migrationBuilder.InsertData(
                schema: "Item",
                table: "ItemHoleTypes",
                columns: new[] { "Id", "Description", "OpenCost" },
                values: new object[,]
                {
                    { 0, "Hole for attacking purpose", 0 },
                    { 1, "Hole for defending purpose", 0 },
                    { 2, "Hole for increase attributes purpose", 0 }
                });

            migrationBuilder.InsertData(
                schema: "Item",
                table: "ItemsCategories",
                columns: new[] { "Id", "Name", "Place", "Remark" },
                values: new object[,]
                {
                    { 1, "Chapéu", 1, null },
                    { 2, "Óculos", 2, null },
                    { 3, "Cabelo", 3, null },
                    { 4, "Face", 4, null },
                    { 5, "Roupa", 5, null },
                    { 6, "Olhos", 6, null },
                    { 7, "Arma", 7, null },
                    { 8, "Pulseiras", 8, null },
                    { 9, "Anéis", 9, null },
                    { 10, "Itens de combate", null, null },
                    { 11, "Itens de auxílio", null, null },
                    { 12, "Itens de Tarefa", null, null },
                    { 13, "Terno", 11, null },
                    { 14, "Colar", 12, null },
                    { 15, "Decoração", 13, null },
                    { 16, "Bolha", 14, null },
                    { 17, "Itens auxiliares", 15, null },
                    { 18, "Baú de Cartões", null, null },
                    { 19, "Ajuda", 16, null },
                    { 20, "Poção de Prática", null, null },
                    { 23, "Inventário de Missões Práticas", null, null },
                    { 25, "Baú de Cartões", null, null },
                    { 27, "Armas especiais", 27, null },
                    { 30, "Propriedade especial", null, null },
                    { 31, "Mão Secundária Especial", null, null },
                    { 32, "Sementes", null, null },
                    { 33, "Fertilizante", null, null },
                    { 34, "Alimento de mascote", null, null },
                    { 35, "Ovo mascote", null, null },
                    { 36, "Colheita", null, null },
                    { 50, "Arma mascote", null, null },
                    { 51, "Chapéu mascote", null, null }
                });

            migrationBuilder.InsertData(
                schema: "Server",
                table: "ServerConfig",
                columns: new[] { "Id", "Description", "Name", "Value" },
                values: new object[,]
                {
                    { 0, null, "PublicRSAKey", "-----BEGIN PUBLIC KEY-----\r\nMFwwDQYJKoZIhvcNAQEBBQADSwAwSAJBAL1ezivGNWo8deIaiWOtukZ5hsczjqza\r\nuNeF0ieYdWN8fE6/YZpB4ZOyZiGhp8EfRlFpUjzPtw1i5CcA7K+SWHUCAwEAAQ==\r\n-----END PUBLIC KEY-----" },
                    { 1, null, "PrivateRSAKey", "-----BEGIN RSA PRIVATE KEY-----\r\nMIIBOgIBAAJBAL1ezivGNWo8deIaiWOtukZ5hsczjqzauNeF0ieYdWN8fE6/YZpB\r\n4ZOyZiGhp8EfRlFpUjzPtw1i5CcA7K+SWHUCAwEAAQJAMLJxiDY3RDN6CQPT8ssZ\r\nDMhxjUZH2VGBmQKzsTT2cvd94bH7V4ETGv011Tv5d31eeMudGLkiwUMIQUVBq/ba\r\nPQIhAOLCUPZxw4v/e3GnRi8Zm31wymdGk40AFuPApAGNFbDnAiEA1co6HkX4psjf\r\ny+XzxcSPlojhiyb98CQV2x5akJz1FEMCIQCLQHVjwl0pvgzasLSi/ADGudsyLN8z\r\nuZhU6NpOsYtehQIgMFrAEG7VEawnai/FljqiG3M0SEv2baVLyDayVzkY+Y8CIBji\r\ngNSm2/bwJM4fYfSsHD2BXOTneOWWP9ZtM6i30gWC\r\n-----END RSA PRIVATE KEY-----" }
                });

            migrationBuilder.InsertData(
                schema: "Server",
                table: "Servers",
                columns: new[] { "Id", "AllowedLevel", "Ip", "Name", "Port", "Remark", "ServerStateId", "TotalCharacters", "TotalRooms" },
                values: new object[] { 0, null, "127.0.0.1", "Test server", 9202, null, 0, 0, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterCards_CharacterId",
                schema: "Character",
                table: "CharacterCards",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterRanks_CharacterId",
                schema: "Character",
                table: "CharacterRanks",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterRanks_RankId",
                schema: "Character",
                table: "CharacterRanks",
                column: "RankId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharactersFriends_CharacterId1",
                schema: "Character",
                table: "CharactersFriends",
                column: "CharacterId1");

            migrationBuilder.CreateIndex(
                name: "IX_CharactersFriends_CharacterId2",
                schema: "Character",
                table: "CharactersFriends",
                column: "CharacterId2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "CharacterCards",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "CharacterRanks",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "Characters",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "CharactersFriends",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "Item",
                schema: "Item");

            migrationBuilder.DropTable(
                name: "ItemBindTypes",
                schema: "Item");

            migrationBuilder.DropTable(
                name: "ItemHoleTypes",
                schema: "Item");

            migrationBuilder.DropTable(
                name: "ItemsCategories",
                schema: "Item");

            migrationBuilder.DropTable(
                name: "Levels",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "Ranks",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "ServerConfig",
                schema: "Server");

            migrationBuilder.DropTable(
                name: "Servers",
                schema: "Server");

            migrationBuilder.DropTable(
                name: "ServerStates",
                schema: "Server");
        }
    }
}
