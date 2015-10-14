using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartHouseDll;

namespace SmartHouseMVC.Models
{
    public class WebReader : Storage, IReader
    {
        public WebReader(House home) : base(home)
        {
        }

        public void Read()
        {
            
        }

        public void Help(RemoteControl remote, string message)
        {
            
        }
    }
}