namespace PracticaExtensionMethods
{
    public class Logic
    {
        public static void EsPar(int numero)
        {
            if (numero % 2 == 0)
            {

            }
            else
            {
                throw new NoEsParException();
            }
        }

        public static void DevolverMensaje(string mensajeUsuario)
        {
            throw new MensajeException(mensajeUsuario);
        }
    }
}
