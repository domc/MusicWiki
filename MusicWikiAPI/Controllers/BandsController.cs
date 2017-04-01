using CRUDLibrary;
using MusicWikiAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicWikiAPI.Controllers
{
    public class BandsController : ApiController
    {
        musicwikiEntities entities = new musicwikiEntities();

        // ..api/Bands
        public IQueryable<BandDTO> Get()
        {
            var bands = from b in entities.bands
                        select new BandDTO() {
                            id = b.id,
                            name = b.name
                        };

            return bands;
        }

        // ..api/Bands/0
        public BandDetailDTO Get(int id)
        {
            var band = entities.bands.Select(b =>
                       new BandDetailDTO()
                       {
                           id = b.id,
                           name = b.name,
                           country = b.country,
                           genre = b.genre,
                           formationDate = b.formationDate
                       }).SingleOrDefault(b => b.id == id);

            return band;
        }
    }
}
