using LivrariaMVC.Models;
using LivrariaMVC.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LivrariaMVC.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly AppDbContext _context;
        public AutorRepository(AppDbContext context)
        {
            _context = context;   
        }
        public IEnumerable<Autor> Autores => _context.Autores.AsNoTracking().ToList();  

        public async Task<int> CreateAsync(Autor autor)
        {
            try 
            {
              await  _context.Autores.AddAsync(autor); 
              await  _context.SaveChangesAsync();
               return autor.AutorId;
            }
            catch(Exception ex) 
            {
                throw new Exception("Erro ao fazer inserção no banco");
            }
           
        }

        public async Task<bool> DeleteAsync(Autor autor)
        {
            try
            {
                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
               
                throw new Exception("Erro ao fazer remoção do banco");
                
            }
        }

        public async Task<Autor> GetByIdAsync(int id)
        {
            Autor? autor = await _context.Autores.AsNoTracking().FirstOrDefaultAsync(x => x.AutorId == id);
            return autor;
        }

        public async Task<Autor> GetByNameAsync(string name)
        {
            Autor? autor = await _context.Autores.AsNoTracking().FirstOrDefaultAsync(x => x.AutorName.ToLower() == name.ToLower());
            return autor;

        }

        public async Task<bool> UpdateAsync(Autor autor)
        {
            throw new NotImplementedException();
        }

        
    }
}
