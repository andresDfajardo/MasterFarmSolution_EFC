using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MasterFarmSolution.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgriculturalOperationsTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgriculturalOperationsTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Farmers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstNameFarmer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lastNameFarmer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    emailFarmer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phoneFarmer = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    addressFarmer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateLastConnection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PlotTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    plotType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlotTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Farms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    farmName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    farmerId = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farms", x => x.id);
                    table.ForeignKey(
                        name: "FK_Farms_Farmers_farmerId",
                        column: x => x.farmerId,
                        principalTable: "Farmers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    farmerId = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Farmers_farmerId",
                        column: x => x.farmerId,
                        principalTable: "Farmers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productTypeId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_productTypeId",
                        column: x => x.productTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plots",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    farmId = table.Column<int>(type: "int", nullable: false),
                    plotTypeId = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plots", x => x.id);
                    table.ForeignKey(
                        name: "FK_Plots_Farms_farmId",
                        column: x => x.farmId,
                        principalTable: "Farms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plots_PlotTypes_plotTypeId",
                        column: x => x.plotTypeId,
                        principalTable: "PlotTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameAnimal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    plotId = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.id);
                    table.ForeignKey(
                        name: "FK_Animals_Plots_plotId",
                        column: x => x.plotId,
                        principalTable: "Plots",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crops",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    harvestDays = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    plotId = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crops", x => x.id);
                    table.ForeignKey(
                        name: "FK_Crops_Plots_plotId",
                        column: x => x.plotId,
                        principalTable: "Plots",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgriculturalOperations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cropId = table.Column<int>(type: "int", nullable: false),
                    dateOperation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    operationTypeId = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgriculturalOperations", x => x.id);
                    table.ForeignKey(
                        name: "FK_AgriculturalOperations_AgriculturalOperationsTypes_operationTypeId",
                        column: x => x.operationTypeId,
                        principalTable: "AgriculturalOperationsTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgriculturalOperations_Crops_cropId",
                        column: x => x.cropId,
                        principalTable: "Crops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HarvestRecords",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    operationId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HarvestRecords", x => x.id);
                    table.ForeignKey(
                        name: "FK_HarvestRecords_AgriculturalOperations_operationId",
                        column: x => x.operationId,
                        principalTable: "AgriculturalOperations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HarvestRecords_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationXGames",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    agriculturalOperationId = table.Column<int>(type: "int", nullable: false),
                    gameId = table.Column<int>(type: "int", nullable: false),
                    dateTimeOperationXGame = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationXGames", x => x.id);
                    table.ForeignKey(
                        name: "FK_OperationXGames_AgriculturalOperations_agriculturalOperationId",
                        column: x => x.agriculturalOperationId,
                        principalTable: "AgriculturalOperations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationXGames_Games_gameId",
                        column: x => x.gameId,
                        principalTable: "Games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgriculturalOperations_cropId",
                table: "AgriculturalOperations",
                column: "cropId");

            migrationBuilder.CreateIndex(
                name: "IX_AgriculturalOperations_operationTypeId",
                table: "AgriculturalOperations",
                column: "operationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_plotId",
                table: "Animals",
                column: "plotId");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_plotId",
                table: "Crops",
                column: "plotId");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_farmerId",
                table: "Farms",
                column: "farmerId");

            migrationBuilder.CreateIndex(
                name: "IX_HarvestRecords_operationId",
                table: "HarvestRecords",
                column: "operationId");

            migrationBuilder.CreateIndex(
                name: "IX_HarvestRecords_productId",
                table: "HarvestRecords",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationXGames_agriculturalOperationId",
                table: "OperationXGames",
                column: "agriculturalOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationXGames_gameId",
                table: "OperationXGames",
                column: "gameId");

            migrationBuilder.CreateIndex(
                name: "IX_Plots_farmId",
                table: "Plots",
                column: "farmId");

            migrationBuilder.CreateIndex(
                name: "IX_Plots_plotTypeId",
                table: "Plots",
                column: "plotTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_productTypeId",
                table: "Products",
                column: "productTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_farmerId",
                table: "Users",
                column: "farmerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "HarvestRecords");

            migrationBuilder.DropTable(
                name: "OperationXGames");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AgriculturalOperations");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "AgriculturalOperationsTypes");

            migrationBuilder.DropTable(
                name: "Crops");

            migrationBuilder.DropTable(
                name: "Plots");

            migrationBuilder.DropTable(
                name: "Farms");

            migrationBuilder.DropTable(
                name: "PlotTypes");

            migrationBuilder.DropTable(
                name: "Farmers");
        }
    }
}
