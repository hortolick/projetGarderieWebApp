namespace projetGarderieWebApp.Models
{
    public class DepenseDTO
    {

        public string DateTemps { get; set; }

        public double Montant { get; set; }

        public double MontantAdmissible { get; set; }

        public CategorieDepenseDTO CategorieDepense { get; set; }

        public CommerceDTO Commerce { get; set; }

        public DepenseDTO(string dateTemps = "", double montant = 0, double montantAdmissible = 0, CategorieDepenseDTO categorieDepense=null, CommerceDTO commerce=null)
        {
            DateTemps = dateTemps;
            Montant = montant;
            MontantAdmissible = montantAdmissible;
            CategorieDepense = categorieDepense;
            Commerce=commerce;
        }

        public DepenseDTO() { }

    }
}
