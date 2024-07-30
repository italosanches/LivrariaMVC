using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivrariaMVC.Models
{
    [Table("Autores")]
    public class Autor
    {
        public Autor()
        {
            
        }
        public Autor(string name)
        {
            AutorName = name;
        }
        [Key]
        public int AutorId { get; set; }
        [Required(ErrorMessage ="Nome é obrigatorio.")]
        [StringLength(50,ErrorMessage ="Nome deve ser menor que {0}")]
        [Display(Name = "Nome")]
        public string? AutorName { get; set;}

        public string? AutorImgUrl { get; set; }

        public IEnumerable<LivroAutor> LivroAutores { get; set; } = new List<LivroAutor>();
    }
}
