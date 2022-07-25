using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEventsEntityFrameworkDb.Migrations
{
    public partial class _2022_07_25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Galleries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galleries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.id);
                    table.ForeignKey(
                        name: "FK__Countries__city___75A278F5",
                        column: x => x.city_id,
                        principalTable: "Cities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    second_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    country_id = table.Column<int>(type: "int", nullable: true),
                    city_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK__Users__city_id__778AC167",
                        column: x => x.city_id,
                        principalTable: "Cities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Users__country_i__76969D2E",
                        column: x => x.country_id,
                        principalTable: "Countries",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Users__role_id__7E37BEF6",
                        column: x => x.role_id,
                        principalTable: "Roles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    country_id = table.Column<int>(type: "int", nullable: true),
                    city_id = table.Column<int>(type: "int", nullable: true),
                    gallery_id = table.Column<int>(type: "int", nullable: true),
                    time_of_event = table.Column<TimeSpan>(type: "time", nullable: true),
                    date_of_event = table.Column<DateTime>(type: "date", nullable: true),
                    address = table.Column<string>(type: "nchar(80)", fixedLength: true, maxLength: 80, nullable: true),
                    acceptable_age = table.Column<int>(type: "int", nullable: true),
                    cost_of_visit = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.id);
                    table.ForeignKey(
                        name: "FK__Events__city_id__787EE5A0",
                        column: x => x.city_id,
                        principalTable: "Cities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Events__country___797309D9",
                        column: x => x.country_id,
                        principalTable: "Countries",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Events__gallery___7B5B524B",
                        column: x => x.gallery_id,
                        principalTable: "Galleries",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Events__user_id__7A672E12",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    gallery_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.id);
                    table.ForeignKey(
                        name: "FK__Images__gallery___7C4F7684",
                        column: x => x.gallery_id,
                        principalTable: "Galleries",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Images__user_id__7D439ABD",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CategoriesEvents",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    event_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesEvents", x => x.id);
                    table.ForeignKey(
                        name: "FK__Categorie__categ__02084FDA",
                        column: x => x.category_id,
                        principalTable: "Categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Categorie__event__01142BA1",
                        column: x => x.event_id,
                        principalTable: "Events",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    event_id = table.Column<int>(type: "int", nullable: true),
                    message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.id);
                    table.ForeignKey(
                        name: "FK__Messages__enent___7F2BE32F",
                        column: x => x.event_id,
                        principalTable: "Events",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Messages__user_i__00200768",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Categori__72E12F1B6CA6E7A6",
                table: "Categories",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesEvents_category_id",
                table: "CategoriesEvents",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesEvents_event_id",
                table: "CategoriesEvents",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_city_id",
                table: "Countries",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Countrie__72E12F1B0A12FB18",
                table: "Countries",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_city_id",
                table: "Events",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_Events_country_id",
                table: "Events",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_Events_gallery_id",
                table: "Events",
                column: "gallery_id");

            migrationBuilder.CreateIndex(
                name: "IX_Events_user_id",
                table: "Events",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Events__72E12F1BCB86E8B3",
                table: "Events",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Gallerie__72E12F1B67329A7C",
                table: "Galleries",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_gallery_id",
                table: "Images",
                column: "gallery_id");

            migrationBuilder.CreateIndex(
                name: "IX_Images_user_id",
                table: "Images",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Images__72E12F1B116F28F5",
                table: "Images",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_event_id",
                table: "Messages",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_user_id",
                table: "Messages",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Roles__72E12F1B4750934D",
                table: "Roles",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_city_id",
                table: "Users",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_country_id",
                table: "Users",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__760965CD1BC080B4",
                table: "Users",
                column: "role_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__AB6E6164C19E76E7",
                table: "Users",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriesEvents");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Galleries");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
