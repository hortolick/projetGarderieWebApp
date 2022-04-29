using projetGarderieAPIv2.Models;

namespace projetGarderieAPIv2.DTOs
{
    public class PersonneDTO
    {
        #region Attributs
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string DateNaissance { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Province { get; set; }
        public string Telephone { get; set; }
        #endregion

        #region Constructeurs
        public PersonneDTO() { }

        public PersonneDTO(string nom = "", string prenom = "", string dateNaissance = "", string adresse = "", string ville = "", string province = "", string telephone = "")
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            Adresse = adresse;
            Ville = ville;
            Province = province;
            Telephone = telephone;
        }

        public PersonneDTO(Personne personne)
        {
            Nom = personne.Nom;
            Prenom=personne.Prenom;
            DateNaissance=personne.DateNaissance;
            Adresse=personne.Adresse;
            Ville=personne.Ville;
            Province=personne.Province;
            Telephone=personne.Telephone;
        }
        #endregion
    }
}
