using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyUsuarioInEmpresa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtividadePrincipal_Empresa_Empresaid",
                table: "AtividadePrincipal");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Endereco_Enderecoid",
                table: "Empresa");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Users",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "numero",
                table: "Endereco",
                newName: "Numero");

            migrationBuilder.RenameColumn(
                name: "municipio",
                table: "Endereco",
                newName: "Municipio");

            migrationBuilder.RenameColumn(
                name: "logradouro",
                table: "Endereco",
                newName: "Logradouro");

            migrationBuilder.RenameColumn(
                name: "complemento",
                table: "Endereco",
                newName: "Complemento");

            migrationBuilder.RenameColumn(
                name: "cep",
                table: "Endereco",
                newName: "CEP");

            migrationBuilder.RenameColumn(
                name: "bairro",
                table: "Endereco",
                newName: "Bairro");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Endereco",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Enderecoid",
                table: "Empresa",
                newName: "EnderecoId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Empresa",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Empresa_Enderecoid",
                table: "Empresa",
                newName: "IX_Empresa_EnderecoId");

            migrationBuilder.RenameColumn(
                name: "Empresaid",
                table: "AtividadePrincipal",
                newName: "EmpresaId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AtividadePrincipal",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_AtividadePrincipal_Empresaid",
                table: "AtividadePrincipal",
                newName: "IX_AtividadePrincipal_EmpresaId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Empresa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_UserId",
                table: "Empresa",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtividadePrincipal_Empresa_EmpresaId",
                table: "AtividadePrincipal",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Endereco_EnderecoId",
                table: "Empresa",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Users_UserId",
                table: "Empresa",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtividadePrincipal_Empresa_EmpresaId",
                table: "AtividadePrincipal");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Endereco_EnderecoId",
                table: "Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Users_UserId",
                table: "Empresa");

            migrationBuilder.DropIndex(
                name: "IX_Empresa_UserId",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Empresa");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Users",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Endereco",
                newName: "numero");

            migrationBuilder.RenameColumn(
                name: "Municipio",
                table: "Endereco",
                newName: "municipio");

            migrationBuilder.RenameColumn(
                name: "Logradouro",
                table: "Endereco",
                newName: "logradouro");

            migrationBuilder.RenameColumn(
                name: "Complemento",
                table: "Endereco",
                newName: "complemento");

            migrationBuilder.RenameColumn(
                name: "CEP",
                table: "Endereco",
                newName: "cep");

            migrationBuilder.RenameColumn(
                name: "Bairro",
                table: "Endereco",
                newName: "bairro");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Endereco",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "EnderecoId",
                table: "Empresa",
                newName: "Enderecoid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Empresa",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Empresa_EnderecoId",
                table: "Empresa",
                newName: "IX_Empresa_Enderecoid");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "AtividadePrincipal",
                newName: "Empresaid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AtividadePrincipal",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_AtividadePrincipal_EmpresaId",
                table: "AtividadePrincipal",
                newName: "IX_AtividadePrincipal_Empresaid");

            migrationBuilder.AddForeignKey(
                name: "FK_AtividadePrincipal_Empresa_Empresaid",
                table: "AtividadePrincipal",
                column: "Empresaid",
                principalTable: "Empresa",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Endereco_Enderecoid",
                table: "Empresa",
                column: "Enderecoid",
                principalTable: "Endereco",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
