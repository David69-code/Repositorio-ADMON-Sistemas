using System;

namespace Semana09_PatronBuilder
{

    /// Clase que representa un reporte generado en el sistema.
    /// Muchas secciones son opcionales.
  
    public class Reporte
    {
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public DateTime Fecha { get; private set; } = DateTime.Now;
        public string TablaDatos { get; private set; }
        public string Grafico { get; private set; }
        public string Conclusiones { get; private set; }
        public string ComentariosFinales { get; private set; }

        internal Reporte(string titulo)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("El título del reporte es obligatorio");

            Titulo = titulo;
        }

        // Métodos internos para configuración desde el Builder
        internal void EstablecerAutor(string autor) => Autor = autor;
        internal void EstablecerFecha(DateTime fecha) => Fecha = fecha;
        internal void EstablecerTablaDatos(string tabla) => TablaDatos = tabla;
        internal void EstablecerGrafico(string grafico) => Grafico = grafico;
        internal void EstablecerConclusiones(string conclusiones) => Conclusiones = conclusiones;
        internal void EstablecerComentariosFinales(string comentarios) => ComentariosFinales = comentarios;

        public override string ToString()
        {
            string texto = $"REPORTE: {Titulo}\n" +
                           $"Fecha: {Fecha:dd/MM/yyyy HH:mm}\n";

            if (!string.IsNullOrWhiteSpace(Autor))
                texto += $"Autor: {Autor}\n";

            texto += "\n----------------------------------------\n";

            if (!string.IsNullOrWhiteSpace(TablaDatos))
                texto += $"Datos:\n{TablaDatos}\n\n";

            if (!string.IsNullOrWhiteSpace(Grafico))
                texto += $"Gráfico: {Grafico}\n\n";

            if (!string.IsNullOrWhiteSpace(Conclusiones))
                texto += $"Conclusiones:\n{Conclusiones}\n\n";

            if (!string.IsNullOrWhiteSpace(ComentariosFinales))
                texto += $"Comentarios finales:\n{ComentariosFinales}\n";

            return texto + "----------------------------------------";
        }
    }
}