using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PruebaExperticket.Domain;

namespace PruebaExperticket.Persistencia
{

	public class RepositoryVolatil : IRepository
	{

		private Hashtable clientes;

		public RepositoryVolatil()
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

		public bool EliminarCliente(string dni)
        {
			try
			{
				clientes.Remove(dni);
				return true;
			} catch (Exception e)
            {
				TextWriter errorWriter = Console.Error;
				errorWriter.WriteLine(e.Message);
				return false;
            }
        }

		public Cliente BuscarPorDni(string? dni)
        {
			if (dni is not null && clientes.ContainsKey(dni))
			{
				return (Cliente)clientes[dni];
			}
			TextWriter errorWriter = Console.Error;
			errorWriter.WriteLine("No existe ese cliente");
			return null;
        }

		public IEnumerable<Cliente> BuscarPorNombreApellidosONacimiento(string? nombre, string? apellidos, DateTime? nacimiento)
		{
			var clientesResult = ((IEnumerable<Cliente>)clientes.Values).Where(cliente =>
				(nombre is not null && cliente.Nombre == nombre)
				|| (apellidos is not null && cliente.Apellidos == apellidos)
				|| (nacimiento is not null && cliente.Nacimiento == nacimiento)
				);
			return clientesResult;
		}

		public bool ModificarCliente(string dni, Cliente cliente)
        {
            try
            {
				clientes[dni] = cliente;
				return true;
            }
            catch (Exception e)
            {
				TextWriter errorWriter = Console.Error;
				errorWriter.WriteLine(e.Message);
				return false;
            }
        }

		public IEnumerable<Cliente> ObtenerClientes()
		{
			return (IEnumerable<Cliente>)clientes.Values;
		}
	}
}
