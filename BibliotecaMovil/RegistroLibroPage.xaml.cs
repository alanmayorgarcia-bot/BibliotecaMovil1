using BibliotecaMovil.Models;

namespace BibliotecaMovil;

public partial class RegistroLibroPage : ContentPage
{
    public RegistroLibroPage()
    {
        InitializeComponent();
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TxtTitulo.Text) || string.IsNullOrWhiteSpace(TxtAutor.Text))
        {
            await DisplayAlert("Error", "Por favor completa el título y autor.", "OK");
            return;
        }

        var nuevoLibro = new Libro
        {
            Titulo = TxtTitulo.Text.Trim(),
            Autor = TxtAutor.Text.Trim(),
            Categoria = string.IsNullOrWhiteSpace(TxtCategoria.Text) ? "General" : TxtCategoria.Text.Trim(),
            Disponible = true
        };

        await App.LibroRepository.GuardarLibroAsync(nuevoLibro);
        await DisplayAlert("Éxito", "Libro registrado correctamente en la base de datos local.", "OK");
        await Navigation.PopAsync();
    }
}