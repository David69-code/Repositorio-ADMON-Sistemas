using System;

namespace Semana09_PatronBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Semana 9 - Patrón Builder";

            bool salir = false;

            // Bucle principal del menú interactivo
            while (!salir)
            {
                MostrarMenuPrincipal();

                Console.Write("\nSelecciona una opción (1-4): ");
                string opcion = Console.ReadLine()?.Trim();

                Console.Clear(); // Limpia la pantalla para mejor legibilidad

                switch (opcion)
                {
                    case "1":
                        EjecutarCaso1Usuarios();
                        break;

                    case "2":
                        EjecutarCaso2Reportes();
                        break;

                    case "3":
                        EjecutarAmbosCasos();
                        break;

                    case "4":
                        salir = true;
                        Console.WriteLine("\n¡Gracias por usar el programa! Hasta luego.\n");
                        break;

                    default:
                        Console.WriteLine("\nOpción inválida. Elige 1, 2, 3 o 4.\n");
                        break;
                }

                // Pausa antes de volver al menú (excepto al salir)
                if (!salir)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        // Método para mostrar el menú principal
     
        static void MostrarMenuPrincipal()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("   SEMANA 9 - PATRÓN BUILDER");
            Console.WriteLine("=====================================\n");

            Console.WriteLine("1. Caso 1: Registro de usuarios");
            Console.WriteLine("2. Caso 2: Generación de reportes");
            Console.WriteLine("3. Ejecutar ambos casos");
            Console.WriteLine("4. Salir");
            Console.WriteLine("-------------------------------------");
        }

        // Caso 1: Usuarios con Builder
        // Aquí se muestra el patrón Builder para crear objetos Usuario.
        // Solo se requieren nombre, email y contraseña (obligatorios).
        static void EjecutarCaso1Usuarios()
        {
            Console.WriteLine("=== CASO 1: Registro de usuarios ===\n");

            // Ejemplo 1: Paquita la del Barrio
            var paquita = new UsuarioBuilder("Paquita la del Barrio", "paquita@justiciaymoral.com", "¡AnimalRastrero!")
                .ConRol("Defensora de la Decencia")          // Opcional
                .ConTelefono("+503 2222-4567")               // Opcional
                .ConDireccion("Chalate")                     // Opcional
                .Build();                                    // Construye el objeto final

            // Ejemplo 2: Vicente Fernández (solo datos mínimos + uno opcional)
            var vicente = new UsuarioBuilder("Vicente Fernández", "vicente@elrey.com", "VolverVolver")
                .ConRol("Rey de la Ranchera")                // Opcional
                .Build();                                    // Construye sin dirección ni teléfono

            Console.WriteLine(paquita);
            Console.WriteLine(vicente);
        }

        // Caso 2: Reportes con Builder
        // "Aquí se usa el patrón Builder para crear objetos Reporte.
        // Solo el título es obligatorio. Las demás secciones (autor, fecha, gráfico, conclusiones, comentarios)
        // son opcionales y se agregan según se necesite.
        
        static void EjecutarCaso2Reportes()
        {
            Console.WriteLine("=== CASO 2: Generación de reportes ===\n");

            // Ejemplo 1: Reporte de Michael Jackson (solo título + conclusiones y comentarios)
            var reporteMJ = new ReporteBuilder("Impacto Cultural de Thriller")
                .ConAutor("Michael Jackson")
                .ConConclusiones("La música une al mundo y rompe barreras raciales y culturales.")
                .ConComentariosFinales("Hee-hee! Keep the faith.")
                .Build();

            // Ejemplo 2: Reporte de Tony Stark (título + gráfico + conclusiones)
            var reporteStark = new ReporteBuilder("Evolución de Tecnología Stark Industries")
                .ConAutor("Tony Stark - Iron Man")
                .ConGrafico("Diagrama de armaduras: Mark I → Mark LXXXV")
                .ConConclusiones("La innovación constante salva vidas y redefine lo posible.")
                .ConComentariosFinales("Casi me pongo serio contra Thanos.")
                .Build();

            Console.WriteLine(reporteMJ);
            Console.WriteLine("───────────────────────────────────────\n");
            Console.WriteLine(reporteStark);
        }

       
        static void EjecutarAmbosCasos()
        {
            EjecutarCaso1Usuarios();
            Console.WriteLine("\n───────────────────────────────────────\n───────────────────────────────────────\n");
            EjecutarCaso2Reportes();
        }
    }
}