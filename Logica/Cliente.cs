using System;
namespace Logica
{

	public class Cliente
	{
		private string nombre;
		private string apellidos;
		private Sexo sexo;
		private DateTime nacimiento;
		private Direccion direccion;
		private readonly string dni;

		public string Nombre { get => nombre; set => nombre = value; }
		public string Apellidos { get => apellidos; set => apellidos = value; }
		public Sexo Sexo { get => sexo; set => sexo = value; }
		public DateTime Nacimiento { get => nacimiento; set => nacimiento = value; }
		public Direccion Direccion { get => direccion; set => direccion = value; }
		public string DNI { get => dni; }

		public Cliente(string pNombre, string pApellidos, Sexo pSexo, DateTime pNacimiento, Direccion pDireccion, string pDNI)
		{
			nombre = pNombre;
			apellidos = pApellidos;
			sexo = pSexo;
			nacimiento = pNacimiento;
			direccion = pDireccion;
			dni = pDNI;
		}

		override
        public string ToString()
        {
			return nombre + " " + apellidos + "con DNI " + dni + ", " + sexo.ToString() + " nacido el " + nacimiento.ToShortDateString() + "con dirección en: " + direccion + ".";
        }
    }
}
