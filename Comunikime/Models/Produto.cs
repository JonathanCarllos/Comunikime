using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Comunikime.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O nome do produto deve ser informado")]
        [Display(Name = "Nome do Produto")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O {0} deve ter no minímo{1} e no máximo{2}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O nome da descrição deve ser informado")]
        [Display(Name = "Descrição")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "O {0} deve ter no minímo{1} e no máximo{2}")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O nome da descrição detalhada deve ser informado")]
        [Display(Name = "Descrição detalhada")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "O {0} deve ter no minímo{1} e no máximo{2}")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "O nome do preço deve ser informado")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "O preço deve está entre R$1,00 e R$999,99")]
        public decimal Preco { get; set; }

        [Display(Name = "Caminho da Imagem")]
        [StringLength(200, ErrorMessage = " O {0} caminho da imagem deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho da Imagem miniatura")]
        [StringLength(200, ErrorMessage = " O {0} caminho da imagem deve ter no máximo {1} caracteres")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Estoque")]
        public bool Estoque { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }    
}