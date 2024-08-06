using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaExperticket.Domain
{

	public class Cliente
	{
		public string Nombre { get; set; }
		public string Apellidos { get; set; }
		public Sexo Sexo { get; set; }
		public DateTime Nacimiento { get; set; }
		public Direccion Direccion { get; set; }

		[Key]
		public string DNI { get; set; }

		public Cliente() { }

		public Cliente(string nombre, string apellidos, Sexo sexo, DateTime nacimiento, Direccion direccion, string dni)
		{
			Nombre = nombre;
			Apellidos = apellidos;
			Sexo = sexo;
			Nacimiento = nacimiento;
			Direccion = direccion;
			DNI = dni;
		}


		override
        public string ToString()
        {
			return Nombre + " " + Apellidos + "con DNI " + DNI + ", " + Sexo.ToString() + " nacido el " + Nacimiento.ToShortDateString() + "con dirección en: " + Direccion + ".";
        }
    }
}
