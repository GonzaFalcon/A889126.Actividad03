using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A889126.Actividad03
{
    class Program
    {
        static void Main(string[] args)
        {
            //SI SU NÚMERO DE REGISTRO TERMINA EN 4-6 Realice la aplicación 2)

            /*File => permite manejar archivos como un todo
            //StreamReader => permite leer archivos
            //Streamwriter => permite escribir archivos
            */

            bool salir = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Por favor seleccione el numero de la operacion que desea realizar y presione Enter: ");
                Console.WriteLine("-------------");

                Console.WriteLine("1 - Consultar libro mayor");
                Console.WriteLine("2 - Actualizar libro mayor");
                Console.WriteLine("3 - Salir");
                Console.WriteLine();

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Consultar();
                        break;
                    case "2":
                        ActualizarMayor();
                        break;
                    case "3":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("No ha ingresado una opción del menú");
                        break;
                }

            } while (!salir);
        }

        private static void Consultar()
        {
            var cuentas = LMayor.Seleccionar();
            cuentas?.MostrarCuenta();
        }

        private static void ActualizarMayor()
        {
            var cuentas = LMayor.Actualizar();
            if (cuentas == false)
            {
                return;
            }

            LMayor.MostrarDatosActualizados();
        }
    }
}
