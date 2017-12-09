using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppMaze.Models;
namespace WebAppMaze.Controllers
{
    public class PlayersController : ApiController
    {
        private static List<Player> players = new List<Player>{
                new Player { UserName = "user1", Mail = "user1@gmail.com", Pass = "123" },
                new Player { UserName = "user2", Mail = "user2@gmail.com", Pass = "123" }
                };
        public IEnumerable<Player> GetAllPlayers()
        {
            return players;
        }
        public IHttpActionResult GetPlayer(string name)
        {
            Player pl = players.FirstOrDefault(p => p.UserName == name);
            if (pl == null)
            {
                return NotFound();
            }
            return Ok(pl);
        }
        [HttpPost]
        public void AddPlayer(Player p)
        {

            System.Console.WriteLine("{0}", p.UserName);
            players.Add(p);
        }
    }
}
