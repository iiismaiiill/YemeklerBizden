using Microsoft.EntityFrameworkCore.Migrations;

namespace yemekoneri.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanicis",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SurName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicis", x => x.KullaniciId);
                });

            migrationBuilder.CreateTable(
                name: "Yemeks",
                columns: table => new
                {
                    YemekId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YemekAdi = table.Column<string>(nullable: true),
                    YemekAciklamasi = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    Yorumlar = table.Column<string>(nullable: true),
                    KullaniciId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yemeks", x => x.YemekId);
                    table.ForeignKey(
                        name: "FK_Yemeks_Kullanicis_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicis",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Begens",
                columns: table => new
                {
                    BegenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsLike = table.Column<bool>(nullable: false),
                    KullaniciId = table.Column<int>(nullable: true),
                    YemekId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Begens", x => x.BegenId);
                    table.ForeignKey(
                        name: "FK_Begens_Kullanicis_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicis",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Begens_Yemeks_YemekId",
                        column: x => x.YemekId,
                        principalTable: "Yemeks",
                        principalColumn: "YemekId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Yorums",
                columns: table => new
                {
                    YorumId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YorumMail = table.Column<string>(nullable: true),
                    YorumAciklama = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    KullaniciId = table.Column<int>(nullable: true),
                    YemekId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorums", x => x.YorumId);
                    table.ForeignKey(
                        name: "FK_Yorums_Kullanicis_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicis",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Yorums_Yemeks_YemekId",
                        column: x => x.YemekId,
                        principalTable: "Yemeks",
                        principalColumn: "YemekId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Begens_KullaniciId",
                table: "Begens",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Begens_YemekId",
                table: "Begens",
                column: "YemekId");

            migrationBuilder.CreateIndex(
                name: "IX_Yemeks_KullaniciId",
                table: "Yemeks",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorums_KullaniciId",
                table: "Yorums",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorums_YemekId",
                table: "Yorums",
                column: "YemekId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Begens");

            migrationBuilder.DropTable(
                name: "Yorums");

            migrationBuilder.DropTable(
                name: "Yemeks");

            migrationBuilder.DropTable(
                name: "Kullanicis");
        }
    }
}
