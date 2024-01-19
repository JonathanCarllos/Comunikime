using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comunikime.Migrations
{
    public partial class PopularProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Produtos(CategoriaId,DescricaoCurta,Descricao,Estoque,ImagemThumbnailUrl,ImagemUrl,Preco,Nome) values(1, 'Caneta escolar', 'caneta esferografica', 1, 'https://http2.mlstatic.com/D_NQ_NP_2X_971577-MLB44653901933_012021-F.webp', 'https://http2.mlstatic.com/D_NQ_NP_2X_971577-MLB44653901933_012021-F.webp', 3.50, 'Caneta Bic')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Produtos");
        }
    }
}
