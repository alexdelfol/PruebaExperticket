using System;
using System.Collections;
using Modelo;
using System.IO;

namespace Persistence
{

	public class PersistenciaVolatil : Persistencia
	{

		private Hashtable clientes;

		public PersistenciaVolatil()
		{
			clientes = new Hashtable();
		}

		public bool AnyadirCliente(Cliente cliente)
        {
			try
			{
				clientes.Add(cliente.DNI, cliente);
				return true;
			} catch (Exception e)
			{
				TextWriter errorWriter = Console.Error;
				errorWriter.WriteLine(e.Message);
				return false;
            }
        }

		public bool EliminarCliente(Cliente cliente)
        {
			try
			{
				clientes.Remove(cliente.DNI);
				return true;
			} catch (Exception e)
            {
				TextWriter errorWriter = Console.Error;
				errorWriter.WriteLine(e.Message);
				return false;
            }
        }

		public Cliente BuscarPorDNI(string DNI)
        {
			if (clientes.ContainsKey(DNI))
			{
				return (Cliente)clientes[DNI];
			}
			TextWriter errorWriter = Console.Error;
			errorWriter.WriteLine("No existe ese cliente");
			return null;
        }

		public Cliente BuscarPorNombreApellidosYNacimiento(string nombre, string apellidos, DateTime nacimiento)
        {
			foreach(DictionaryEntry cliente in clientes)
            {
				Cliente result = (Cliente) cliente.Value;
				if (nombre == result.Nombre && apellidos == result.Apellidos && nacimiento.Equals(result.Nacimiento))
                {
					return result;
                }
            }
			TextWriter errorWriter = Console.Error;
			errorWriter.WriteLine("No existe ese cliente");
			return null;
		}

		public bool ModificarCliente(Cliente cliente)
        {
            try
            {
				clientes[cliente.DNI] = cliente;
				return true;
            }
            catch (Exception e)
            {
				TextWriter errorWriter = Console.Error;
				errorWriter.WriteLine(e.Message);
				return false;
            }
        }

		public Cliente[] ObtenerArrayClientes()
        {
			Cliente[] arrrayResult = new Cliente[clientes.Count];
			clientes.CopyTo(arrrayResult, 0);
			return arrrayResult;
        }
	}
}
