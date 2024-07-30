using LivrariaMVC.Models;

namespace LivrariaMVC.Repository.Interfaces
{
    public interface IAutorRepository
    {
        IEnumerable<Autor> Autores { get; }

        public Task<Autor> GetByIdAsync(int id);

        public Task<Autor> GetByNameAsync(string name);

        public Task<int> CreateAsync(Autor autor); 

        public Task<bool> UpdateAsync(Autor autor);

        public Task<bool> DeleteAsync(Autor autor);
    }
}
