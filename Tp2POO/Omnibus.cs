using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2POO
{
    public class Omnibus : Transporte
    {
        public Omnibus(int cantidadPasajeros) : base(cantidadPasajeros) { }
        public override string Pasajeros()
        {
            return string.Format($"Omnibus: {ObtenerCantidadPasajeros()}");            
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
