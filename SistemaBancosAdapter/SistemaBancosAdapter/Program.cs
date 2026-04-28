using System;

namespace SistemaBancosAdapter
{
    // 1. Creamos la interfaz (El contrato) 
    public interface IPagoModerno
    {
        void RealizarPago(double monto);
    }

   // 2. Implementamos la interfaz en una clase (El sistema moderno) 
    public class SistemaModerno : IPagoModerno
    {
        public void RealizarPago(double monto)
        {
            Console.WriteLine($"[SISTEMA MODERNO] Procesando pago de ${monto} con tecnología actual.");
        }
    }

    // 3. Creamos la clase que "no habla el mismo idioma" (El sistema antiguo/legado) 
    // Esta clase NO implementa la interfaz, por lo que no es compatible directamente.
    public class ServicioAntiguoEfectivo
    {
        public void CobrarEnEfectivo(double monto)
        {
            Console.WriteLine($"[SISTEMA ANTIGUO] Cobrando ${monto} directamente en efectivo.");
        }
    }

    // 4. Creamos el Adaptador usando inyección de dependencias 
    public class AdaptadorPago : IPagoModerno
    {
        private readonly ServicioAntiguoEfectivo _servicioAntiguo;

        // Inyección de dependencias en el constructor
        public AdaptadorPago(ServicioAntiguoEfectivo servicio)
        {
            _servicioAntiguo = servicio;
        }

        public void RealizarPago(double monto)
        {
            // El adaptador hace que el sistema antiguo actúe como el moderno 
            Console.WriteLine("[ADAPTADOR] Traduciendo pago a formato antiguo...");
            _servicioAntiguo.CobrarEnEfectivo(monto);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Ejecución según la guía
            ServicioAntiguoEfectivo servicioViejo = new ServicioAntiguoEfectivo();

            // Usamos el adaptador para integrar el sistema viejo al nuevo flujo
            IPagoModerno sistema = new AdaptadorPago(servicioViejo);

            sistema.RealizarPago(250.00);

            Console.WriteLine("\nAlgoritmo ejecutado. Presiona una tecla para salir.");
            Console.ReadKey();
        }
    }
}