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
using System.Web.OData.Routing;

namespace Services.Controllers
{
    public class UsersController:ODataController
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
        /// http://localhost:55509/OData/Users/UserService.GetMaxID  41?
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetMaxID()
        {

            var result = db.Users.Max(x => x.ID);
            return Ok(result);

            
        }
        [HttpGet]
        public IHttpActionResult GetMaxName()
        {

            var result = db.Users.First().UserName;
            Module a = new Module { MName = "xx", ID = 4, IP = "343" };
            string b=Newtonsoft.Json.JsonConvert.SerializeObject(a);
            return Ok(b);


        }
        /// <summary>
        /// http://localhost:55509/Odata/GetSome(ID=10)
        /// 
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        [ODataRoute("GetSome(ID={ID})")]
        public IHttpActionResult GetSome([FromODataUri]int ID)
        {
            double a = ID;
            return Ok(a);
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