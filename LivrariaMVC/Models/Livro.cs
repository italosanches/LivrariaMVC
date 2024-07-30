using LivrariaMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivrariaMVC.Models
{
    [Table("Livros")]
    public class Livro
    {
        [Key]
        public int LivroId { get; set; }

        [Required(ErrorMessage ="O nome do livro é obrigatorio.")]
        [Display(Name ="Titulo do Livro")]
        [Column(TypeName ="varchar(50)")]
        [MinLength(1,ErrorMessage ="O nome deve conter no minimo uma letra")]
        public string? LivroTitulo { get; set; }


        [Required(ErrorMessage = "A descrição do livro é obrigatoria.")]
        [Display(Name = "Descrição do Livro")]
        [Column(TypeName = "varchar(100)")]
        [MinLength(1, ErrorMessage = "O nome deve conter no minimo uma letra")]
        public string? LivroDescricao { get; set; }

        [Display(Name = "Quantidade de paginas.")]
        public int LivroQuantidadePaginas { get; set; }

        [Display(Name ="Data de publicação.")]
        public DateTime LivroDataPublicacao { get; set; }


        public string? LivroImgUrl { get; set; }


        public IEnumerable<LivroAutor> LivrosAutores { get; set; } = new List<LivroAutor>();
        public IEnumerable<LivroGenero> LivrosGeneros { get; set; } = new List<LivroGenero>();


        public StatusLivro StatusLivro { get; set; }
    }
}
