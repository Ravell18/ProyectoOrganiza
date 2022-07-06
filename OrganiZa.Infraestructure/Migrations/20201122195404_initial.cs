using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrganiZa.Infraestructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calendarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MesPago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModoP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colegiatura = table.Column<double>(type: "float", nullable: false),
                    Statusdepago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alumno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdE = table.Column<int>(type: "int", nullable: false),
                    IdP = table.Column<int>(type: "int", nullable: false),
                    IdT = table.Column<int>(type: "int", nullable: false),
                    IdA = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rolusuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdT = table.Column<int>(type: "int", nullable: false),
                    IdA = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alumno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fichapago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Colegiatura = table.Column<double>(type: "float", nullable: false),
                    Mespagado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Voucher = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TutorId = table.Column<int>(type: "int", nullable: false),
                    IdE = table.Column<int>(type: "int", nullable: false),
                    Statusdepago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalendarioModelsId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Calendarios_CalendarioModelsId",
                        column: x => x.CalendarioModelsId,
                        principalTable: "Calendarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Escuelas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModoP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nreferencia = table.Column<int>(type: "int", nullable: false),
                    Colegiatura = table.Column<double>(type: "float", nullable: false),
                    IdA = table.Column<int>(type: "int", nullable: false),
                    CalendarioModelsId = table.Column<int>(type: "int", nullable: true),
                    PagosModelsId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escuelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Escuelas_Calendarios_CalendarioModelsId",
                        column: x => x.CalendarioModelsId,
                        principalTable: "Calendarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Escuelas_Pagos_PagosModelsId",
                        column: x => x.PagosModelsId,
                        principalTable: "Pagos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Administradors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rolusuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsersId = table.Column<int>(type: "int", nullable: true),
                    EscuelaModelsId = table.Column<int>(type: "int", nullable: true),
                    CalendarioModelsId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administradors_Calendarios_CalendarioModelsId",
                        column: x => x.CalendarioModelsId,
                        principalTable: "Calendarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Administradors_Escuelas_EscuelaModelsId",
                        column: x => x.EscuelaModelsId,
                        principalTable: "Escuelas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Administradors_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tutors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rolusuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alumno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<double>(type: "float", nullable: false),
                    NombreE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FichaPago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdE = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: true),
                    EscuelaModelsId = table.Column<int>(type: "int", nullable: true),
                    CalendarioModelsId = table.Column<int>(type: "int", nullable: true),
                    PagosModelsId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tutors_Calendarios_CalendarioModelsId",
                        column: x => x.CalendarioModelsId,
                        principalTable: "Calendarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tutors_Escuelas_EscuelaModelsId",
                        column: x => x.EscuelaModelsId,
                        principalTable: "Escuelas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tutors_Pagos_PagosModelsId",
                        column: x => x.PagosModelsId,
                        principalTable: "Pagos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tutors_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administradors_CalendarioModelsId",
                table: "Administradors",
                column: "CalendarioModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Administradors_EscuelaModelsId",
                table: "Administradors",
                column: "EscuelaModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Administradors_UsersId",
                table: "Administradors",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Escuelas_CalendarioModelsId",
                table: "Escuelas",
                column: "CalendarioModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Escuelas_PagosModelsId",
                table: "Escuelas",
                column: "PagosModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_CalendarioModelsId",
                table: "Pagos",
                column: "CalendarioModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutors_CalendarioModelsId",
                table: "Tutors",
                column: "CalendarioModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutors_EscuelaModelsId",
                table: "Tutors",
                column: "EscuelaModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutors_PagosModelsId",
                table: "Tutors",
                column: "PagosModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutors_UsersId",
                table: "Tutors",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradors");

            migrationBuilder.DropTable(
                name: "Tutors");

            migrationBuilder.DropTable(
                name: "Escuelas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Calendarios");
        }
    }
}
