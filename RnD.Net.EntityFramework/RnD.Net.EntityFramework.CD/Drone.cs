using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RnD.Net.EntityFramework.CD
{
    public class Drone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DroneConfiguration Configuration { get; set; }
    }
}
