using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2POO
{
    public abstract class TransportePublico
    {
        private int CantidadPasajeros;
        public int GetCantidadPasajeros()
        {
            return CantidadPasajeros;
        }
        public TransportePublico(int cantidadPasajeros)
        {
            this.CantidadPasajeros = cantidadPasajeros;
        }
        public abstract string Avanzar();
        public abstract string Detenerse();
        public abstract string pasajeros();
    }
}
