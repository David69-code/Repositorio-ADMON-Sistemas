using System;
using System.Text;

namespace SistemaTransporte
{
    // ====================================================================
    // 1. EL PRODUCTO (Interfaz)
    // EXPLICACIÓN: "Primero creé la interfaz ITransporte. Esta actúa como 
    // un contrato que obliga a todos los medios de transporte a tener 
    // un método llamado IniciarViaje()."
    // ====================================================================
    public interface ITransporte
    {
        void IniciarViaje();
    }

    // ====================================================================
    // 2. PRODUCTOS CONCRETOS (Clases que implementan la interfaz)
    // EXPLICACIÓN: "Aquí están las clases concretas: Bus, Taxi y Bicicleta.
    // Cada una hereda de ITransporte y le da su propio comportamiento 
    // al método IniciarViaje() mostrando un mensaje en consola."
    // ====================================================================
    public class Bus : ITransporte
    {
        public void IniciarViaje()
        {
            Console.WriteLine("🚌 BUS: El bus ha iniciado su ruta. Subiendo pasajeros.");
        }
    }

    public class Taxi : ITransporte
    {
        public void IniciarViaje()
        {
            Console.WriteLine("🚕 TAXI: El taxi está en camino. Viaje privado en curso.");
        }
    }

    public class Bicicleta : ITransporte
    {
        public void IniciarViaje()
        {
            Console.WriteLine("🚲 BICICLETA: Bicicleta lista. Pedaleando por la ciclovía.");
        }
    }

    // ====================================================================
    // 3. LA CLASE CREADORA (Factory)
    // EXPLICACIÓN: "Esta es la parte central del patrón. La clase 
    // TransporteFactory tiene un método estático que recibe el tipo de 
    // transporte que queremos. Usando un switch, decide qué objeto 
    // instanciar (new Bus, new Taxi, etc.) y lo devuelve."
    // ====================================================================
    public class TransporteFactory
    {
        public static ITransporte CrearTransporte(string tipoTransporte)
        {
            switch (tipoTransporte.ToLower())
            {
                case "bus":
                    return new Bus();
                case "taxi":
                    return new Taxi();
                case "bicicleta":
                    return new Bicicleta();
                default:
                    // Si mandamos un transporte que no existe, lanzamos un error.
                    throw new ArgumentException($"El transporte '{tipoTransporte}' no existe en el sistema.");
            }
        }
    }

    // ====================================================================
    // 4. LÓGICA DE EJECUCIÓN (Programa Principal)
    // EXPLICACIÓN: "En el Main, en lugar de instanciar las clases directamente 
    // con la palabra 'new', le pido a la Fábrica que lo haga por mí. 
    // Esto hace que el código sea ordenado y fácil de mantener."
    // ====================================================================
    class Program
    {
        static void Main(string[] args)
        {
            // Esta línea arregla el problema de los signos de interrogación '??' 
            // para que la consola muestre los emojis correctamente.
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("=== SISTEMA DE TRANSPORTE (FACTORY METHOD) ===\n");

            try
            {
                // Solicitamos un Bus a la fábrica
                ITransporte transporte1 = TransporteFactory.CrearTransporte("bus");
                transporte1.IniciarViaje();

                // Solicitamos un Taxi a la fábrica
                ITransporte transporte2 = TransporteFactory.CrearTransporte("taxi");
                transporte2.IniciarViaje();

                // Solicitamos una Bicicleta a la fábrica
                ITransporte transporte3 = TransporteFactory.CrearTransporte("bicicleta");
                transporte3.IniciarViaje();
            }
            catch (Exception ex)
            {
                // Captura cualquier error si pedimos algo que no está en la fábrica
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nPresione cualquier tecla para finalizar...");
            Console.ReadKey();
        }
    }
}