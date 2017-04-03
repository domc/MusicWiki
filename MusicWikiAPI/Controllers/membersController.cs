using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CRUDLibrary;
using MusicWikiAPI.Models;

namespace MusicWikiAPI.Controllers
{
    public class membersController : ApiController
    {
        private musicwikiEntities db = new musicwikiEntities();

        // GET: api/members
        [ResponseType(typeof(IEnumerable<BandMemberDTO>))]
        public IHttpActionResult Getmembers()
        {
            //Set up return model(list)
            var members = from b in db.members
                          select new BandMemberDTO()
                        {
                            id = b.id,
                            firstName = b.firstName,
                            lastName = b.lastName,
                            band=b.band.name                        
                        };

            return Ok(members);
        }

        // GET: api/members/5
        [ResponseType(typeof(BandMemberDetailDTO))]
        public IHttpActionResult Getmember(int id)
        {
            member memberLib = db.members.Find(id);
            if (memberLib == null)
            {
                return NotFound();
            }

            BandMemberDetailDTO member = new BandMemberDetailDTO
            {
                id= memberLib.id,
                firstName= memberLib.firstName,
                lastName= memberLib.lastName,
                role= memberLib.role,
                band=memberLib.band.name
            };

            return Ok(member);
        }

        // PUT: api/members/?bandid
        [ResponseType(typeof(void))]
        public IHttpActionResult Putmember(BandMemberEditDTO member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                member memberLib = db.members.Find(member.id);
                if (memberLib == null)
                {
                    return NotFound();
                }
                else
                {
                    //Pass potential changes from postedModel to db entry
                    memberLib.firstName = member.firstName;
                    memberLib.lastName = member.lastName;
                    memberLib.role = member.role;

                    //Change the members band
                    band band = db.bands.Find(member.bandID);
                    if (band != null)
                    {
                        memberLib.bandId = band.id;
                    }
                    else
                    {
                        return NotFound();
                    }

                    db.Entry(memberLib).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/members
        [ResponseType(typeof(BandMemberDetailDTO))]
        public IHttpActionResult Postmember(BandMemberCreateDTO member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //Check if the band exists
            band band = db.bands.Find(member.bandID);
            if (band == null)
            {
                return NotFound();
            }

            //Create DB entry from createModel
            member memberLib = new member {
                firstName = member.firstName,
                lastName = member.lastName,
                role=member.role,
                bandId=member.bandID                
            };

            db.members.Add(memberLib);
            db.SaveChanges();

            //Return model
            BandMemberDetailDTO memberReturn = new BandMemberDetailDTO
            {
                id= memberLib.id,
                firstName = memberLib.firstName,
                lastName = memberLib.lastName,
                role = memberLib.role,
                band = band.name
            };
            return CreatedAtRoute("DefaultApi", new { id = memberReturn.id }, memberReturn);
        }

        // DELETE: api/members/5
        [ResponseType(typeof(BandMemberDTO))]
        public IHttpActionResult Deletemember(int id)
        {
            member memberLib = db.members.Find(id);
            if (memberLib == null)
            {
                return NotFound();
            }

            //Return model
            BandMemberDTO member = new BandMemberDTO
            {
                id= memberLib.id,
                firstName = memberLib.firstName,
                lastName= memberLib.lastName
            };

            db.members.Remove(memberLib);
            db.SaveChanges();

            return Ok(member);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool memberExists(int id)
        {
            return db.members.Count(e => e.id == id) > 0;
        }
    }
}