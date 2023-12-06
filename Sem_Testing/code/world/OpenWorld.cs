using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_Testing.code.world
{
    public class OpenWorld
    {
        private Dictionary<String,Encounter> encounters;

        public OpenWorld()
        {
            encounters = new Dictionary<string, Encounter>();
            // Filling up the list by hand, the world is custom-made
            encounters.Add("E0", new Encounter(enums.ENCOUNTER_TYPES.REGULAR, new List<String> {"E1","E2" }));
            encounters.Add("E1", new Encounter(enums.ENCOUNTER_TYPES.OPTIONAL, new List<String>())); 
            encounters.Add("E2", new Encounter(enums.ENCOUNTER_TYPES.REGULAR, new List<String> {"E3", "E6"}));
            encounters.Add("E3", new Encounter(enums.ENCOUNTER_TYPES.REGULAR, new List<String> {"E4", "E5"})); 
            encounters.Add("E4", new Encounter(enums.ENCOUNTER_TYPES.OPTIONAL, new List<String>()));
            encounters.Add("E5", new Encounter(enums.ENCOUNTER_TYPES.REGULAR, new List<String> {"E8"})); 
            encounters.Add("E6", new Encounter(enums.ENCOUNTER_TYPES.REGULAR, new List<String> {"E7"})); 
            encounters.Add("E7", new Encounter(enums.ENCOUNTER_TYPES.REGULAR, new List<String> {"E8"})); 
            encounters.Add("E8", new Encounter(enums.ENCOUNTER_TYPES.BOSS, new List<String>()));
            // Fill neigbouring encounters

        }

        public List<String> Neigbours(String Encounter)
        {
            return encounters[Encounter].Neigbours();
        }

        public Dictionary<String, Encounter> Encounters()
        {
            return encounters;
        }

    }
}
