
namespace projetGarderieWebApp.Models
{
    public class FinanceDTO
    {
        public string nomGarderie { get; set; }

        public string annee { get; set; }

        public double depense { get; set; }

        public double revenu { get; set; }

        public double profit { get; set; }

        public FinanceDTO(string nomGarderie, string annee, double depense, double revenu, double profit)
        {
            this.nomGarderie = nomGarderie;
            this.annee = annee;
            this.depense = depense;
            this.revenu = revenu;
            this.profit = profit;
        }

        public FinanceDTO() { }
    }
}
