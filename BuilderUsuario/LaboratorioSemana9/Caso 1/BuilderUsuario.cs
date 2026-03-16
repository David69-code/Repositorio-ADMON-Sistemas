using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioSemana9.Caso_1
{
    public class UsuarioBuilder
    {
        private Usuario _usuario = new Usuario();

        // Método para datos obligatorios al inicio
        public UsuarioBuilder ConDatosBasicos(string nombre, string correo, string pass)
        {
            _usuario.Nombre = nombre;
            _usuario.Correo = correo;
            _usuario.Password = pass;
            return this; // Retorna la misma instancia para encadenar métodos
        }

        public UsuarioBuilder ConRol(string rol)
        {
            _usuario.Rol = rol;
            return this;
        }

        public UsuarioBuilder ConDireccion(string direccion)
        {
            _usuario.Direccion = direccion;
            return this;
        }

        // Construye y retorna el objeto final
        public Usuario Build() => _usuario;
    }
}
