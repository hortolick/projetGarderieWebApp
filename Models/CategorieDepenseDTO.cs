using System;

namespace projetGarderieWebApp.Models
{
    public class CategorieDepenseDTO
    {
        public string Description { get; set; }

        public double Pourcentage { get; set; }

        public CategorieDepenseDTO(string description = "", double pourcentage = 0)
        {
            Description = description;
            Pourcentage = pourcentage;
        }

        public CategorieDepenseDTO() { }
    }
}
