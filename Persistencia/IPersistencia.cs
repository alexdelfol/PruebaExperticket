using System;
using Modelo;

namespace Persistence
{
	public interface IPersistencia
	{
		public bool AnyadirCliente(Cliente cliente);
		public bool EliminarCliente(Cliente cliente);
		public bool ModificarCliente(Cliente cliente);
		public Cliente BuscarPorDNI(string DNI);
		public Cliente BuscarPorNombreApellidosYNacimiento(string nombre, string apellidos, DateTime nacimiento);
		public Cliente[] ObtenerArrayClientes();
	}
}
