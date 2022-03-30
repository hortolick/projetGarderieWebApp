using projetGarderieWebApp.Models;

namespace projetGarderieWebApp.DTOs
{
    public class GarderieDTO
	{
		#region Proprietes

		/// <summary>
		/// Nom de la garderie
		/// </summary>
		public string Nom { get; set; }

		/// <summary>
		/// Adresse de la garderie
		/// </summary>
		public string Adresse { get; set; }

		/// <summary>
		/// Ville de la garderie
		/// </summary>
		public string Ville { get; set; }

		/// <summary>
		/// Province de la garderie
		/// </summary>
		public string Province { get; set; }

		/// <summary>
		/// Telephone de la garderie
		/// </summary>
		public string Telephone { get; set; }

		#endregion Proprietes

		#region Constructeurs

		/// <summary>
		/// Constructeur avec parametres
		/// </summary>
		/// <param name="nom">Nom de la garderie</param>
		/// <param name="adresse">Adresse de la garderie</param>
		/// <param name="ville">Ville de la garderie</param>
		/// <param name="province">Province de la garderie</param>
		/// <param name="telephone">Telephone de la garderie</param>
		public GarderieDTO(string nom = "", string adresse = "", string ville = "", string province = "", string telephone = "")
		{
			Nom = nom;
			Adresse = adresse;
			Ville = ville;
			Province = province;
			Telephone = telephone;
		}

		/// <summary>
		/// Parameterless constructor
		/// </summary>
		public GarderieDTO() { }

		/// <summary>
		/// Constructeur avec modele
		/// </summary>
		/// <param name="garderie">Modele de la garderie</param>
		public GarderieDTO(Garderie garderie)
		{
			Nom = garderie.Nom;
			Adresse = garderie.Adresse;
			Ville = garderie.Ville;
			Province = garderie.Province;
			Telephone = garderie.Telephone;
		}

		#endregion Constructeurs


	}
}
