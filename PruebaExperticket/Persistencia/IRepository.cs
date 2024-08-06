using System;
using System.Collections.Generic;
using PruebaExperticket.Domain;

namespace PruebaExperticket.Persistencia
{
	public interface IRepository
	{
		public bool AnyadirCliente(Cliente cliente);
		public bool EliminarCliente(string dni);
		public bool ModificarCliente(string dni, Cliente cliente);
		public Cliente BuscarPorDni(string? dni);
		public IEnumerable<Cliente> BuscarPorNombreApellidosONacimiento(string? nombre, string? apellidos, DateTime? nacimiento);
		public IEnumerable<Cliente> ObtenerClientes();
	}
}
