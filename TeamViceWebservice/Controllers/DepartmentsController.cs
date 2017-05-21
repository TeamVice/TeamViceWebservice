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
    public class DepartmentsController : ApiController
    {
        private TeamViceContext db = new TeamViceContext();

        // GET: api/Departments
        public IQueryable<Department> GetDepartment()
        {
            return db.Department;
        }

        // GET: api/Departments/5
        [ResponseType(typeof(Department))]
        public async Task<IHttpActionResult> GetDepartment(int id)
        {
            Department department = await db.Department.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        // PUT: api/Departments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDepartment(int id, Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != department.DepId)
            {
                return BadRequest();
            }

            db.Entry(department).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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

        // POST: api/Departments
        [ResponseType(typeof(Department))]
        public async Task<IHttpActionResult> PostDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Department.Add(department);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = department.DepId }, department);
        }

        // DELETE: api/Departments/5
        [ResponseType(typeof(Department))]
        public async Task<IHttpActionResult> DeleteDepartment(int id)
        {
            Department department = await db.Department.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            db.Department.Remove(department);
            await db.SaveChangesAsync();

            return Ok(department);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartmentExists(int id)
        {
            return db.Department.Count(e => e.DepId == id) > 0;
        }
    }
}