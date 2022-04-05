namespace projetGarderieWebApp.Models
{
    public class DepenseDTO
    {
        public string DateTemps { get; set; }

        public double Montant { get; set; }

        public double MontantAdmissible { get; set; }

        public DepenseDTO(string dateTemps = "", double montant = 0, double montantAdmissible = 0)
        {
            DateTemps = dateTemps;
            Montant = montant;
            MontantAdmissible = montantAdmissible;
        }

        public DepenseDTO() { }

    }
}
