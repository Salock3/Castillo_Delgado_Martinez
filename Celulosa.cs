using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace ProyectoAnashe
{
    enum Sexo
    {
        Masculino,
        Femenino
    }

    internal class Fecha
    {
        public Fecha() { }

        public int Dia { set; get; }
        public int Mes { set; get; }
        public int Anio { set; get; }
    }

    internal class Cliente
    {
        public int rut { set; get; }
        private int identificador { set; get; }

        public string Clave { set; get; }
        public string NombreCliente { set; get; }
        public string ApellidoPaternoCliente { set; get; }
        public string ApellidoMaternoCliente { set; get; }
        public Fecha FechaNacimientoCliente { set; get; }

        public Cliente(int rut, string nombreCliente, string clave, string apellidoPaternoCliente, string apellidoMaternoCliente, Fecha fechaNacimientoCliente)
        {
            this.rut = rut;
            this.Clave = clave;
            this.NombreCliente = nombreCliente;
            this.ApellidoPaternoCliente = apellidoPaternoCliente;
            this.ApellidoMaternoCliente = apellidoMaternoCliente;
            this.FechaNacimientoCliente = fechaNacimientoCliente;
        }

        public void SetFechaNacimiento(int dia, int mes, int anio)
        {
            FechaNacimientoCliente = new Fecha
            {
                Dia = dia,
                Mes = mes,
                Anio = anio
            };
        }

        public Sexo Sexo { set; get; }
    }

    internal class Producto
    {
        private int idProducto { set; get; }

        public int IdProducto { set; get; }
        public int Cantidad { set; get; }
        public double Precio { set; get; }
        public string NombreProducto { set; get; }

        public Producto(int idProducto, double precio, string nombreProducto, int cantidad)
        {
            this.idProducto = idProducto;
            this.Precio = precio;
            this.NombreProducto = nombreProducto;
            this.Cantidad = cantidad;
        }
    }

    internal class Venta
    {
        public int Precio { set; get; }
        public int Cantidad { set; get; }
        public Fecha FechaCompra { set; get; }

        public void SetFechaCompra(int dia, int mes, int anio)
        {
            FechaCompra = new Fecha
            {
                Dia = dia,
                Mes = mes,
                Anio = anio
            };
        }
    }

    internal class Administrador
    {
        private int idAdministrador { set; get; }
        public int id { set; get; }
        public int IdAdministrador { set; get; }
        public string NombreAdmin { set; get; }
        public string ApellidoPaternoAdmin { set; get; }
        public string ApellidoMaternoAdmin { set; get; }
        public string Cargo { set; get; }
    }

    internal class Bodega
    {
        public int EspacioBodega { set; get; }
        public string NombreBodega { set; get; }
    }

    
}