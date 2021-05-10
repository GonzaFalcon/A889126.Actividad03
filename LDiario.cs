using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A889126.Actividad03
{
    class LDiario
    {
        private static readonly Dictionary<int, AsientoContable> entradas;
        const string nombreArchivo = "Diario.txt";

        static LDiario()
        {
            entradas = new Dictionary<int, AsientoContable>();

            if (File.Exists(nombreArchivo))
            {
                using (var reader = new StreamReader(nombreArchivo))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var asientos = new AsientoContable(linea);
                        entradas.Add(asientos.NumeroAsiento, asientos);
                    }
                }

            }
        }

        public static void MovimientosFuturos(int codigoCuenta, DateTime fecha, ref decimal debe, ref decimal haber)
        {
            if (entradas.Count == 0)
            {
                Console.WriteLine("No existen asientos cargados en el libro diario.");
            }
            else
            {
                foreach (var asiento in entradas.Values)
                {
                    if (codigoCuenta == asiento.CodigoCuenta)
                    {
                        if (fecha < asiento.Fecha)
                        {
                            debe += asiento.Debe;
                            haber += asiento.Haber;
                        }
                    }

                }
            }
        }

        public static AsientoContable Seleccionar()
        {
            var modelo = AsientoContable.Busqueda();
            foreach (var asientos in entradas.Values)
            {
                if (asientos.CoincideCon(modelo))
                {
                    return asientos;
                }
            }

            Console.WriteLine("No se ha encontrado una cuenta que coincida");
            return null;
        }
    }
}
