using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivrariaMVC.Models
{
    [Table("Generos")]
    public class Genero
    {
        [Key]
        public int GeneroId { get; set; }


        [Required(ErrorMessage = "O genero é obrigatorio.")]
        [Display(Name = "Genero de Livro")]
        [Column(TypeName = "varchar(50)")]
        [MinLength(1, ErrorMessage = "O nome deve conter no minimo uma letra")]
        public string? GeneroNome { get; set;}

        public IEnumerable<LivroGenero> LivrosGeneros { get; set; } = new List<LivroGenero>();
    }
}
