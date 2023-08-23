using System;

namespace PracticaExtensionMethods
{
    public class NoEsParException : Exception
    {
        public NoEsParException() : base("No es par.") { }
    }


}
