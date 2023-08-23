using System;

namespace PracticaExtensionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int menu = 0;
            int salida = 0;

            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("\nIngresá el número de lo que quieras hacer:\n" +
                        "1. Dividir número por cero (sólo para valientes)\n" +
                        "2. ¡Calculadora de divisiones! (es menos aterrador... ¡a menos que rompas algo!)\n" +
                        "3. Descubrir si un número es par o impar.\n" +
                        "4. El programa repite alguna frase que ingreses, pasando por una excepción.\n" +
                        "5. Salir");

                    menu = Convert.ToInt32(Console.ReadLine());
                    switch (menu)
                    {
                        case 1:
                            try
                            {
                                int num = (int)Extensions.PedirNumero("Ingresá un número para ver qué sucede:");
                                Extensions.DivisionPorCero(num);
                            }
                            catch (DivideByZeroException)
                            {
                                Console.WriteLine("¡BUM! Hiciste explotar todo. ¿No sabías que ¡Solo Chuck Norris divide por cero!?");
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("¡Seguro ingresaste una letra o no ingresaste nada!");
                            }
                            finally
                            {
                                Console.WriteLine("Ha terminado la operación.");
                            }
                            break;

                        case 2:
                            try
                            {
                                float num1 = Extensions.PedirNumero("Ingresá un número que quieras dividir:");
                                float num2 = Extensions.PedirNumero("Perfecto, ahora ingresá el número por el cual querés dividirlo:");

                                if (num2 == 0)
                                {
                                    Console.WriteLine("¡¿Todavía no aprendiste a NO DIVIDIR POR CERO?! >:(");
                                }
                                else
                                {
                                    Console.WriteLine("Resultado: {0}", Extensions.Division(num1, num2));
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("¡Seguro ingresaste una letra o no ingresaste nada!");
                            }
                            finally
                            {
                                Console.WriteLine("Ha terminado la operación.");
                            }

                            break;

                        case 3:
                            try
                            {
                                Console.Write("Ingresá un número para saber si es par: ");
                                int numero = Convert.ToInt32(Console.ReadLine());
                                Logic.EsPar(numero);
                                Console.WriteLine("Es par!!");
                            }
                            catch (NoEsParException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;

                        case 4:
                            try
                            {
                                Console.Write("Ingrese un mensaje: ");
                                string mensajeUsuario = Console.ReadLine();
                                Logic.DevolverMensaje(mensajeUsuario);
                            }
                            catch (MensajeException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        case 5:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Ups!! parece que ingresaste una opción incorrecta!");
                            break;
                    }
                    if (salida == 0) { Console.Write("\nOprima cualquier tecla para continuar.\n"); }

                    Console.ReadKey();
                }

                catch (FormatException)
                {
                    Console.WriteLine("¡La respuesta tenía que ser sólo con números!");
                    Console.Write("\nOprima cualquier tecla.");
                    Console.ReadLine();
                }
            }
            while (salida == 0);
        }
    }
}