using System;

namespace Sistema_Inventario // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //EJERCICIOS DE BUCLE WHILE CON MÉTODOS

            // Cuando el método sea static string, es de mostrar mensajes o información relacionada con el método Main.
            // Cuando el método sea static int, es de cálculos numéricos o validaciones que devuelven un número entero.
            // Cuando el método sea static bool, es de validaciones que devuelven verdadero o falso.

            //Orden alfabético de variables
            bool opcionSalir = false;
            double precio = 0, validarPrecio = 0, guardarRegistro = 0, guardarPromedio = 0;
            int codigoProducto = 0, cantidadProducto = 0, validarCodigo = 0, totalCantidad = 0, contraseña = 0, validarCantidad = 0;
            string nombreProducto = "";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==== SISTEMA DE CONTROL DE INVENTARIO SIMPLE ====");
            Console.WriteLine("Por favor, ingresar la contraseña...");
            
            try
            {
                contraseña = Convert.ToInt32(Console.ReadLine() ?? "");
                Console.Clear();
            }
            catch (FormatException Fex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Por favor, ingresar únicamente datos NUMÉRICOS.");
                return;
            }

            

            if (contraseña != 1234)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Contraseña incorrecta. Acceso denegado.");
                return; // Termina la ejecución del programa si la contraseña es incorrecta.
            }

            Console.WriteLine("Bienvenido, por favor ingresa el nombre del producto.");
            nombreProducto = Console.ReadLine() ?? "";
            Console.Clear();

            if (nombreProducto == "") // Detecta espacios vacíos 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: No se ingresó ningún texto.");
                return;
            }
            else if (!nombreProducto.All(c => char.IsLetter(c) || c == ' ')) // Permite letras con espacios.
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Solo se permiten letras y espacios.");
                return;
            }


            Console.WriteLine("Por favor ingresa el código del producto. Válido desde 1 a 99");
            try
            {
                codigoProducto = Convert.ToInt32(Console.ReadLine()?? "");
                Console.Clear();
            }
            catch (FormatException Fex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Solo se deben ingresar valores NUMÉRICOS");

            }

            validarCodigo = LeerCodigo(codigoProducto);

            if (validarCodigo <= 0 || validarCodigo >= 100)
            {
                return; // Termina la ejecución del programa si el código no es válido.
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Código asignado: {0} ", validarCodigo);
            Console.WriteLine("Por favor, ingresa la cantidad del producto.");
            try
            {
                cantidadProducto = Convert.ToInt32(Console.ReadLine()?? "");
                Console.Clear();
            }
            catch (FormatException Fex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Solo se deben ingresar valores NUMÉRICOS");
                return;
            }

            validarCantidad = LeerCantidad(cantidadProducto);

            totalCantidad += cantidadProducto;

            while (validarCantidad >= 1)
            {


                Console.WriteLine("Por favor, ingresa el precio del producto - unidad -");
                try
                {
                    precio = Convert.ToDouble(Console.ReadLine()?? "");
                    Console.Clear();
                }
                catch (FormatException Fex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Solo se deben ingresar valores NUMÉRICOS");

                }

                validarPrecio = LeerPrecio(precio);

                if (validarPrecio <= 0)
                {
                    return; // Termina la ejecución del programa si el código no es válido.
                }

                guardarRegistro = RegistrarProducto(precio, cantidadProducto);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Producto registrado con éxito.");
                Console.WriteLine("");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("¿Deseas actualizar el precio del producto antes de su finalización? S/N");
                Console.WriteLine("Recuerda que el precio ingresado anteriormente se borrará y se asigna un nuevo.");
                opcionSalir = Console.ReadLine()?.ToUpper() == "S";
                Console.Clear();

                if (!opcionSalir)
                    {
                        break; // Sale del bucle si el usuario no desea actualizar el precio.
                }

            }

       
            guardarPromedio = promedioPrecio(precio, cantidadProducto);

            
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=== REPORTE FINAL ===");
                Console.WriteLine("Nombre del producto: {0} ", nombreProducto);
                Console.WriteLine("Código del producto: {0} ", codigoProducto);
                Console.WriteLine("Total de cantidad del producto: {0} ", totalCantidad);
                Console.WriteLine("Valor por unidad: $ {0} COP", precio);
                Console.WriteLine("Valor Total: $ {0} COP", guardarRegistro);
                Console.WriteLine("Promedio de Precio: $ {0} COP", guardarPromedio);
            
        }

        static int LeerCodigo(int validaCodigo)
        {
            int codigoProducto = validaCodigo; // Asigna el valor del código ingresado a la variable local para su validación. 

            if (codigoProducto <= 0 || codigoProducto >= 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: El código del producto debe estar en el rango permitido 1-99");
                Console.ResetColor();
                return 0; // Devuelve 0 para indicar que el código no es válido.
            }
            else
            {
                return validaCodigo; // Devuelve el código del producto si es válido, o 0 si no lo es.
            }
        }

        static int LeerCantidad(int validarCantidad)
        {
            int cantidadProducto = validarCantidad;


            if (cantidadProducto > 1)
            {
                return cantidadProducto;
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: La cantidad de los productos debenser número positivo");
                return 0;
            }
        }

        static double LeerPrecio(double validarPrecio)
        {
            double precio = validarPrecio;

            if (precio <= -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: El precio del producto debe ser un número positivo.");
                return 0;
            }
            return precio;

        }

        static double RegistrarProducto(double precio, int cantidadProducto)
        {
            double subtotal = 0;
            subtotal = precio * cantidadProducto;

            return subtotal;
        }

        static double promedioPrecio(double precio, int cantidadProducto)
        {
            double promedio = 0;
            promedio = precio / cantidadProducto;
            return promedio;
        }
    }
}
