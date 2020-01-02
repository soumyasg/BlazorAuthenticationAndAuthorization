using Microsoft.EntityFrameworkCore.Migrations;

namespace BocesModule.Api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoSerGroups",
                columns: table => new
                {
                    CoSerGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoSerGroupCode = table.Column<string>(nullable: false),
                    CoSerGroupName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoSerGroups", x => x.CoSerGroupId);
                });

            migrationBuilder.InsertData(
                table: "CoSerGroups",
                columns: new[] { "CoSerGroupId", "CoSerGroupCode", "CoSerGroupName" },
                values: new object[] { 1, "CoSerGroup1", "CoSer Group 1" });

            migrationBuilder.InsertData(
                table: "CoSerGroups",
                columns: new[] { "CoSerGroupId", "CoSerGroupCode", "CoSerGroupName" },
                values: new object[] { 2, "CoSerGroup2", "CoSer Group 2" });

            migrationBuilder.InsertData(
                table: "CoSerGroups",
                columns: new[] { "CoSerGroupId", "CoSerGroupCode", "CoSerGroupName" },
                values: new object[] { 3, "CoSerGroup3", "CoSer Group 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoSerGroups");
        }
    }
}
