﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace MVC
{
    public interface ICommand
    {
        string Execute(string[] args, TcpClient client = null);
    }
}
