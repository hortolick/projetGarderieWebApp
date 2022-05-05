namespace projetGarderieWebApp.Models
{
    public class EnfantDTO : PersonneDTO
    {
        public EnfantDTO() { }
        public EnfantDTO(string nom = "", string prenom = "", string dateNaissance = "", string adresse = "", string ville = "", string province = "", string telephone = "")
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            Adresse = adresse;
            Ville = ville;
            Province = province;
            Telephone = telephone;
        }
    }
}
