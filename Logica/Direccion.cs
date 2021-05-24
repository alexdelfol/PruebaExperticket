using System;

namespace Logica
{
	public class Direccion
	{
		private string calle;
		private int numero;
		private string informacionAuxiliar;
		private string ciudad;
		private int codPostal;
		private string pais;

		public string Calle { get => calle; set => calle = value; }
		public int Numero { get => numero; set => numero = value; }
		public string InformacionAuxiliar { get => informacionAuxiliar; set => informacionAuxiliar = value; }
		public string Ciudad { get => ciudad; set => ciudad = value; }
		public int CodPostal { get => codPostal; set => codPostal = value; }
		public string Pais { get => pais; set => pais = value; }

		
		public Direccion(string pCalle, int pNumero, string pAux, string pCiudad, int pCodPostal, string pPais)
		{
			calle = pCalle;
			numero = pNumero;
			informacionAuxiliar = pAux;
			ciudad = pCiudad;
			pais = pPais;
			codPostal = pCodPostal;
		}
        
		override
		public string ToString()
        {
			if (informacionAuxiliar == null)
            {
				return calle + ", " + numero + ", " + ciudad + ", " + codPostal + ", " + pais;

			}
            else
            {
				return calle + ", " + numero + ", " + informacionAuxiliar + ", " + ciudad + ", " + codPostal + ", " + pais;

			}
		}
    }
}
