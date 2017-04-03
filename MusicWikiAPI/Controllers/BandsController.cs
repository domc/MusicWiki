using CRUDLibrary;
using MusicWikiAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace MusicWikiAPI.Controllers
{
    public class BandsController : ApiController
    {
        musicwikiEntities entities = new musicwikiEntities();

        // GET
        // ..api/Bands
        [ResponseType(typeof(IEnumerable<BandDTO>))]
        public IHttpActionResult Get()
        {
            var bands = from b in entities.bands
                        select new BandDTO() {
                            id = b.id,
                            name = b.name
                        };

            return Ok(bands);  // ==Request.CreateResponse<IEnumerable<BandDTO>>(HttpStatusCode.OK, bands);
        }

        // GET
        // ..api/Bands/1
        [ResponseType(typeof(BandDetailDTO))]
        public IHttpActionResult Get(int id)
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
                return NotFound();
            }
            else
            {
                return Ok(band);
            }
        }

        // POST
        // ..api/Bands/
        [ResponseType(typeof(BandDetailDTO))]
        public IHttpActionResult Post(BandCreateDTO bandPost)
        {
            if (ModelState.IsValid)
            {
                //Create enty in DB
                band bandLib = new band
                {
                    name = bandPost.name,
                    country = bandPost.country,
                    genre = bandPost.genre,
                    formationDate = bandPost.formationDate
                };
                entities.bands.Add(bandLib);
                entities.SaveChanges();

                //Set up return model
                BandDetailDTO band = new BandDetailDTO
                {
                    name = bandLib.name,
                    country = bandLib.country,
                    genre = bandLib.genre,
                    formationDate = bandLib.formationDate,
                    id = bandLib.id
                };

                //Return status created + new path(Location)
                return CreatedAtRoute("DefaultApi", new { id = band.id }, band );
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT
        // ..api/Bands
        [ResponseType(typeof(BandDetailDTO))]
        public IHttpActionResult Put(BandDetailDTO band)
        {
            if (ModelState.IsValid)
            {
                band bandLib = entities.bands.Find(band.id);
                if (bandLib != null)
                {
                    bandLib.name = band.name;
                    bandLib.country = band.country;
                    bandLib.genre = band.genre;
                    bandLib.formationDate = band.formationDate;

                    entities.Entry(bandLib).State = EntityState.Modified;
                    entities.SaveChanges();

                    return Ok(band);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE
        // ..api/Bands/1
        [ResponseType(typeof(BandDTO))]
        public IHttpActionResult Delete(int id)
        {
            band bandLib = entities.bands.Find(id);
            if (bandLib != null)
            {
                var band = new BandDTO()
                {
                    id = bandLib.id,
                    name = bandLib.name
                };

                entities.bands.Remove(bandLib);
                entities.SaveChanges();

                return Ok(band);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
