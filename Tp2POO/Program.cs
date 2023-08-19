using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;
            do
            {
                try
                {
                    int menuTransporte = 0;
                    Console.WriteLine("Elegí en qué transporte ingresar la cantidad de pasajeros:\n\n1 Taxi\n2 Omnibus\n3 Salir\n");
                    menuTransporte = Convert.ToInt32(Console.ReadLine());
                    switch (menuTransporte)
                    {
                        case (1):
                            Console.Clear();

                            Console.WriteLine("\nPerfecto, ahora ingresá 5 numeros de pasajeros de taxis:\n");

                            List<Taxi> taxis = IngresoTaxi(5);
                            Console.WriteLine("\nEstos son los pasajeros que viajaron:");
                            foreach (var i in taxis)
                            {
                                Console.WriteLine(i.Pasajeros());
                            }
                            Console.WriteLine("\n\nOprima algún botón para continuar.");
                            break;

                        case (2):
                            Console.Clear();

                            Console.WriteLine("\nPerfecto, ahora ingresá 5 numeros de pasajeros de omnibus:\n");

                            List<Omnibus> omnibus = IngresoOmnibus(5);
                            Console.WriteLine("\nEstos son los pasajeros que viajaron:");
                            foreach (var i in omnibus)
                            {
                                Console.WriteLine(i.Pasajeros());
                            }
                            Console.WriteLine("\n\nOprima algún botón para continuar.\n\n");
                            break;


                        case (3):
                            Console.Clear();

                            Console.WriteLine("Adiós!");
                            continuar = false;
                            break;



                        default:
                            Console.Clear();

                            Console.WriteLine("Ingresaste un carácter incorrecto");
                            break;
                    }
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.Write(ex.Message);
                }

                Console.Clear();
            } 
            while (continuar == true);
        }
        static List<Taxi> IngresoTaxi(int contador)
        {
            List<Taxi> taxis = new List<Taxi>();

            for (int i = 0; i < contador; i++)
            {
                Console.Write($"{ i + 1}° taxi:");
                int cantPasajeros = Convert.ToInt32(Console.ReadLine());
                if (cantPasajeros <= 4 && cantPasajeros>0)
                {
                    taxis.Add(new Taxi(cantPasajeros));
                }
                else if(cantPasajeros<0)
                {
                    Console.WriteLine("¡¡El taxi se negó a llevar pasajeros inexistentes y se fue vacío!!");
                    taxis.Add(new Taxi(0));
                }
                else
                {
                    Console.WriteLine("¡¡El taxi se negó a llevar tantos pasajeros y se fue vacío!!");
                    taxis.Add(new Taxi(0));
                }
            }
            return taxis;
        }
        static List<Omnibus> IngresoOmnibus(int contador)
        {
            List<Omnibus> omnibus = new List<Omnibus>();

            for (int i = 0; i < contador; i++)
            {
                Console.Write($"{ i + 1}° omnibus:");
                int cantPasajeros = Convert.ToInt32(Console.ReadLine());
                if (cantPasajeros <= 40 && cantPasajeros > 0)
                {
                    omnibus.Add(new Omnibus(cantPasajeros));
                }                
                else if (cantPasajeros < 0)
                {
                    Console.WriteLine("El omnibus no encontró a nadie en la parada y se fue vacío.");
                    omnibus.Add(new Omnibus(0));
                }
                else
                {
                    cantPasajeros = cantPasajeros-40;
                    Console.WriteLine($"¡¡{cantPasajeros} pasajeros no entraron en el ómnibus!!");
                    omnibus.Add(new Omnibus(40));
                }
            }
            return omnibus;
        }
    }
}
