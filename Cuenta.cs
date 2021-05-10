using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A889126.Actividad03
{
    class Cuenta
    {
        public int CodigoCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }

        public Cuenta() { }

        public Cuenta(string linea)
        {
            var datos = linea.Split(';');
            CodigoCuenta = int.Parse(datos[0]);
            Fecha = DateTime.Parse(datos[1]);
            Debe = decimal.Parse(datos[2]);
            Haber = decimal.Parse(datos[3]);
        }

        public string ObtenerLineaDatos() => $"{CodigoCuenta};{Fecha};{Debe};{Haber}";


        public void MostrarCuenta()
        {
            Console.WriteLine();
            Console.WriteLine($"Codigo cuenta: {CodigoCuenta}");
            Console.WriteLine($"Fecha: {Fecha.ToShortDateString()}");
            Console.WriteLine($"Debe: {Debe}");
            Console.WriteLine($"Haber: {Haber}");
            Console.WriteLine();
        }

        public static Cuenta Busqueda()
        {
            var modelo = new Cuenta();
            modelo.CodigoCuenta = IngresarCodigoCuenta(obligatorio: false);
            modelo.Fecha = IngresarFecha("Ingrese la fecha", obligatorio: false);
            return modelo;
        }

        public bool CoincideCon(Cuenta modelo)
        {
            if (modelo.CodigoCuenta != 0 && modelo.CodigoCuenta != CodigoCuenta)
            {
                return false;
            }
            if (modelo.Fecha != DateTime.MinValue && Fecha != modelo.Fecha)
            {
                return false;
            }
            return true;

        }

        private static int IngresarCodigoCuenta(bool obligatorio = true)
        {
            var titulo = "Ingrese el codigo de la cuenta";
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

                if (!int.TryParse(ingreso, out var codigoCuenta))
                {
                    Console.WriteLine("No ha ingresado un codigo de cuenta válido");
                    continue;
                }

                return codigoCuenta;

            } while (true);
        }

        private static DateTime IngresarFecha(string titulo, bool obligatorio = true)
        {
            do
            {
                if (!obligatorio)
                {
                    titulo += " o presione [Enter para continuar]";
                }

                Console.WriteLine(titulo);

                var ingreso = Console.ReadLine();

                if (!obligatorio && string.IsNullOrWhiteSpace(ingreso))
                {
                    return DateTime.MinValue;
                }

                if (!DateTime.TryParse(ingreso, out DateTime fechaNacimiento))
                {
                    Console.WriteLine("No es una fecha válida");
                    continue;
                }
                if (fechaNacimiento > DateTime.Now)
                {
                    Console.WriteLine("La fecha debe ser menor a la actual");
                    continue;
                }
                return fechaNacimiento;

            } while (true);
        }
    }
}
