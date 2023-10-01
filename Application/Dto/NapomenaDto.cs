using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class NapomenaDto
    {
        public Guid Id { get; set; }
        public string NezeljenoDejstvo { get; set; }
        public string Primedba { get; set; }
        public SestraDto Sestra { get; set; }
    }
}
