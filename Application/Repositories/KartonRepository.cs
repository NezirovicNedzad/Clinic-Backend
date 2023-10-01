using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Application.Dto;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Persistence;

namespace Application.Repositories
{
    public class KartonRepository : IKartonRepository
    {
          

private readonly DataContext _context;

        public KartonRepository(DataContext context)
        {
            _context = context;
           
        }

        public async Task CreateKarton(Karton karton)
        { await _context.Kartoni.AddAsync(karton);
        }

        public async Task<List<KartonDtoIstorija>> GetKartoniPacijenta(Guid IdPacijenta)
        {

Pacijent p=await _context.Pacijenti.FindAsync(IdPacijenta);

List<KartonDtoIstorija> kartoniPacijenta=await _context.Kartoni.Where(x=>x.Pacijent.Equals(p)).Select(x=>new KartonDtoIstorija{IdK=x.Id,IdPacijenta=x.Pacijent.Id,IdOdeljenja=x.Odeljenje.Id,NazivOdeljenja=x.Odeljenje.Naziv,ImeLekara=x.Lekar.Ime,PrezimeLekara=x.Lekar.Prezime}).ToListAsync();

        return kartoniPacijenta;
        
        }

        public async Task<KartonDto> GetKartonPacijenta(Guid idP, Guid idO)
        {
            Odeljenje odeljenje=await _context.Odeljenja.FindAsync(idO);
            Pacijent P=await _context.Pacijenti.FindAsync(idP);


var k= await _context.Kartoni.Where(k =>k.Pacijent==P && k.Odeljenje==odeljenje).Select(n=>new{Id=n.Id,Dijagnoza=n.Dijagnoza,Terapija=n.Terapija,Lekar=n.Lekar}).FirstAsync();
LekarDto lekar=new LekarDto{Id=k.Lekar.Id,Ime=k.Lekar.Ime,Prezime=k.Lekar.Prezime};
var Pregledi=await _context.Pregledi.Where(pregled=>pregled.Karton.Id==k.Id).Select(s=>new PregledDto2{Id=s.Id,Dijagnoza=s.Dijagnoza,VremePregleda=s.VremePregleda,Anamneza=s.Anamneza,Terapija=s.Terapija,Lekar=new LekarDto{Id=s.Lekar.Id,Ime=s.Lekar.Ime,Prezime=s.Lekar.Prezime}}).ToListAsync();
KartonDto kartonDto= new KartonDto{
    
    Id=k.Id,
    Dijagnoza=k.Dijagnoza,
    Terapija=k.Terapija,
    Pregledi=Pregledi,
    Lekar=lekar
    };

return kartonDto;
        }

       
    }
}
