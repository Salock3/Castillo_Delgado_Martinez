namespace ProyectoAnashe
{
    public partial class MainPage : ContentPage
    {
        private readonly string clave;

        public MainPage()
        {
            InitializeComponent();
        }
        private void CrearUsuario(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaguinaPrincipal());
        }
        private void Ckick_anashe(object sender, EventArgs e)
        {
          
                Navigation.PushAsync(new CrearUsuari1());
            
        }
        private bool EsValido(string usuario, string clave)
        {
            // Validación de usuario y clave (puedes agregar lógica más avanzada aquí)
            return usuario == "usuario" && clave == "clave";
        }
       

    }
}