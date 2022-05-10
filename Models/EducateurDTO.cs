namespace projetGarderieWebApp.Models
{
    public class EducateurDTO : PersonneDTO
    {
        public EducateurDTO() { }
        public EducateurDTO(string nom = "", string prenom = "", string dateNaissance = "", string adresse = "", string ville = "", string province = "", string telephone = "")
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
