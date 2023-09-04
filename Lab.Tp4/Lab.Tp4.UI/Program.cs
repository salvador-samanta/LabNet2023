using Lab.Tp4.Data;
using Lab.Tp4.Logic;
using System;

namespace Lab.Tp4.UI
{
    internal class Program : BaseLogic
    {
        static void Main(string[] args)
        {
            
            int salida = 0;


            try
            {

                do
                {
                    int menu = 0;
                    Console.WriteLine("\nIngresá el número de lo que quieras ejecutar:\r\n\n" +
                        "\"1.  Query para devolver objeto customer\r\n" +
                        "\"2.  Query para devolver todos los productos sin stock\r\n" +
                        "\"3.  Query para devolver todos los productos que tienen stock y que cuestan más de 3 por\r\nunidad\r\n" +
                        "\"4.  Query para devolver todos los customers de la Región WA\r\n" +
                        "\"5.  Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789\r\n" +
                        "\"6.  Query para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula.\r\n" +
                        "\"7.  Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1/1/1997.\r\n" +
                        "\"8.  Query para devolver los primeros 3 Customers de la  Región WA\r\n" +
                        "\"9.  Query para devolver lista de productos ordenados por nombre.\r\n" +
                        "\"10. Query para devolver lista de productos ordenados por unit in stock de mayor a menor.\r\n" +
                        "\"11. Query para devolver las distintas categorías asociadas a los productos.\r\n" +
                        "\"12. Query para devolver el primer elemento de una lista de productos..\r\n" +
                        "\"13. Query para devolver los customer con la cantidad de ordenes asociadas");

                    menu = int.Parse(Console.ReadLine());
                    Model model = new Model();

                    switch (menu)
                    {
                        case 1:
                            model.Customers();
                            break;

                        case 2:
                            model.ProductsWithoutStock();
                            break;

                        case 3:
                            model.ProductsMoreThan3();
                            break;

                        case 4:
                            model.AllWACustomers();
                            break;

                        case 5:
                            model.ProductId789();
                            break;

                        case 6:
                            model.CustomersNames();
                            break;

                        case 7:
                            model.OrderAndCustomer();
                            break;

                        case 8:
                            model.FirstThreeCustomersWA();
                            break;

                        case 9:
                            model.OrderedByNameProducts();
                            break;

                        case 10:
                            model.OrderedByStockProducts();
                            break;

                        case 11:
                            model.ProductsCategories();
                            break;

                        case 12:
                            model.FirstProductOfTheList();
                            break;

                        case 13:
                            model.CustomersWithOrderCounts();
                            break;
                        
                        case 14:
                            salida = 1;
                            break;

                        default:
                            Console.WriteLine("Ingresaste una opción incorrecta!\n\n");
                            break;
                    }
                }
                while (salida == 0);
                {
                    Console.WriteLine("Gracias por corregir :D");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("¡La respuesta tenía que ser sólo con números!");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Ocurrió un error en la operación.\nDetalles: {ex.Message}");
            }

            Console.Read();


        }
    }
}

