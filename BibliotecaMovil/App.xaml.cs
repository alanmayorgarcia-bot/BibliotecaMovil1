using BibliotecaMovil.Data;

namespace BibliotecaMovil
{
    public partial class App : Application
    {
        private static LibroDAO? _libroRepository;

        public static LibroDAO LibroRepository
        {
            get
            {
                if (_libroRepository == null)
                {
                    string dbPath = Path.Combine(FileSystem.AppDataDirectory, "biblioteca.db");
                    _libroRepository = new LibroDAO(dbPath);
                }
                return _libroRepository;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
        }
    }
}