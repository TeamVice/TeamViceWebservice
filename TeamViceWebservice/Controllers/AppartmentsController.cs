using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TeamViceWebservice;

namespace TeamViceWebservice.Controllers
{
    public class AppartmentsController : ApiController
    {
        private TeamViceContext db = new TeamViceContext();

        // GET: api/Appartments
        public IQueryable<Appartment> GetAppartment()
        {
            return db.Appartment;
        }

        // GET: api/Appartments/5
        [ResponseType(typeof(Appartment))]
        public async Task<IHttpActionResult> GetAppartment(int id)
        {
            Appartment appartment = await db.Appartment.FindAsync(id);
            if (appartment == null)
            {
                return NotFound();
            }

            return Ok(appartment);
        }

        // PUT: api/Appartments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAppartment(int id, Appartment appartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appartment.AppartNo)
            {
                return BadRequest();
            }

            db.Entry(appartment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Appartments
        [ResponseType(typeof(Appartment))]
        public async Task<IHttpActionResult> PostAppartment(Appartment appartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Appartment.Add(appartment);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AppartmentExists(appartment.AppartNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = appartment.AppartNo }, appartment);
        }

        // DELETE: api/Appartments/5
        [ResponseType(typeof(Appartment))]
        public async Task<IHttpActionResult> DeleteAppartment(int id)
        {
            Appartment appartment = await db.Appartment.FindAsync(id);
            if (appartment == null)
            {
                return NotFound();
            }

            db.Appartment.Remove(appartment);
            await db.SaveChangesAsync();

            return Ok(appartment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppartmentExists(int id)
        {
            return db.Appartment.Count(e => e.AppartNo == id) > 0;
        }
    }
}