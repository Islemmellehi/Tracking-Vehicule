using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntitiesDLL.Entities
{
    public class Coordonnées
    {


        private float pat {  get; set; }
        private float lang {  get; set; }

        public Coordonnées(float pat, float lang)
        {
            this.pat = pat;
            this.lang = lang;
        }
    }
}
