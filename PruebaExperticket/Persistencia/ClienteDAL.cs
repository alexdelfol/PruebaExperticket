using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Linq;
using PruebaExperticket.Domain;

namespace PruebaExperticket.Persistencia
{
	public class ClienteDAL:DbContext,IRepository
	{
		public ClienteDAL(): base("ContextoCliente")
		{
		}

		public DbSet<Cliente> Clientes { get; set; }

        public bool AnyadirCliente(Cliente cliente)
        {
            try
            {
                Clientes.Add(cliente);
                return true;
            }
            catch (Exception e)
            {
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(e.Message);
                return false;
            }
        }

        public Cliente BuscarPorDni(string? dni)
        {
            Cliente result = Clientes.Find(dni);
            if (result == null) {
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine("No existe ese cliente");
            }
            return result;

        }

        public IEnumerable<Cliente> BuscarPorNombreApellidosONacimiento(string? nombre, string? apellidos, DateTime? nacimiento)
        {
            return Clientes.Where(cliente =>
                (nombre != null && cliente.Nombre == nombre)
                || (apellidos != null && cliente.Apellidos == apellidos)
                || (nacimiento != null && cliente.Nacimiento == nacimiento)
            );
        }

        public bool EliminarCliente(Cliente cliente)
        {
            try
            {
                Clientes.Remove(cliente);
                return true;
            }
            catch (Exception e)
            {
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(e.Message);
                return false;
            }
        }

        public bool ModificarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> ObtenerClientes()
        {
            return Clientes;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
