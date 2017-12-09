using MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using MazeLib;
using Newtonsoft.Json.Linq;
using WebAppMaze.Models;

namespace WebAppMaze.Controllers
{
    public class mazeController : ApiController
    {
        private static IModel maze_model = new MazeModel();
        private static Dictionary<Maze, string> mazes = new Dictionary<Maze, string>();

        // POST: api/maze
        [HttpPost]
        public string Solve(string name, int algo)
        {
            object obj = maze_model.Solve(name, algo);
            return JsonConvert.SerializeObject(obj);
        }

        // POST: api/maze
        [HttpPost]
        public string StartMaze(MazeBoard maze)
        {
            string name = maze.Name;
            int rows = maze.Rows;
            int cols = maze.Cols;

            Maze genMaze = maze_model.GenerateMaze(name, rows, cols);
            if (genMaze == null)
            {
                return null;
            }

            mazes.Add(genMaze, name);
            JObject obj = JObject.Parse(genMaze.ToJSON());
            return genMaze.ToJSON();
        }

        // PUT: api/maze/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/maze/5
        public void Delete(int id)
        {
        }
    }
}
