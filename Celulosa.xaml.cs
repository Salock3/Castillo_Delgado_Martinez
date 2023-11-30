namespace ProyectoAnashe;

public partial class CrearUsuari1 : ContentPage
{
	public CrearUsuari1()
	{
		InitializeComponent();
	}
	private void Almacenar_bienAnashe(object sender, EventArgs e)
	{
		Navigation.PushAsync(new Almacenimiento());
    }
	private void Buscar_BienAnashe(object obj, EventArgs e)
	{
		Navigation.PushAsync(new Buscador());

    }
}