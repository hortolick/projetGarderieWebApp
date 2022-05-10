
namespace projetGarderieWebApp.Models
{
    public class PresenceDTO
    {
        #region Attributs
        private string date;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        private string nomGarderie;

        public string NomGarderie
        {
            get { return nomGarderie; }
            set { nomGarderie = value; }
        }

        private EnfantDTO enfant;

        public EnfantDTO Enfant
        {
            get { return enfant; }
            set { enfant = value; }
        }

        private EducateurDTO educateur;

        public EducateurDTO Educateur
        {
            get { return educateur; }
            set { educateur = value; }
        }
        #endregion

        #region Constructeurs
        public PresenceDTO() { }
        public PresenceDTO(string date = "", string nomGarderie = "", EnfantDTO enfant = null, EducateurDTO educateur = null)
        {
            Date = date;
            NomGarderie = nomGarderie;
            Enfant = enfant;
            Educateur = educateur;
        }

        #endregion
    }
}