using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaApp.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres")]
        [Column("Titulo", TypeName = "nvarchar(100)")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O autor é obrigatório")]
        [StringLength(50, ErrorMessage = "O nome do autor deve ter no máximo 50 caracteres")]
        [Column("Autor", TypeName = "nvarchar(50)")]
        public string Autor { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de publicação é obrigatória")]
        [DataType(DataType.Date)]
        [Column("DataPublicacao", TypeName = "date")]
        public DateTime DataPublicacao { get; set; }

        [Required(ErrorMessage = "O gênero é obrigatório")]
        [StringLength(30, ErrorMessage = "O gênero deve ter no máximo 30 caracteres")]
        [Column("Genero", TypeName = "nvarchar(30)")]
        public string Genero { get; set; } = string.Empty;

        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; } = null!;
    }

    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; } = string.Empty;

        public ICollection<Livro> Livros { get; set; } = new List<Livro>();
    }
}
