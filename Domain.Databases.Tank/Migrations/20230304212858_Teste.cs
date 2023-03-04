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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    ItemBindTypeId = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Item_ItemBindTypes_ItemBindTypeId",
                        column: x => x.ItemBindTypeId,
                        principalSchema: "Item",
                        principalTable: "ItemBindTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_ItemHoleTypes_Hole1Id",
                        column: x => x.Hole1Id,
                        principalSchema: "Item",
                        principalTable: "ItemHoleTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Item_ItemHoleTypes_Hole2Id",
                        column: x => x.Hole2Id,
                        principalSchema: "Item",
                        principalTable: "ItemHoleTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Item_ItemHoleTypes_Hole3Id",
                        column: x => x.Hole3Id,
                        principalSchema: "Item",
                        principalTable: "ItemHoleTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Item_ItemHoleTypes_Hole4Id",
                        column: x => x.Hole4Id,
                        principalSchema: "Item",
                        principalTable: "ItemHoleTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Item_ItemHoleTypes_Hole5Id",
                        column: x => x.Hole5Id,
                        principalSchema: "Item",
                        principalTable: "ItemHoleTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Item_ItemHoleTypes_Hole6Id",
                        column: x => x.Hole6Id,
                        principalSchema: "Item",
                        principalTable: "ItemHoleTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Item_ItemsCategories_ItemsCategoryId",
                        column: x => x.ItemsCategoryId,
                        principalSchema: "Item",
                        principalTable: "ItemsCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                schema: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<bool>(type: "bit", nullable: false),
                    Xp = table.Column<int>(type: "int", nullable: false),
                    Honor = table.Column<int>(type: "int", nullable: false),
                    RankId = table.Column<int>(type: "int", nullable: true),
                    Coins = table.Column<int>(type: "int", nullable: false),
                    Gold = table.Column<int>(type: "int", nullable: false),
                    Medals = table.Column<int>(type: "int", nullable: false),
                    Coupons = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WinnedFights = table.Column<int>(type: "int", nullable: false),
                    TotalFights = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Characters_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "Character",
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Ranks_RankId",
                        column: x => x.RankId,
                        principalSchema: "Character",
                        principalTable: "Ranks",
                        principalColumn: "Id");
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
                    table.ForeignKey(
                        name: "FK_Servers_ServerStates_ServerStateId",
                        column: x => x.ServerStateId,
                        principalSchema: "Server",
                        principalTable: "ServerStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    table.ForeignKey(
                        name: "FK_Cards_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Item",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterMarriages",
                schema: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartnerId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    WeddingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DivorceDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMarriages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterMarriages_Characters_PartnerId",
                        column: x => x.PartnerId,
                        principalSchema: "Character",
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_CharacterRanks_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalSchema: "Character",
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterRanks_Ranks_RankId",
                        column: x => x.RankId,
                        principalSchema: "Character",
                        principalTable: "Ranks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharactersCustomizedItems",
                schema: "Character",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_CharactersCustomizedItems_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalSchema: "Character",
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharactersCustomizedItems_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Item",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharactersFriends",
                schema: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    FriendshipStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FriendshipEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharactersFriends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharactersFriends_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalSchema: "Character",
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterTeachers",
                schema: "Character",
                columns: table => new
                {
                    CharacterTeacherId = table.Column<int>(type: "int", nullable: false),
                    RelationshipStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RelationshipStartEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_CharacterTeachers_Characters_CharacterTeacherId",
                        column: x => x.CharacterTeacherId,
                        principalSchema: "Character",
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarriageProposals",
                schema: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromCharacterId = table.Column<int>(type: "int", nullable: false),
                    ToCharacterId = table.Column<int>(type: "int", nullable: false),
                    ProposalSpeech = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcceptedProposal = table.Column<bool>(type: "bit", nullable: true),
                    ProposalDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarriageProposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarriageProposals_Characters_FromCharacterId",
                        column: x => x.FromCharacterId,
                        principalSchema: "Character",
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MarriageProposals_Characters_ToCharacterId",
                        column: x => x.ToCharacterId,
                        principalSchema: "Character",
                        principalTable: "Characters",
                        principalColumn: "Id");
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
                    table.ForeignKey(
                        name: "FK_CharacterCards_Cards_CardId",
                        column: x => x.CardId,
                        principalSchema: "Character",
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterCards_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalSchema: "Character",
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                schema: "Character",
                table: "Levels",
                columns: new[] { "Level", "Blood", "Xp" },
                values: new object[,]
                {
                    { 1, 1000, 0L },
                    { 2, 1050, 37L },
                    { 3, 1100, 162L },
                    { 4, 1150, 505L },
                    { 5, 1200, 1283L },
                    { 6, 1250, 2801L },
                    { 7, 1300, 5462L },
                    { 8, 1350, 9771L },
                    { 9, 1400, 16341L },
                    { 10, 1450, 25899L },
                    { 11, 1530, 39291L },
                    { 12, 1610, 57489L },
                    { 13, 1690, 81594L },
                    { 14, 1770, 112847L },
                    { 15, 1850, 152630L },
                    { 16, 1970, 202472L },
                    { 17, 2090, 264058L },
                    { 18, 2210, 339232L },
                    { 19, 2330, 430003L },
                    { 20, 2450, 538554L },
                    { 21, 2620, 667242L },
                    { 22, 2790, 818609L },
                    { 23, 2960, 995383L },
                    { 24, 3130, 1200489L },
                    { 25, 3300, 1437053L },
                    { 26, 3380, 1753103L },
                    { 27, 3460, 2112735L },
                    { 28, 3540, 2519637L },
                    { 29, 3620, 2977665L },
                    { 30, 3700, 3490849L },
                    { 31, 3870, 4145185L },
                    { 32, 4040, 4873978L },
                    { 33, 4210, 5684269L },
                    { 34, 4380, 6583537L },
                    { 35, 4550, 7579710L },
                    { 36, 4670, 8681174L },
                    { 37, 4790, 9896788L },
                    { 38, 4910, 11235892L },
                    { 39, 5030, 12708322L },
                    { 40, 5150, 14324419L },
                    { 41, 5200, 16263735L },
                    { 42, 5250, 18590915L },
                    { 43, 5300, 21383531L },
                    { 44, 5350, 24734669L },
                    { 45, 5400, 28756036L },
                    { 46, 5450, 33581676L },
                    { 47, 5500, 39372443L },
                    { 48, 5550, 46321365L },
                    { 49, 5600, 54660070L },
                    { 50, 5650, 63832646L },
                    { 51, 5680, 73922480L },
                    { 52, 5710, 85021297L },
                    { 53, 5740, 97229996L },
                    { 54, 5770, 110659565L },
                    { 55, 5800, 125432090L },
                    { 56, 5830, 140943242L },
                    { 57, 5860, 157229951L },
                    { 58, 5890, 174330996L },
                    { 59, 5920, 192287093L },
                    { 60, 5950, 211140995L }
                });

            migrationBuilder.InsertData(
                schema: "Character",
                table: "Ranks",
                columns: new[] { "Id", "Agility", "Attack", "Damage", "Defense", "Guard", "Hp", "Luck", "Name" },
                values: new object[] { 1, 0, 0, 0, 0, 0, 0, 0, "Novato" });

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
                table: "ServerStates",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 0, "Server online" },
                    { 1, "Server offline" }
                });

            migrationBuilder.InsertData(
                schema: "Server",
                table: "Servers",
                columns: new[] { "Id", "AllowedLevel", "Ip", "Name", "Port", "Remark", "ServerStateId", "TotalCharacters", "TotalRooms" },
                values: new object[] { 0, null, "127.0.0.1", "Test server", 9202, null, 0, 0, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ItemId",
                schema: "Character",
                table: "Cards",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterCards_CardId",
                schema: "Character",
                table: "CharacterCards",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterCards_CharacterId",
                schema: "Character",
                table: "CharacterCards",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMarriages_PartnerId",
                schema: "Character",
                table: "CharacterMarriages",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterRanks_CharacterId",
                schema: "Character",
                table: "CharacterRanks",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterRanks_RankId",
                schema: "Character",
                table: "CharacterRanks",
                column: "RankId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_RankId",
                schema: "Character",
                table: "Characters",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_TeacherId",
                schema: "Character",
                table: "Characters",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_CharactersCustomizedItems_CharacterId",
                schema: "Character",
                table: "CharactersCustomizedItems",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharactersCustomizedItems_ItemId",
                schema: "Character",
                table: "CharactersCustomizedItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CharactersFriends_CharacterId",
                schema: "Character",
                table: "CharactersFriends",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTeachers_CharacterTeacherId",
                schema: "Character",
                table: "CharacterTeachers",
                column: "CharacterTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Hole1Id",
                schema: "Item",
                table: "Item",
                column: "Hole1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Hole2Id",
                schema: "Item",
                table: "Item",
                column: "Hole2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Hole3Id",
                schema: "Item",
                table: "Item",
                column: "Hole3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Hole4Id",
                schema: "Item",
                table: "Item",
                column: "Hole4Id");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Hole5Id",
                schema: "Item",
                table: "Item",
                column: "Hole5Id");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Hole6Id",
                schema: "Item",
                table: "Item",
                column: "Hole6Id");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemBindTypeId",
                schema: "Item",
                table: "Item",
                column: "ItemBindTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemsCategoryId",
                schema: "Item",
                table: "Item",
                column: "ItemsCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MarriageProposals_FromCharacterId",
                schema: "Character",
                table: "MarriageProposals",
                column: "FromCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_MarriageProposals_ToCharacterId",
                schema: "Character",
                table: "MarriageProposals",
                column: "ToCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Servers_ServerStateId",
                schema: "Server",
                table: "Servers",
                column: "ServerStateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterCards",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "CharacterMarriages",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "CharacterRanks",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "CharactersCustomizedItems",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "CharactersFriends",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "CharacterTeachers",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "Levels",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "MarriageProposals",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "ServerConfig",
                schema: "Server");

            migrationBuilder.DropTable(
                name: "Servers",
                schema: "Server");

            migrationBuilder.DropTable(
                name: "Cards",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "Characters",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "ServerStates",
                schema: "Server");

            migrationBuilder.DropTable(
                name: "Item",
                schema: "Item");

            migrationBuilder.DropTable(
                name: "Ranks",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "ItemBindTypes",
                schema: "Item");

            migrationBuilder.DropTable(
                name: "ItemHoleTypes",
                schema: "Item");

            migrationBuilder.DropTable(
                name: "ItemsCategories",
                schema: "Item");
        }
    }
}
