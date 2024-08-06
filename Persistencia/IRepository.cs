using System;
using PruebaExperticket.Domain;

namespace PruebaExperticket.Persistencia
{
	public interface IRepository
	{
		public bool AnyadirCliente(Cliente cliente);
		public bool EliminarCliente(Cliente cliente);
		public bool ModificarCliente(Cliente cliente);
		public Cliente BuscarPorDNI(string dni);
		public Cliente BuscarPorNombreApellidosYNacimiento(string nombre, string apellidos, DateTime nacimiento);
		public Cliente[] ObtenerArrayClientes();
	}
}
