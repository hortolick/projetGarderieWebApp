namespace projetGarderieWebApp.Models
{
    public class CommerceDTO
    {
        public string Description { get; set; }

        public string Adresse { get; set; }

        public string Telephone { get; set; }

        public CommerceDTO(string description = "", string adresse = "", string telephone = "")
        {
            Description = description;
            Adresse = adresse;
            Telephone = telephone;
        }

        public CommerceDTO() { }
    }
}
