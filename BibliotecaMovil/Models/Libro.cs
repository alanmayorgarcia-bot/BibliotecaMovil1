using SQLite;

namespace BibliotecaMovil.Models
{
    [Table("Libros")]
    public class Libro
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Titulo { get; set; } = string.Empty;

        [NotNull]
        public string Autor { get; set; } = string.Empty;

        public string Categoria { get; set; } = string.Empty;

        public bool Disponible { get; set; } = true;
    }
}