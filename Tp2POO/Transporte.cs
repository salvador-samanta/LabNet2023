using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2POO
{
    public abstract class Transporte
    {
        public int CantidadPasajeros;
        public int ObtenerCantidadPasajeros()
        {
            return CantidadPasajeros;
        }
        public Transporte(int cantidadPasajeros)
        {
            this.CantidadPasajeros = cantidadPasajeros;
        }
        public abstract string Avanzar();
        public abstract string Detenerse();
        public abstract string Pasajeros();
    }
}
