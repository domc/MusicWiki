using CRUDLibrary;
using MusicWikiAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicWikiAPI.Controllers
{
    public class BandsController : ApiController
    {
        musicwikiEntities entities = new musicwikiEntities();

        // GET
        // ..api/Bands
        public HttpResponseMessage Get()
        {
            var bands = from b in entities.bands
                        select new BandDTO() {
                            id = b.id,
                            name = b.name
                        };

            return Request.CreateResponse<IEnumerable<BandDTO>>(HttpStatusCode.OK, bands);
        }

        // GET
        // ..api/Bands/1
        public HttpResponseMessage Get(int id)
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
            if (band == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Vnos ne obstaja.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, band);
            }
        }

        // POST
        // ..api/Bands/
        public void Post(BandDetailDTO band)
        {
            band bandLib = new band
            {
                name = band.name,
                country = band.country,
                genre = band.genre,
                formationDate = band.formationDate
            };
            entities.bands.Add(bandLib);
            entities.SaveChanges();
        }

        // PUT
        // ..api/Bands/1
        public void Put(int id, BandDetailDTO band)
        {
            band bandLib = entities.bands.Find(id);
            bandLib.name = band.name;
            bandLib.country = band.country;
            bandLib.genre = band.genre;
            bandLib.formationDate = band.formationDate;

            entities.Entry(bandLib).State = EntityState.Modified;
            entities.SaveChanges();
        }

        // DELETE
        // ..api/Bands/1
        public void Delete(int id)
        {
            band bandLib = entities.bands.Find(id);
            entities.bands.Remove(bandLib);
            entities.SaveChanges();
        }
    }
}
