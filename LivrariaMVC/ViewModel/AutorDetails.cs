using LivrariaMVC.Models;

namespace LivrariaMVC.ViewModel
{
    public class AutorDetails
    {
        public Autor Autor { get; set; }
        public IEnumerable<Livro> Livros { get; set; }
    }
}
