namespace Semana09_PatronBuilder
{
    /// Builder para crear objetos Usuario de forma flexible.
    /// Permite encadenar métodos (fluent interface) y solo obliga a los datos mínimos.
   
    public class UsuarioBuilder
    {
        // Campos obligatorios (se pasan en el constructor)
        private readonly string _nombre;
        private readonly string _email;
        private readonly string _password;

        // Campos opcionales
        private string _rol;
        private string _telefono;
        private string _direccion;
        private bool _estaActiva = true;

        public UsuarioBuilder(string nombre, string email, string password)
        {
            _nombre = nombre;
            _email = email;
            _password = password;
        }

        // Métodos fluentes (devuelven this para encadenar)
        public UsuarioBuilder ConRol(string rol)
        {
            _rol = rol;
            return this;
        }

        public UsuarioBuilder ConTelefono(string telefono)
        {
            _telefono = telefono;
            return this;
        }

        public UsuarioBuilder ConDireccion(string direccion)
        {
            _direccion = direccion;
            return this;
        }

        public UsuarioBuilder CuentaInactiva()
        {
            _estaActiva = false;
            return this;
        }

        
        /// Método final que construye y devuelve el objeto Usuario completo
        
        public Usuario Build()
        {
            // Creamos el objeto con los datos obligatorios
            var usuario = new Usuario(_nombre, _email, _password);

            // Configuramos los opcionales si fueron proporcionados
            if (_rol != null) usuario.EstablecerRol(_rol);
            if (_telefono != null) usuario.EstablecerTelefono(_telefono);
            if (_direccion != null) usuario.EstablecerDireccion(_direccion);
            usuario.EstablecerEstado(_estaActiva);

            return usuario;
        }
    }
}