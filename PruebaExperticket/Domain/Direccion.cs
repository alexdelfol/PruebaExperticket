namespace PruebaExperticket.Domain
{
	public class Direccion
	{
		public string Calle { get; set; }
		public int Numero { get; set; }
		public string InformacionAuxiliar { get; set; }
		public string Ciudad { get; set; }
		public int CodPostal { get; set; }
		public string Pais { get; set; }

		public Direccion()
		{
			
		}
		
		public Direccion(string calle, int numero, string informacionAuxliar, string ciudad, int codPostal, string pais)
		{
			Calle = calle;
			Numero = numero;
			InformacionAuxiliar = informacionAuxliar;
			Ciudad = ciudad;
			Pais = pais;
			CodPostal = codPostal;
		}
        
		override
		public string ToString()
        {
	        return Calle + ", " + Numero + ", " + (string.IsNullOrEmpty(InformacionAuxiliar) ? InformacionAuxiliar + ", " : "") + Ciudad + ", " + CodPostal + ", " + Pais;
		}
    }
}
