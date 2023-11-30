using System.ComponentModel.Design;
using System.Xml;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using Windows.Networking.Connectivity;
using Windows.System;

namespace ProyectoAnashe;

public partial class Almacenimiento : ContentPage
{
   
    string strConect = "data source =ProyectoAnashe";
    List<Producto> LosMisproductos = new List<Producto>();
    private object datos;
    List<Producto> pro;
    string appData;
    string fileName;
    public Almacenimiento()
	{
		InitializeComponent();
        pro = new List<Producto>();
        appData = FileSystem.Current.AppDataDirectory;
        fileName = "Producto.json";
    }
	
	private void Agregar(object sender, EventArgs e)
	{
       
        string Precio = PrecioProducto.Text;
        string idProducto = idProd.Text;
        string NombreProducto = NombreProduct.Text;
		string cantidardo = CantidadProducto.Text;
        int Id = int.Parse(idProd.Text);
        int idProductos = Convert.ToInt32(idProd.Text);
        Producto Misproducto = new Producto(Int32.Parse(idProducto), Int32.Parse(Precio), NombreProducto,Int32.Parse(cantidardo));
		LosMisproductos.Add(Misproducto);
		PrecioProducto.Text = "";
		idProd.Text = "";
		NombreProduct.Text = "";
		CantidadProducto.Text = "";

        if (PrecioProducto.Text == string.Empty || idProd.Text == string.Empty || NombreProduct.Text == string.Empty || CantidadProducto.Text == string.Empty)
        {
            var alert = DisplayAlert("URL", appData, "Ok");
            var Misproductardos = new Producto(Int32.Parse(Precio), Int32.Parse(idProducto), NombreProducto, Int32.Parse(cantidardo));
            pro.Add(Misproductardos);
            string usersJson = JsonConvert.SerializeObject(pro, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(appData + '/' + fileName, usersJson);
            DisplayAlert("Json", usersJson, "Ok");
            
        }
        else
        {
            DisplayAlert("Ingresar Usuarios", "Campos sin datos\nUsuario no agregado", "ok");
        }
    }
	
    private void ingresar(object sender, EventArgs e)
    {
        string id = Id.Text;
        if (Id.Text == idProd.Text)
        {
            DisplayAlert("Datos Erronio", "ok", "ok");
        }      
        else
        {
            string datos = "datos\n";
            foreach (var Misproducto in LosMisproductos)
            {
                datos += $"Cantidad:{Misproducto.Cantidad}\n";
                datos += $"Precio:{Misproducto.Precio}\n";
                datos += $"Nombre:{Misproducto.NombreProducto}\n";
                datos += "------------------------\n";
            }
            DisplayAlert("datos guardado", datos, "ok");
        }    
    }  
        

    
}