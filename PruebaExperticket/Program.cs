using System;
using PruebaExperticket.Persistencia;

namespace PruebaExperticket
{
    class Program
    {
        private const string MENSAJE_BIENVENIDA = "¡Bienvenido al sistema de gestión de clientes!";
        private const string PREGUNTA_PRINCIPAL =   "¿Qué desea realizar (introduzca el número)?\n" +
                                                    "   1. Añadir un nuevo cliente.\n" +
                                                    "   2. Buscar un cliente.\n" +
                                                    "   3. Modificar un cliente.\n" +
                                                    "   4. Mostrar todos los clientes.\n" +
                                                    "   5. Eliminar un cliente.";
        private const string PREGUNTA_BUSQUEDA ="";
        private const string PREGUNTA_MODIFICACION ="";
        static void Main(string[] args)
        {
            IRepository miRepository = new ClienteDAL();

            Console.WriteLine(MENSAJE_BIENVENIDA);
            Console.WriteLine(PREGUNTA_PRINCIPAL);
        }
    }
}
