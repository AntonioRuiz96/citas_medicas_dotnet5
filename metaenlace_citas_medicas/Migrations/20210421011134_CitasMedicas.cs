using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace metaenlace_citas_medicas.Migrations
{
    public partial class CitasMedicas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    clave = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "MEDICOS",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false),
                    numColegiado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICOS", x => x.userID);
                    table.ForeignKey(
                        name: "FK_MEDICOS_USUARIOS_userID",
                        column: x => x.userID,
                        principalTable: "USUARIOS",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PACIENTES",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false),
                    NSS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numTarjeta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTES", x => x.userID);
                    table.ForeignKey(
                        name: "FK_PACIENTES_USUARIOS_userID",
                        column: x => x.userID,
                        principalTable: "USUARIOS",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    citaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    motivoCita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pacienteUserID = table.Column<int>(type: "int", nullable: false),
                    medicoUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.citaID);
                    table.ForeignKey(
                        name: "FK_Citas_MEDICOS_medicoUserID",
                        column: x => x.medicoUserID,
                        principalTable: "MEDICOS",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_PACIENTES_pacienteUserID",
                        column: x => x.pacienteUserID,
                        principalTable: "PACIENTES",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicoPaciente",
                columns: table => new
                {
                    medicosuserID = table.Column<int>(type: "int", nullable: false),
                    pacientesuserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoPaciente", x => new { x.medicosuserID, x.pacientesuserID });
                    table.ForeignKey(
                        name: "FK_MedicoPaciente_MEDICOS_medicosuserID",
                        column: x => x.medicosuserID,
                        principalTable: "MEDICOS",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicoPaciente_PACIENTES_pacientesuserID",
                        column: x => x.pacientesuserID,
                        principalTable: "PACIENTES",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosticos",
                columns: table => new
                {
                    diagnosticoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valoracionEspecialista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enfermedad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    citaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosticos", x => x.diagnosticoID);
                    table.ForeignKey(
                        name: "FK_Diagnosticos_Citas_citaID",
                        column: x => x.citaID,
                        principalTable: "Citas",
                        principalColumn: "citaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_medicoUserID",
                table: "Citas",
                column: "medicoUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_pacienteUserID",
                table: "Citas",
                column: "pacienteUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosticos_citaID",
                table: "Diagnosticos",
                column: "citaID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicoPaciente_pacientesuserID",
                table: "MedicoPaciente",
                column: "pacientesuserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnosticos");

            migrationBuilder.DropTable(
                name: "MedicoPaciente");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "MEDICOS");

            migrationBuilder.DropTable(
                name: "PACIENTES");

            migrationBuilder.DropTable(
                name: "USUARIOS");
        }
    }
}
