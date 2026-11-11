using BibliotecaMovil.Models;

namespace BibliotecaMovil;

public partial class CatalogoPage : ContentPage
{
    public CatalogoPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CargarLibrosAsync();
    }

    private async Task CargarLibrosAsync()
    {
        List<Libro> lista = await App.LibroRepository.ObtenerTodosAsync();
        BindableLayout.SetItemsSource(ContenedorLibros, lista);
    }

    private async void OnNuevoLibroClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegistroLibroPage());
    }

    private async void OnRefrescarClicked(object sender, EventArgs e)
    {
        await CargarLibrosAsync();
    }

    private async void OnEliminarLibroClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button?.CommandParameter is Libro libro)
        {
            bool confirmar = await DisplayAlert("Confirmar", $"¿Deseas eliminar '{libro.Titulo}'?", "Sí", "No");
            if (confirmar)
            {
                await App.LibroRepository.EliminarLibroAsync(libro);
                await CargarLibrosAsync();
            }
        }
    }
}