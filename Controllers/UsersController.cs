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
using WebAppMaze.Models;

namespace WebAppMaze.Controllers
{
    public class UsersController : ApiController
    {
        private WebAppMazeContext db = new WebAppMazeContext();

        // GET: api/Users
        public IQueryable<Player> GetPlayers()
        {
            return db.Players;
        }

        // GET: api/Users/5
        //[ResponseType(typeof(Player))]
        public string GetPlayer(string name, string pass)
        {
            Player player = db.Players.Find(name);

            if (player != null)
            {
                if (player.Pass == pass)
                {
                    return "Success";
                }
            }

            //return NotFound();
            return "Not Register";
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlayer(string name, Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (name != player.UserName)
            {
                return BadRequest();
            }

            db.Entry(player).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(name))
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

        // POST: api/Users
        [ResponseType(typeof(Player))]
        public string PostPlayer(Player player)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return "Error Register";
            }

            if (PlayerExists(player.UserName))
            {
                return "IsExist";
            }

            db.Players.Add(player);
            db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = player.Id }, player);
            return "Success";
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(Player))]
        public IHttpActionResult DeletePlayer(int id)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }

            db.Players.Remove(player);
            db.SaveChanges();

            return Ok(player);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlayerExists(string name)
        {
            return db.Players.Count(e => e.UserName == name) > 0;
        }
    }
}