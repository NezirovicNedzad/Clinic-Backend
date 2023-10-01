using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class NapomenaDto2
    {
        public Guid Id { get; set; }
        public string NezeljenoDejstvo { get; set; }
        public string Primedba { get; set; }
        public Guid IdKarton { get; set; }
        public string IdSestra { get; set; }
    }
}
