using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DataTypes
{
    class MainPlayerStats
    {
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Points { get; set; }
        public int CurrentExp { get; set; }
        public int ReqExp { get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
    }
}
