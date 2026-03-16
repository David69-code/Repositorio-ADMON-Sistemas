using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioSemana9.Caso_1
{
    public class Usuario
    {
        // Propiedades del perfil de usuario
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }

        public void MostrarPerfil()
        {
            System.Console.WriteLine($"--- Perfil de {Nombre} ---");
            System.Console.WriteLine($"Rol: {Rol} | Email: {Correo}");
            System.Console.WriteLine($"Dirección: {Direccion ?? "No proporcionada"}");
            System.Console.WriteLine("---------------------------\n");
        }
    }
}