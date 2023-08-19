using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2POO
{
    public class Taxi : Transporte
    {
        public Taxi(int cantidadPasajeros) : base(cantidadPasajeros) { }
        public override string Pasajeros()
        {
            return string.Format($"Taxi: {ObtenerCantidadPasajeros()}");
        }
        public override string Avanzar()
        {
            throw new NotImplementedException();
        }
        public override string Detenerse()
        {
            throw new NotImplementedException();
        }
    }
}
