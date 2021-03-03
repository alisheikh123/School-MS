using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School_MS.Data.Migrations
{
    public partial class newtbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblSubject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSubject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblChapter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChaptertName = table.Column<string>(nullable: true),
                    SubjectID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblChapter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblChapter_tblSubject_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "tblSubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(nullable: true),
                    Chaptertid = table.Column<int>(nullable: true),
                    QuestionNo = table.Column<string>(nullable: false),
                    QuestionName = table.Column<string>(nullable: false),
                    QuestionAnswer = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    VideoUrl = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblQuestion_tblChapter_Chaptertid",
                        column: x => x.Chaptertid,
                        principalTable: "tblChapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblQuestion_tblSubject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "tblSubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblChapter_SubjectID",
                table: "tblChapter",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_tblQuestion_Chaptertid",
                table: "tblQuestion",
                column: "Chaptertid");

            migrationBuilder.CreateIndex(
                name: "IX_tblQuestion_SubjectId",
                table: "tblQuestion",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblQuestion");

            migrationBuilder.DropTable(
                name: "tblChapter");

            migrationBuilder.DropTable(
                name: "tblSubject");
        }
    }
}
