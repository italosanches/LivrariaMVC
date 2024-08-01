using LivrariaMVC.Models;

namespace LivrariaMVC.Repository.Interfaces
{
    public interface IGeneroRepository
    {
        IEnumerable<Genero> Generos { get; }

        public Task<Genero> GetByIdAsync(int id);

        public Task<Genero> GetByNameAsync(string name);

        public Task<int> CreateAsync(Genero genero);

        public Task<bool> UpdateAsync(Genero genero);

        public Task<bool> DeleteAsync(Genero genero);
    }
}
