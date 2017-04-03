﻿using CRUDLibrary;
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
                return Request.CreateResponse(HttpStatusCode.NotFound, "Band not found in our DB.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, band);
            }
        }

        // POST
        // ..api/Bands/
        public HttpResponseMessage Post(BandDetailDTO band)
        {
            if (ModelState.IsValid)
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

                band.id = bandLib.id;
                return Request.CreateResponse(HttpStatusCode.Created, band);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // PUT
        // ..api/Bands/1
        public HttpResponseMessage Put(BandDetailDTO band)
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

                    return Request.CreateResponse(HttpStatusCode.OK, band);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Band not found in our DB.");
                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE
        // ..api/Bands/1
        public HttpResponseMessage Delete(int id)
        {
            band bandLib = entities.bands.Find(id);
            if (bandLib != null)
            {
                entities.bands.Remove(bandLib);
                entities.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, bandLib);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Band not found in our DB.");
            }
        }
    }
}
