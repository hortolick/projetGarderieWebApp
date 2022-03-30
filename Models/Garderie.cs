namespace projetGarderieWebApp.Models
{
    public class Garderie
    {

		private string nom;

		public string Nom
		{
			get { return nom; }
			set { nom = value; }
		}

		private string adresse;

		public string Adresse
		{
			get { return adresse; }
			set { adresse = value; }
		}

		private string ville;

		public string Ville
		{
			get { return ville; }
			set { ville = value; }
		}

		private string province;

		public string Province
		{
			get { return province; }
			set { province = value; }
		}

		private string telephone;

		public string Telephone
		{
			get { return telephone; }
			set { telephone = value; }
		}


		/// <summary>
		/// Constructeur avec parametres
		/// </summary>
		/// <param name="nom">Nom de la garderie</param>
		/// <param name="adresse">Adresse de la garderie</param>
		/// <param name="ville">Ville de la garderie</param>
		/// <param name="province">Province de la garderie</param>
		/// <param name="telephone">Telephone de la garderie</param>
		public Garderie(string nom="", string adresse="", string ville="", string province="", string telephone="")
        {
			Nom = nom;
			Adresse = adresse;
			Ville = ville;
			Province = province;
			Telephone = telephone;
        }
	}
}