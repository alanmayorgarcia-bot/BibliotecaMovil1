using SQLite;
using BibliotecaMovil.Models;

namespace BibliotecaMovil.Data
{
    public class LibroDAO
    {
        private readonly SQLiteAsyncConnection _db;

        public LibroDAO(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Libro>().Wait();
        }

        public Task<List<Libro>> ObtenerTodosAsync() => _db.Table<Libro>().ToListAsync();

        public Task<Libro> ObtenerPorIdAsync(int id) => _db.Table<Libro>().Where(l => l.Id == id).FirstOrDefaultAsync();

        public Task<int> GuardarLibroAsync(Libro libro)
        {
            if (libro.Id != 0)
                return _db.UpdateAsync(libro);
            else
                return _db.InsertAsync(libro);
        }

        public Task<int> EliminarLibroAsync(Libro libro) => _db.DeleteAsync(libro);
    }
}