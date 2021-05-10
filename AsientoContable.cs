using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A889126.Actividad03
{
    class AsientoContable
    {
        public int NumeroAsiento { get; set; }
        public DateTime Fecha { get; set; }
        public int CodigoCuenta { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }

        public AsientoContable() { }

        public AsientoContable(string linea)
        {
            var datos = linea.Split(';');
            NumeroAsiento = int.Parse(datos[0]);
            Fecha = DateTime.Parse(datos[1]);
            CodigoCuenta = int.Parse(datos[2]);
            Debe = decimal.Parse(datos[3]);
            Haber = decimal.Parse(datos[4]);
        }

        public void MostrarAsientoContable()
        {
            Console.WriteLine();
            Console.WriteLine($"Numero de asiento {NumeroAsiento}");
            Console.WriteLine($"Fecha {Fecha.ToShortDateString()}");
            Console.WriteLine($"Codigo cuenta {CodigoCuenta}");
            Console.WriteLine($"Debe {Debe}");
            Console.WriteLine($"Haber {Haber}");
            Console.WriteLine();
        }

        public static AsientoContable Busqueda()
        {
            var modelo = new AsientoContable();
            modelo.NumeroAsiento = IngresarNumeroAsiento(obligatorio: false);
            return modelo;
        }

        public bool CoincideCon(AsientoContable modelo)
        {
            if (modelo.NumeroAsiento != 0 && modelo.NumeroAsiento != NumeroAsiento)
            {
                return false;
            }
            return true;

        }

        private static int IngresarNumeroAsiento(bool obligatorio = true)
        {
            var titulo = "Ingrese el numero de asiento";
            if (!obligatorio)
            {
                titulo += " o presione [Enter] para continuar";
            }

            do
            {
                Console.WriteLine(titulo);
                var ingreso = Console.ReadLine();
                if (!obligatorio && string.IsNullOrWhiteSpace(ingreso))
                {
                    return 0;
                }

                if (!int.TryParse(ingreso, out var numeroAsiento))
                {
                    Console.WriteLine("No ha ingresado un numero de asiento válido");
                    continue;
                }

                return numeroAsiento;

            } while (true);
        }
    }
}
