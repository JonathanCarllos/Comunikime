using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comunikime.Migrations
{
    public partial class PopularCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Categorias(CategoriaNome, Descricao) values('Escolar', 'Pequena haste em que se encaixa ou a que se adapta um lápis ou a que se ajusta um aparo, para que se possa escrever.')");

            migrationBuilder.Sql("insert into Categorias(CategoriaNome, Descricao) values('Celular','O smartphone é um celular com tecnologias avançadas, o que inclui programas executados um sistema operacional, equivalente aos computadores.')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Categorias");
        }
    }
}
