using Microsoft.Maui.Controls;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;

namespace ProyectoAnashe;
public class User
{

}
public partial class PaguinaPrincipal : ContentPage
{
    
    List<Cliente> clie;
    string appData;
    string fileName;
    string clave;
    private const string ClaveCorrecta = "contrasena";
    int count;
	List<Cliente> MISCLIENTES = new List<Cliente>();
    private object datos;
    public PaguinaPrincipal()
	{
		InitializeComponent();
        clie = new List<Cliente>();
        appData = FileSystem.Current.AppDataDirectory;
        fileName = "Cliente.json";
    }
    

    private void Cliked_Usuario(object sender, EventArgs e)
    {
        string nombreCliente = EntryUsuario.Text;
        string Clave = EntryRut.Text;
        string rut = EntryClave.Text;
        string apellidoPaternoCliente = EntryApellidoPaterno.Text;
        string apellidoMaternoCliente = EntryApellidoMaterno.Text;
        Fecha MisFechas = new Fecha();
        int dia = int.Parse(EnntryDia.Text);
        int mes = int.Parse(EntryMes.Text);
        int Anhio = int.Parse(EntryAño.Text);
        Cliente MisCliente = new Cliente(Int32.Parse(Clave), nombreCliente, rut, apellidoPaternoCliente, apellidoMaternoCliente, MisFechas);
        MISCLIENTES.Add(MisCliente);
        EntryUsuario.Text = "";
        EntryClave.Text = "";
        EntryRut.Text = "";
        EntryApellidoPaterno.Text = "";
        EntryApellidoMaterno.Text = "";
        EnntryDia.Text = "";
        EntryMes.Text = "";
        EntryAño.Text = "";
        DisplayAlert("Éxito", "Creacion de sesion éxitosa", "Aceptar");
        Navigation.PushAsync(new CrearUsuari1());
        if (EntryRut.Text == string.Empty || EntryClave.Text == string.Empty)
        {
            var alert = DisplayAlert("URL", appData, "Ok");
            var user = new Cliente(Int32.Parse(Clave), nombreCliente, rut, apellidoPaternoCliente, apellidoMaternoCliente, MisFechas);
            clie.Add(user);
            string usersJson = JsonConvert.SerializeObject(clie, Formatting.Indented);
            File.WriteAllText(appData + '\\' + fileName, usersJson);
        }
        else
        {
            DisplayAlert("Ingresar Usuarios", "Campos sin datos\nUsuario no agregado", "ok");
        }
    }
    private void Mostrar_usuario(object sender, EventArgs e)
    {
        string datos = "datos\n";
        foreach (var MISCLIENTES in MISCLIENTES)
        {
            datos += $"Nombre: {MISCLIENTES.NombreCliente}\n";
            datos += $"Clave: {MISCLIENTES.Clave}\n";
            datos += $"Rut: {MISCLIENTES.rut}\n";
            datos += $"Apellidos: {MISCLIENTES.ApellidoPaternoCliente},{MISCLIENTES.ApellidoMaternoCliente}\n";
            datos += $"Fecha: {MISCLIENTES.FechaNacimientoCliente}\n";
            datos += "------------------------\n";
        }
        DisplayAlert("Datos", datos, "Ok");

    }
    private void cli(object sender, EventArgs e)
    {
        string json = File.ReadAllText(appData + '\\' + fileName);
        DisplayAlert("Json", json, "Ok");
        List<User> users = new List<User>();
        users = JsonConvert.DeserializeObject<List<User>>(json);
        DisplayAlert("Json", json, "Ok");
    }
}