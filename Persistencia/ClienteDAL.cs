using System;
using Modelo;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Collections;

namespace Persistence
{
	public class ClienteDAL:DbContext,IPersistencia
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

        public Cliente BuscarPorDNI(string DNI)
        {
            Cliente result = Clientes.Find(DNI);
            if (result == null) {
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine("No existe ese cliente");
            }
            return result;

        }

        public Cliente BuscarPorNombreApellidosYNacimiento(string nombre, string apellidos, DateTime nacimiento)
        {
            foreach (Cliente cliente in Clientes.ToListAsync().Result)
            {
                if (nombre == cliente.Nombre && apellidos == cliente.Apellidos && nacimiento.Equals(cliente.Nacimiento))
                {
                    return cliente;
                }
            }
            TextWriter errorWriter = Console.Error;
            errorWriter.WriteLine("No existe ese cliente");
            return null;
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

        public Cliente[] ObtenerArrayClientes()
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
