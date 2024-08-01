using LivrariaMVC.Models;
using LivrariaMVC.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LivrariaMVC.Repository
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly AppDbContext _context;

        public GeneroRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genero> Generos =>  _context.Generos.AsNoTracking().OrderBy(x => x.GeneroId).ToList();

        public async Task<int> CreateAsync(Genero genero)
        {
            try
            {
                await _context.Generos.AddAsync(genero);
                await _context.SaveChangesAsync();
                return genero.GeneroId;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao fazer inserção no banco");
            }

        }

        public async Task<bool> DeleteAsync(Genero genero)
        {
            try
            {
                _context.Generos.Remove(genero);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao fazer remoção do banco");

            }
        }

        public async Task<Genero> GetByIdAsync(int id)
        {
            Genero? genero = await _context.Generos.AsNoTracking().FirstOrDefaultAsync(x => x.GeneroId == id);
            return genero;
        }

        public async Task<Genero> GetByNameAsync(string? name)
        {
            return await _context.Generos.AsNoTracking().FirstOrDefaultAsync(x => x.GeneroNome.ToLower().Trim() == name.ToLower().Trim());


        }

        public async Task<bool> UpdateAsync(Genero genero)
        {
            try
            {
                _context.Update(genero);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao fazer update");
            }
        }

    }
}
