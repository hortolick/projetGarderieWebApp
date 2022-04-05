namespace projetGarderieWebApp.Models
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

		#endregion Constructeurs


	}
}
