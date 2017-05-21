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
    public class AssignmentsController : ApiController
    {
        private TeamViceContext db = new TeamViceContext();

        // GET: api/Assignments
        public IQueryable<Assignment> GetAssignment()
        {
            return db.Assignment;
        }

        // GET: api/Assignments/5
        [ResponseType(typeof(Assignment))]
        public async Task<IHttpActionResult> GetAssignment(int id)
        {
            Assignment assignment = await db.Assignment.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }

            return Ok(assignment);
        }

        // PUT: api/Assignments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAssignment(int id, Assignment assignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assignment.AssignId)
            {
                return BadRequest();
            }

            db.Entry(assignment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentExists(id))
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

        // POST: api/Assignments
        [ResponseType(typeof(Assignment))]
        public async Task<IHttpActionResult> PostAssignment(Assignment assignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Assignment.Add(assignment);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = assignment.AssignId }, assignment);
        }

        // DELETE: api/Assignments/5
        [ResponseType(typeof(Assignment))]
        public async Task<IHttpActionResult> DeleteAssignment(int id)
        {
            Assignment assignment = await db.Assignment.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }

            db.Assignment.Remove(assignment);
            await db.SaveChangesAsync();

            return Ok(assignment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssignmentExists(int id)
        {
            return db.Assignment.Count(e => e.AssignId == id) > 0;
        }
    }
}