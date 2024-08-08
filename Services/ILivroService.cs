
using BibliotecaApp.Data;
using BibliotecaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApp.Services
{
    public interface ILivroService
    {
        Task<List<Livro>> GetAllLivrosAsync();
        Task<Livro> GetLivroByIdAsync(int id);
        Task CreateLivroAsync(Livro livro);
        Task UpdateLivroAsync(Livro livro);
        Task DeleteLivroAsync(int id);
        Task<List<Categoria>> GetAllCategoriasAsync();

    }

    public class LivroService : ILivroService
    {
        private readonly BibliotecaContext _context;

        public LivroService(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<List<Livro>> GetAllLivrosAsync()
        {
            return await _context.Livros
                                 .Include(l => l.Categoria) // Inclui a categoria
                                 .ToListAsync();
        }

        public async Task<Livro> GetLivroByIdAsync(int id)
        {
            return await _context.Livros.FindAsync(id);
        }

        public async Task CreateLivroAsync(Livro livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLivroAsync(Livro livro)
        {
            _context.Entry(livro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLivroAsync(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro != null)
            {
                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();
            }
        }

        // CATEGORIAS
        public async Task<List<Categoria>> GetAllCategoriasAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

    }

}
