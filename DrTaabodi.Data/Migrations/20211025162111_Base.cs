using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DrTaabodi.Data.Migrations
{
    public partial class Base : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostCategoryTbl",
                columns: table => new
                {
                    PostCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostCategoryTblPostCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategoryTbl", x => x.PostCategoryId);
                    table.ForeignKey(
                        name: "FK_PostCategoryTbl_PostCategoryTbl_PostCategoryTblPostCategoryId",
                        column: x => x.PostCategoryTblPostCategoryId,
                        principalTable: "PostCategoryTbl",
                        principalColumn: "PostCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostTypeTbl",
                columns: table => new
                {
                    PostTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostTypeTblPostTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTypeTbl", x => x.PostTypeId);
                    table.ForeignKey(
                        name: "FK_PostTypeTbl_PostTypeTbl_PostTypeTblPostTypeId",
                        column: x => x.PostTypeTblPostTypeId,
                        principalTable: "PostTypeTbl",
                        principalColumn: "PostTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PstTbl",
                columns: table => new
                {
                    PstId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PstContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PstTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PstDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PstTblPstId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PstTbl", x => x.PstId);
                    table.ForeignKey(
                        name: "FK_PstTbl_PstTbl_PstTblPstId",
                        column: x => x.PstTblPstId,
                        principalTable: "PstTbl",
                        principalColumn: "PstId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QnATbl",
                columns: table => new
                {
                    QnAId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QnATbl", x => x.QnAId);
                });

            migrationBuilder.CreateTable(
                name: "UsrTbl",
                columns: table => new
                {
                    UsrId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PassCode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    UsrNickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsrFamily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsrEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsrStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsrTbl", x => x.UsrId);
                });

            migrationBuilder.CreateTable(
                name: "WebsiteOptionsTbls",
                columns: table => new
                {
                    OptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebsiteOptionsTbls", x => x.OptionId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostCategoryTblPstTbl",
                columns: table => new
                {
                    PostCategoryTablePostCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostTablePstId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategoryTblPstTbl", x => new { x.PostCategoryTablePostCategoryId, x.PostTablePstId });
                    table.ForeignKey(
                        name: "FK_PostCategoryTblPstTbl_PostCategoryTbl_PostCategoryTablePostCategoryId",
                        column: x => x.PostCategoryTablePostCategoryId,
                        principalTable: "PostCategoryTbl",
                        principalColumn: "PostCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostCategoryTblPstTbl_PstTbl_PostTablePstId",
                        column: x => x.PostTablePstId,
                        principalTable: "PstTbl",
                        principalColumn: "PstId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTypeTblPstTbl",
                columns: table => new
                {
                    PostTablePstId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostTypeTablePostTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTypeTblPstTbl", x => new { x.PostTablePstId, x.PostTypeTablePostTypeId });
                    table.ForeignKey(
                        name: "FK_PostTypeTblPstTbl_PostTypeTbl_PostTypeTablePostTypeId",
                        column: x => x.PostTypeTablePostTypeId,
                        principalTable: "PostTypeTbl",
                        principalColumn: "PostTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTypeTblPstTbl_PstTbl_PostTablePstId",
                        column: x => x.PostTablePstId,
                        principalTable: "PstTbl",
                        principalColumn: "PstId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PstTblUsrTbl",
                columns: table => new
                {
                    PostTablePstId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserTableUsrId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PstTblUsrTbl", x => new { x.PostTablePstId, x.UserTableUsrId });
                    table.ForeignKey(
                        name: "FK_PstTblUsrTbl_PstTbl_PostTablePstId",
                        column: x => x.PostTablePstId,
                        principalTable: "PstTbl",
                        principalColumn: "PstId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PstTblUsrTbl_UsrTbl_UserTableUsrId",
                        column: x => x.UserTableUsrId,
                        principalTable: "UsrTbl",
                        principalColumn: "UsrId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QnATblUsrTbl",
                columns: table => new
                {
                    QuestionAndAnswerTableQnAId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserTableUsrId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QnATblUsrTbl", x => new { x.QuestionAndAnswerTableQnAId, x.UserTableUsrId });
                    table.ForeignKey(
                        name: "FK_QnATblUsrTbl_QnATbl_QuestionAndAnswerTableQnAId",
                        column: x => x.QuestionAndAnswerTableQnAId,
                        principalTable: "QnATbl",
                        principalColumn: "QnAId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QnATblUsrTbl_UsrTbl_UserTableUsrId",
                        column: x => x.UserTableUsrId,
                        principalTable: "UsrTbl",
                        principalColumn: "UsrId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategoryTbl_PostCategoryTblPostCategoryId",
                table: "PostCategoryTbl",
                column: "PostCategoryTblPostCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategoryTblPstTbl_PostTablePstId",
                table: "PostCategoryTblPstTbl",
                column: "PostTablePstId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTypeTbl_PostTypeTblPostTypeId",
                table: "PostTypeTbl",
                column: "PostTypeTblPostTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTypeTblPstTbl_PostTypeTablePostTypeId",
                table: "PostTypeTblPstTbl",
                column: "PostTypeTablePostTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PstTbl_PstTblPstId",
                table: "PstTbl",
                column: "PstTblPstId");

            migrationBuilder.CreateIndex(
                name: "IX_PstTblUsrTbl_UserTableUsrId",
                table: "PstTblUsrTbl",
                column: "UserTableUsrId");

            migrationBuilder.CreateIndex(
                name: "IX_QnATblUsrTbl_UserTableUsrId",
                table: "QnATblUsrTbl",
                column: "UserTableUsrId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PostCategoryTblPstTbl");

            migrationBuilder.DropTable(
                name: "PostTypeTblPstTbl");

            migrationBuilder.DropTable(
                name: "PstTblUsrTbl");

            migrationBuilder.DropTable(
                name: "QnATblUsrTbl");

            migrationBuilder.DropTable(
                name: "WebsiteOptionsTbls");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PostCategoryTbl");

            migrationBuilder.DropTable(
                name: "PostTypeTbl");

            migrationBuilder.DropTable(
                name: "PstTbl");

            migrationBuilder.DropTable(
                name: "QnATbl");

            migrationBuilder.DropTable(
                name: "UsrTbl");
        }
    }
}
