using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Odeljenje
    {
        public Guid Id { get; set; }

        public string Naziv { get; set; }
        public string SpecijalizacijaNaziv { get; set; }

        public int BrojKreveta { get; set; }

        public int BrojPacijenata { get; set; }

        public ICollection<AppUser> Osoblje {get; set; } 


        public ICollection<Pacijent>Pacijenti{get;set;}


     }
}
