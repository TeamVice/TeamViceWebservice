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
    public class DepZipCodesController : ApiController
    {
        private TeamViceContext db = new TeamViceContext();

        // GET: api/DepZipCodes
        public IQueryable<DepZipCode> GetDepZipCode()
        {
            return db.DepZipCode;
        }

        // GET: api/DepZipCodes/5
        [ResponseType(typeof(DepZipCode))]
        public async Task<IHttpActionResult> GetDepZipCode(int id)
        {
            DepZipCode depZipCode = await db.DepZipCode.FindAsync(id);
            if (depZipCode == null)
            {
                return NotFound();
            }

            return Ok(depZipCode);
        }

        // PUT: api/DepZipCodes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDepZipCode(int id, DepZipCode depZipCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != depZipCode.DepZipCode1)
            {
                return BadRequest();
            }

            db.Entry(depZipCode).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepZipCodeExists(id))
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

        // POST: api/DepZipCodes
        [ResponseType(typeof(DepZipCode))]
        public async Task<IHttpActionResult> PostDepZipCode(DepZipCode depZipCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DepZipCode.Add(depZipCode);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DepZipCodeExists(depZipCode.DepZipCode1))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = depZipCode.DepZipCode1 }, depZipCode);
        }

        // DELETE: api/DepZipCodes/5
        [ResponseType(typeof(DepZipCode))]
        public async Task<IHttpActionResult> DeleteDepZipCode(int id)
        {
            DepZipCode depZipCode = await db.DepZipCode.FindAsync(id);
            if (depZipCode == null)
            {
                return NotFound();
            }

            db.DepZipCode.Remove(depZipCode);
            await db.SaveChangesAsync();

            return Ok(depZipCode);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepZipCodeExists(int id)
        {
            return db.DepZipCode.Count(e => e.DepZipCode1 == id) > 0;
        }
    }
}