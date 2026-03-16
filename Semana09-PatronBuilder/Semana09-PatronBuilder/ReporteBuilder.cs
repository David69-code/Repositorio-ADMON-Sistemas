using System;

namespace Semana09_PatronBuilder
{
    /// <summary>
    /// Builder para crear reportes de forma flexible.
    /// Solo obliga al título, el resto es opcional.
    /// </summary>
    public class ReporteBuilder
    {
        private readonly string _titulo;

        private string _autor;
        private DateTime? _fecha;
        private string _tablaDatos;
        private string _grafico;
        private string _conclusiones;
        private string _comentariosFinales;

        public ReporteBuilder(string titulo)
        {
            _titulo = titulo ?? throw new ArgumentNullException(nameof(titulo));
        }

        public ReporteBuilder ConAutor(string autor)
        {
            _autor = autor;
            return this;
        }

        public ReporteBuilder ConFechaPersonalizada(DateTime fecha)
        {
            _fecha = fecha;
            return this;
        }

        public ReporteBuilder ConTablaDatos(string tabla)
        {
            _tablaDatos = tabla;
            return this;
        }

        public ReporteBuilder ConGrafico(string grafico)
        {
            _grafico = grafico;
            return this;
        }

        public ReporteBuilder ConConclusiones(string conclusiones)
        {
            _conclusiones = conclusiones;
            return this;
        }

        public ReporteBuilder ConComentariosFinales(string comentarios)
        {
            _comentariosFinales = comentarios;
            return this;
        }

        public Reporte Build()
        {
            var reporte = new Reporte(_titulo);

            if (_autor != null) reporte.EstablecerAutor(_autor);
            if (_fecha.HasValue) reporte.EstablecerFecha(_fecha.Value);
            if (_tablaDatos != null) reporte.EstablecerTablaDatos(_tablaDatos);
            if (_grafico != null) reporte.EstablecerGrafico(_grafico);
            if (_conclusiones != null) reporte.EstablecerConclusiones(_conclusiones);
            if (_comentariosFinales != null) reporte.EstablecerComentariosFinales(_comentariosFinales);

            return reporte;
        }
    }
}