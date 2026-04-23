using System;

namespace Semana09_PatronBuilder
{
  
    /// Clase que representa un usuario del sistema.
    /// Todas las propiedades son de solo lectura desde fuera (private set).
    /// El constructor es internal para que solo el Builder pueda crear instancias.
  
    public class Usuario
    {
        public string Nombre { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; } 

        public string Rol { get; private set; }
        public string Telefono { get; private set; }
        public string Direccion { get; private set; }
        public bool EstaActiva { get; private set; } = true;

       
        /// Constructor internal 
        internal Usuario(string nombre, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre es obligatorio");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("El email es obligatorio");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("La contraseña es obligatoria");

            Nombre = nombre;
            Email = email;
            Password = password;
        }

        // Métodos internos para que el Builder configure las propiedades opcionales
        internal void EstablecerRol(string rol) => Rol = rol;
        internal void EstablecerTelefono(string telefono) => Telefono = telefono;
        internal void EstablecerDireccion(string direccion) => Direccion = direccion;
        internal void EstablecerEstado(bool activa) => EstaActiva = activa;

        public override string ToString()
        {
            return $"Usuario: {Nombre}\n" +
                   $"Email:   {Email}\n" +
                   $"Rol:     {Rol ?? "Sin rol asignado"}\n" +
                   $"Teléfono: {Telefono ?? "No registrado"}\n" +
                   $"Dirección: {Direccion ?? "No registrada"}\n" +
                   $"Estado:   {(EstaActiva ? "Activa" : "Inactiva")}\n" +
                   "----------------------------------------";
        }
    }
}