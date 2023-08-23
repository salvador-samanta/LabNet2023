using System;

namespace PracticaExtensionMethods
{
    public class Extensions
    {
        public static void DivisionPorCero(int numero)
        {
            int num = numero;
            int divideCero = num / 0;
        }

        public static float Division(float num1, float num2)
        {
            float dividendo = num1;
            float divisor = num2;

            float resultado = dividendo / divisor;
            return resultado;
        }

        public static float PedirNumero(string mensaje)
        {
            Console.WriteLine(mensaje);
            while (true)
            {
                if (float.TryParse(Console.ReadLine(), out float num))
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("Seguro ingresaste una letra o no ingresaste nada. ¡Ahora intentalo en serio! >:(");
                }
            }
        }

    }
}
