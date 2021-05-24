using System;
using Logica;

namespace Persistence
{
	public interface Persistencia
	{
		public bool AnyadirCliente(Cliente cliente);
		public bool EliminarCliente(Cliente cliente);
		public bool ModificarCliente(Cliente cliente);
		public Cliente BuscarPorDNI(string DNI);
		public Cliente BuscarPorNombreApellidosYNacimiento(string nombre, string apellidos, DateTime nacimineto);
		public Cliente[] ObtenerArrayClientes();
	}
}
