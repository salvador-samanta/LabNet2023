using System;

namespace PracticaExtensionMethods
{
    internal class MensajeException : Exception
    {
        public MensajeException(string mensaje) : base($"Escribiste: '{mensaje}'")
        {
        }
        public override string Message
        {
            get
            {
                return "Excepción de tipo personalizada.\n" + base.Message;
            }
        }
    }
}
