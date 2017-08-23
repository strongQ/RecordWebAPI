using EF.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;

namespace Services.Controllers
{
    public class UserController:ODataController
    {
        EF.Data.EFDbContext db = new EF.Data.EFDbContext();
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All, MaxTop = 100, MaxSkip = 200, PageSize = 2, AllowedFunctions = AllowedFunctions.All)]
        public IQueryable<MyUser> Get()
        {
            return db.Users.AsQueryable() ;
        }
        // Get odata/Users
        [EnableQuery]
        public SingleResult<MyUser> Get([FromODataUri] int key)
        {
            return SingleResult.Create(db.Users.Where(user => user.ID == key));
        }
        /// <summary>
        /// 完整更新
        /// </summary>
        /// <param name="key"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Put([FromODataUri]int key, MyUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != user.ID)
            {
                return BadRequest();
            }
            db.Entry(user).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(user);
             
        }

        public async Task<IHttpActionResult> Post(MyUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return Created(user);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri]int key, Delta<MyUser> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            MyUser user = await db.Users.FindAsync(key);
            if (user == null) return NotFound();

            patch.Patch(user);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(key))
                {
                    return NotFound();
                }
                else throw;
            }
            return Updated(user);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri]int key)
        {
            MyUser user = await db.Users.FindAsync(key);
            if (user == null) return NotFound();
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
        private bool UserExists(int key)
        {
            return db.Users.Count(e => e.ID == key) > 0;
        }
    }
}