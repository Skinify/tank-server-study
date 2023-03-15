using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tank.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Item");

            migrationBuilder.EnsureSchema(
                name: "Character");

            migrationBuilder.EnsureSchema(
                name: "Quest");

            migrationBuilder.EnsureSchema(
                name: "Configurations");

            migrationBuilder.EnsureSchema(
                name: "Battle");

            migrationBuilder.EnsureSchema(
                name: "Battle.PVE");

            migrationBuilder.EnsureSchema(
                name: "Battle.PVP");

            migrationBuilder.CreateTable(
                name: "BagTypes",
                schema: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BagTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefaultServerConfigs",
                schema: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultServerConfigs", x => x.Id);
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
                name: "ItemsCategoriesTypes",
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
                    table.PrimaryKey("PK_ItemsCategoriesTypes", x => x.Id);
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
                name: "Maps",
                schema: "Battle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ForePic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackPic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Music = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NPCs",
                schema: "Battle.PVE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Blood = table.Column<int>(type: "int", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Agility = table.Column<int>(type: "int", nullable: false),
                    Luck = table.Column<int>(type: "int", nullable: false),
                    Hp = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Guard = table.Column<int>(type: "int", nullable: false),
                    Xp = table.Column<int>(type: "int", nullable: false),
                    AttackRange = table.Column<int>(type: "int", nullable: true),
                    MoveMax = table.Column<int>(type: "int", nullable: false),
                    MoveMin = table.Column<int>(type: "int", nullable: false),
                    MoveSpeed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPCs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PVEDifficultyTypes",
                schema: "Battle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PVEDifficultyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PVEGames",
                schema: "Battle.PVE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinLevel = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PVEGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestConditionTypes",
                schema: "Quest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestConditionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestGroups",
                schema: "Quest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsRepeatable = table.Column<bool>(type: "bit", nullable: false),
                    MaxRepeatTimes = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestGroups", x => x.Id);
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
                name: "RateTypes",
                schema: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeTypes",
                schema: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopCategoriesTypes",
                schema: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCategoriesTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StageTypes",
                schema: "Battle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                schema: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemsCategoryId = table.Column<int>(type: "int", nullable: false),
                    BagTypesId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_BagTypes_BagTypesId",
                        column: x => x.BagTypesId,
                        principalSchema: "Item",
                        principalTable: "BagTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_ItemBindTypes_ItemBindTypeId",
                        column: x => x.ItemBindTypeId,
                        principalSchema: "Item",
                        principalTable: "ItemBindTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_ItemHoleTypes_Hole1Id",
                        column: x => x.Hole1Id,
                        principalSchema: "Item",
                        principalTable: "ItemHoleTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_ItemHoleTypes_Hole2Id",
                        column: x => x.Hole2Id,
                        principalSchema: "Item",
                        principalTable: "ItemHoleTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_ItemHoleTypes_Hole3Id",
                        column: x => x.Hole3Id,
                        principalSchema: "Item",
                        principalTable: "ItemHoleTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_ItemHoleTypes_Hole4Id",
                        column: x => x.Hole4Id,
                        principalSchema: "Item",
                        principalTable: "ItemHoleTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_ItemHoleTypes_Hole5Id",
                        column: x => x.Hole5Id,
                        principalSchema: "Item",
                        principalTable: "ItemHoleTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_ItemHoleTypes_Hole6Id",
                        column: x => x.Hole6Id,
                        principalSchema: "Item",
                        principalTable: "ItemHoleTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_ItemsCategoriesTypes_ItemsCategoryId",
                        column: x => x.ItemsCategoryId,
                        principalSchema: "Item",
                        principalTable: "ItemsCategoriesTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quests",
                schema: "Quest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinLevel = table.Column<int>(type: "int", nullable: false),
                    MaxLevel = table.Column<int>(type: "int", nullable: true),
                    PreQuestId = table.Column<int>(type: "int", nullable: true),
                    CoinsReward = table.Column<int>(type: "int", nullable: false),
                    GoldReward = table.Column<int>(type: "int", nullable: false),
                    MedalsReward = table.Column<int>(type: "int", nullable: false),
                    CouponsReward = table.Column<int>(type: "int", nullable: false),
                    Rands = table.Column<float>(type: "real", nullable: false),
                    RandDouble = table.Column<float>(type: "real", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxFinishTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuestGroupsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quests_QuestGroups_QuestGroupsId",
                        column: x => x.QuestGroupsId,
                        principalSchema: "Quest",
                        principalTable: "QuestGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quests_Quests_PreQuestId",
                        column: x => x.PreQuestId,
                        principalSchema: "Quest",
                        principalTable: "Quests",
                        principalColumn: "Id");
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
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WinnedFights = table.Column<int>(type: "int", nullable: false),
                    TotalFights = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Ranks_RankId",
                        column: x => x.RankId,
                        principalSchema: "Character",
                        principalTable: "Ranks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DefaultServerRates",
                schema: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    AddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RateTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultServerRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefaultServerRates_RateTypes_RateTypeId",
                        column: x => x.RateTypeId,
                        principalSchema: "Configurations",
                        principalTable: "RateTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PVEStages",
                schema: "Battle.PVE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PVEId = table.Column<int>(type: "int", nullable: true),
                    RoomTypesId = table.Column<int>(type: "int", nullable: false),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    RoomDifficultyTypesId = table.Column<int>(type: "int", nullable: false),
                    MapId = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecommendedStartLevel = table.Column<int>(type: "int", nullable: false),
                    RecommendedEndLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PVEStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PVEStages_Maps_MapId",
                        column: x => x.MapId,
                        principalSchema: "Battle",
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PVEStages_PVEDifficultyTypes_RoomDifficultyTypesId",
                        column: x => x.RoomDifficultyTypesId,
                        principalSchema: "Battle",
                        principalTable: "PVEDifficultyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PVEStages_PVEGames_PVEId",
                        column: x => x.PVEId,
                        principalSchema: "Battle.PVE",
                        principalTable: "PVEGames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PVEStages_StageTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalSchema: "Battle",
                        principalTable: "StageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PVPStages",
                schema: "Battle.PVP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomTypesId = table.Column<int>(type: "int", nullable: false),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    MapId = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PVPStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PVPStages_Maps_MapId",
                        column: x => x.MapId,
                        principalSchema: "Battle",
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PVPStages_StageTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalSchema: "Battle",
                        principalTable: "StageTypes",
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
                        name: "FK_Cards_Items_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Item",
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeAward",
                schema: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Strengthen = table.Column<int>(type: "int", nullable: false),
                    AttackCompose = table.Column<int>(type: "int", nullable: false),
                    DefenseCompose = table.Column<int>(type: "int", nullable: false),
                    AgilityCompose = table.Column<int>(type: "int", nullable: false),
                    LuckCompose = table.Column<int>(type: "int", nullable: false),
                    IsBinded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeAward", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeAward_Items_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Item",
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopItems",
                schema: "Item",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ShopCategoryId = table.Column<int>(type: "int", nullable: false),
                    AddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsLimitedOffer = table.Column<bool>(type: "bit", nullable: false),
                    IsPromotion = table.Column<bool>(type: "bit", nullable: false),
                    IsPopular = table.Column<bool>(type: "bit", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ShopItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Item",
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopItems_ShopCategoriesTypes_ShopCategoryId",
                        column: x => x.ShopCategoryId,
                        principalSchema: "Item",
                        principalTable: "ShopCategoriesTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterQuests",
                schema: "Quest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    QuestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterQuests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterQuests_Quests_QuestId",
                        column: x => x.QuestId,
                        principalSchema: "Quest",
                        principalTable: "Quests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterItems",
                schema: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strengthen = table.Column<int>(type: "int", nullable: false),
                    AttackCompose = table.Column<int>(type: "int", nullable: false),
                    DefenseCompose = table.Column<int>(type: "int", nullable: false),
                    AgilityCompose = table.Column<int>(type: "int", nullable: false),
                    LuckCompose = table.Column<int>(type: "int", nullable: false),
                    IsBindable = table.Column<bool>(type: "bit", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsPermanent = table.Column<bool>(type: "bit", nullable: false),
                    DurationDate = table.Column<int>(type: "int", nullable: true),
                    AcquisitionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfUse = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hole1Xp = table.Column<int>(type: "int", nullable: false),
                    Hole2Xp = table.Column<int>(type: "int", nullable: false),
                    Hole3Xp = table.Column<int>(type: "int", nullable: false),
                    Hole4Xp = table.Column<int>(type: "int", nullable: false),
                    Hole5Xp = table.Column<int>(type: "int", nullable: false),
                    Hole6Xp = table.Column<int>(type: "int", nullable: false),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterItems_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalSchema: "Character",
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Item",
                        principalTable: "Items",
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
                name: "Disciples",
                schema: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RelationshipStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RelationshipStartEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciples_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalSchema: "Character",
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
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
                    table.PrimaryKey("PK_Friends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friends_Characters_CharacterId",
                        column: x => x.CharacterId,
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
                name: "Marriages",
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
                    table.PrimaryKey("PK_Marriages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marriages_Characters_PartnerId",
                        column: x => x.PartnerId,
                        principalSchema: "Character",
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PVPGames",
                schema: "Battle.PVP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PVPStages = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PVPGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PVPGames_PVPStages_PVPStages",
                        column: x => x.PVPStages,
                        principalSchema: "Battle.PVP",
                        principalTable: "PVPStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "Recipes",
                schema: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeTypesId = table.Column<int>(type: "int", nullable: false),
                    RecipeAwardId = table.Column<int>(type: "int", nullable: false),
                    SuccessRate = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_RecipeAward_RecipeAwardId",
                        column: x => x.RecipeAwardId,
                        principalSchema: "Item",
                        principalTable: "RecipeAward",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipes_RecipeTypes_RecipeTypesId",
                        column: x => x.RecipeTypesId,
                        principalSchema: "Item",
                        principalTable: "RecipeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterQuestContidionProgress",
                schema: "Quest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestConditionTypeId = table.Column<int>(type: "int", nullable: false),
                    CharacterQuestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterQuestContidionProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterQuestContidionProgress_CharacterQuests_CharacterQuestsId",
                        column: x => x.CharacterQuestsId,
                        principalSchema: "Quest",
                        principalTable: "CharacterQuests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterQuestContidionProgress_QuestConditionTypes_QuestConditionTypeId",
                        column: x => x.QuestConditionTypeId,
                        principalSchema: "Quest",
                        principalTable: "QuestConditionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spaws",
                schema: "Battle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosX = table.Column<int>(type: "int", nullable: false),
                    PosY = table.Column<int>(type: "int", nullable: false),
                    PVPGameId = table.Column<int>(type: "int", nullable: true),
                    PVEGameId = table.Column<int>(type: "int", nullable: true),
                    NPCId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaws", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spaws_NPCs_NPCId",
                        column: x => x.NPCId,
                        principalSchema: "Battle.PVE",
                        principalTable: "NPCs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Spaws_PVEGames_PVEGameId",
                        column: x => x.PVEGameId,
                        principalSchema: "Battle.PVE",
                        principalTable: "PVEGames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Spaws_PVPGames_PVPGameId",
                        column: x => x.PVPGameId,
                        principalSchema: "Battle.PVP",
                        principalTable: "PVPGames",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemRecipes",
                schema: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemRecipes_Items_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Item",
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "Item",
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "Configurations",
                table: "DefaultServerConfigs",
                columns: new[] { "Id", "Description", "Name", "Value" },
                values: new object[,]
                {
                    { 0, null, "PublicRSAKey", "-----BEGIN PUBLIC KEY-----\r\nMFwwDQYJKoZIhvcNAQEBBQADSwAwSAJBAL1ezivGNWo8deIaiWOtukZ5hsczjqza\r\nuNeF0ieYdWN8fE6/YZpB4ZOyZiGhp8EfRlFpUjzPtw1i5CcA7K+SWHUCAwEAAQ==\r\n-----END PUBLIC KEY-----" },
                    { 1, null, "PrivateRSAKey", "-----BEGIN RSA PRIVATE KEY-----\r\nMIIBOgIBAAJBAL1ezivGNWo8deIaiWOtukZ5hsczjqzauNeF0ieYdWN8fE6/YZpB\r\n4ZOyZiGhp8EfRlFpUjzPtw1i5CcA7K+SWHUCAwEAAQJAMLJxiDY3RDN6CQPT8ssZ\r\nDMhxjUZH2VGBmQKzsTT2cvd94bH7V4ETGv011Tv5d31eeMudGLkiwUMIQUVBq/ba\r\nPQIhAOLCUPZxw4v/e3GnRi8Zm31wymdGk40AFuPApAGNFbDnAiEA1co6HkX4psjf\r\ny+XzxcSPlojhiyb98CQV2x5akJz1FEMCIQCLQHVjwl0pvgzasLSi/ADGudsyLN8z\r\nuZhU6NpOsYtehQIgMFrAEG7VEawnai/FljqiG3M0SEv2baVLyDayVzkY+Y8CIBji\r\ngNSm2/bwJM4fYfSsHD2BXOTneOWWP9ZtM6i30gWC\r\n-----END RSA PRIVATE KEY-----" }
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
                table: "ItemsCategoriesTypes",
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
                schema: "Item",
                table: "ShopCategoriesTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 0, "Battle itens", "Battle itens" },
                    { 1, "Dressing itens", "Dressing itens" },
                    { 2, "Props itens", "Props itens" },
                    { 3, "Exchange itens", "Exchange itens" },
                    { 4, "Free itens", "Free itens" }
                });

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
                name: "IX_CharacterItems_CharacterId",
                schema: "Character",
                table: "CharacterItems",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterItems_ItemId",
                schema: "Character",
                table: "CharacterItems",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterQuestContidionProgress_CharacterQuestsId",
                schema: "Quest",
                table: "CharacterQuestContidionProgress",
                column: "CharacterQuestsId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterQuestContidionProgress_QuestConditionTypeId",
                schema: "Quest",
                table: "CharacterQuestContidionProgress",
                column: "QuestConditionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterQuests_QuestId",
                schema: "Quest",
                table: "CharacterQuests",
                column: "QuestId");

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
                name: "IX_DefaultServerRates_RateTypeId",
                schema: "Configurations",
                table: "DefaultServerRates",
                column: "RateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciples_CharacterId",
                schema: "Character",
                table: "Disciples",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_CharacterId",
                schema: "Character",
                table: "Friends",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRecipes_ItemId",
                schema: "Item",
                table: "ItemRecipes",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRecipes_RecipeId",
                schema: "Item",
                table: "ItemRecipes",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_BagTypesId",
                schema: "Item",
                table: "Items",
                column: "BagTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Hole1Id",
                schema: "Item",
                table: "Items",
                column: "Hole1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Hole2Id",
                schema: "Item",
                table: "Items",
                column: "Hole2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Hole3Id",
                schema: "Item",
                table: "Items",
                column: "Hole3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Hole4Id",
                schema: "Item",
                table: "Items",
                column: "Hole4Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Hole5Id",
                schema: "Item",
                table: "Items",
                column: "Hole5Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Hole6Id",
                schema: "Item",
                table: "Items",
                column: "Hole6Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemBindTypeId",
                schema: "Item",
                table: "Items",
                column: "ItemBindTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemsCategoryId",
                schema: "Item",
                table: "Items",
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
                name: "IX_Marriages_PartnerId",
                schema: "Character",
                table: "Marriages",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PVEStages_MapId",
                schema: "Battle.PVE",
                table: "PVEStages",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_PVEStages_PVEId",
                schema: "Battle.PVE",
                table: "PVEStages",
                column: "PVEId");

            migrationBuilder.CreateIndex(
                name: "IX_PVEStages_RoomDifficultyTypesId",
                schema: "Battle.PVE",
                table: "PVEStages",
                column: "RoomDifficultyTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_PVEStages_RoomTypeId",
                schema: "Battle.PVE",
                table: "PVEStages",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PVPGames_PVPStages",
                schema: "Battle.PVP",
                table: "PVPGames",
                column: "PVPStages");

            migrationBuilder.CreateIndex(
                name: "IX_PVPStages_MapId",
                schema: "Battle.PVP",
                table: "PVPStages",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_PVPStages_RoomTypeId",
                schema: "Battle.PVP",
                table: "PVPStages",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Quests_PreQuestId",
                schema: "Quest",
                table: "Quests",
                column: "PreQuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Quests_QuestGroupsId",
                schema: "Quest",
                table: "Quests",
                column: "QuestGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeAward_ItemId",
                schema: "Item",
                table: "RecipeAward",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeAwardId",
                schema: "Item",
                table: "Recipes",
                column: "RecipeAwardId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeTypesId",
                schema: "Item",
                table: "Recipes",
                column: "RecipeTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopItems_ItemId",
                schema: "Item",
                table: "ShopItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopItems_ShopCategoryId",
                schema: "Item",
                table: "ShopItems",
                column: "ShopCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Spaws_NPCId",
                schema: "Battle",
                table: "Spaws",
                column: "NPCId");

            migrationBuilder.CreateIndex(
                name: "IX_Spaws_PVEGameId",
                schema: "Battle",
                table: "Spaws",
                column: "PVEGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Spaws_PVPGameId",
                schema: "Battle",
                table: "Spaws",
                column: "PVPGameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterCards",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "CharacterItems",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "CharacterQuestContidionProgress",
                schema: "Quest");

            migrationBuilder.DropTable(
                name: "CharacterRanks",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "DefaultServerConfigs",
                schema: "Configurations");

            migrationBuilder.DropTable(
                name: "DefaultServerRates",
                schema: "Configurations");

            migrationBuilder.DropTable(
                name: "Disciples",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "Friends",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "ItemRecipes",
                schema: "Item");

            migrationBuilder.DropTable(
                name: "Levels",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "MarriageProposals",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "Marriages",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "PVEStages",
                schema: "Battle.PVE");

            migrationBuilder.DropTable(
                name: "ShopItems",
                schema: "Item");

            migrationBuilder.DropTable(
                name: "Spaws",
                schema: "Battle");

            migrationBuilder.DropTable(
                name: "Cards",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "CharacterQuests",
                schema: "Quest");

            migrationBuilder.DropTable(
                name: "QuestConditionTypes",
                schema: "Quest");

            migrationBuilder.DropTable(
                name: "RateTypes",
                schema: "Configurations");

            migrationBuilder.DropTable(
                name: "Recipes",
                schema: "Item");

            migrationBuilder.DropTable(
                name: "Characters",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "PVEDifficultyTypes",
                schema: "Battle");

            migrationBuilder.DropTable(
                name: "ShopCategoriesTypes",
                schema: "Item");

            migrationBuilder.DropTable(
                name: "NPCs",
                schema: "Battle.PVE");

            migrationBuilder.DropTable(
                name: "PVEGames",
                schema: "Battle.PVE");

            migrationBuilder.DropTable(
                name: "PVPGames",
                schema: "Battle.PVP");

            migrationBuilder.DropTable(
                name: "Quests",
                schema: "Quest");

            migrationBuilder.DropTable(
                name: "RecipeAward",
                schema: "Item");

            migrationBuilder.DropTable(
                name: "RecipeTypes",
                schema: "Item");

            migrationBuilder.DropTable(
                name: "Ranks",
                schema: "Character");

            migrationBuilder.DropTable(
                name: "PVPStages",
                schema: "Battle.PVP");

            migrationBuilder.DropTable(
                name: "QuestGroups",
                schema: "Quest");

            migrationBuilder.DropTable(
                name: "Items",
                schema: "Item");

            migrationBuilder.DropTable(
                name: "Maps",
                schema: "Battle");

            migrationBuilder.DropTable(
                name: "StageTypes",
                schema: "Battle");

            migrationBuilder.DropTable(
                name: "BagTypes",
                schema: "Item");

            migrationBuilder.DropTable(
                name: "ItemBindTypes",
                schema: "Item");

            migrationBuilder.DropTable(
                name: "ItemHoleTypes",
                schema: "Item");

            migrationBuilder.DropTable(
                name: "ItemsCategoriesTypes",
                schema: "Item");
        }
    }
}
