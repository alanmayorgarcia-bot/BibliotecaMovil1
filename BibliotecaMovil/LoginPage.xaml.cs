namespace BibliotecaMovil;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnIngresarClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(TxtUsuario.Text) && !string.IsNullOrWhiteSpace(TxtPassword.Text))
        {
            await Navigation.PushAsync(new CatalogoPage());
        }
        else
        {
            await DisplayAlert("Atención", "Ingresa usuario y contraseña para continuar.", "OK");
        }
    }
}