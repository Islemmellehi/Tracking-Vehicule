using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntitiesDLL.Entities
{
    public class Vehicule
    {
        

        public string matricule { get; set; }
        public string conducteur { get; set; }
        public string model { get; set; }
        public string couleur { get; set; }

        public Vehicule(string matricule)
        {
            this.matricule = matricule;
            
        }

    }
}
