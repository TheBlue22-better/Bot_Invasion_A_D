using Sem_Testing.code.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_Testing.code.world
{
    public class Encounter
    {
        ENCOUNTER_TYPES enType;
        List<String> neigbours;

        public Encounter(ENCOUNTER_TYPES type, List<String> neigbour)
        {
            this.enType = type;
            this.neigbours = neigbour;

        }

        public List<String> Neigbours()
        {
            return neigbours;
        }



    }
}
