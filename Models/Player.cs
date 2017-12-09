using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMaze.Models
{
    public class Player
    {
        [Key]
        public string UserName { get; set; }
        [Required]
        public string Pass { get; set; }
        [Required]
        public string Mail { get; set; }
    }
}