using Bot_Invasion_A_D.code.entities;
using Bot_Invasion_A_D.code.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Invasion_A_D.code.world
{
    public class OpenWorld
    {
        private Dictionary<String,Encounter> encounters;
        private Player player;
        public OpenWorld(DIFFICULTY diff)
        {
            encounters = new Dictionary<String,Encounter>();
            player = new Player("Steve");
            FillEncounter(diff);
        }

        public Player GetPlayer() { return player; }

        public List<String> Neigbours(String Encounter)
        {
            return encounters[Encounter].GetNeigbours();
        }

        public Dictionary<String, Encounter> Encounters()
        {
            return encounters;
        }

        private void FillEncounter(DIFFICULTY diff)
        {
            Dictionary<string, Encounter>  filledEnc = new Dictionary<string, Encounter>();
            
            if (diff == DIFFICULTY.EASY)
            {
                
            }
            else if (diff == DIFFICULTY.MEDIUM)
            {
                encounters.Add("E1", new Encounter(ENCOUNTER_TYPE.REGULAR,DIFFICULTY.EASY, new List<String> { "E2" }));
                encounters.Add("E2", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.EASY, new List<String> { "E3", "E4" }));
                encounters.Add("E3", new Encounter(ENCOUNTER_TYPE.OPTIONAL, DIFFICULTY.EASY, new List<String> {  }));
                encounters.Add("E4", new Encounter(ENCOUNTER_TYPE.REGULAR,DIFFICULTY.MEDIUM, new List<String> { "E5", "E10" }));
                encounters.Add("E5", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.MEDIUM, new List<String> { "E6" }));
                encounters.Add("E6", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.MEDIUM, new List<String> { "E7" }));
                encounters.Add("E7", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.MEDIUM, new List<String> { "E8" }));
                encounters.Add("E8", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.HARD, new List<String> { "E9" }));
                encounters.Add("E9", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.MEDIUM, new List<String> { "E23" }));
                encounters.Add("E10", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.EASY, new List<String> { "E11" }));
                encounters.Add("E11", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.EASY, new List<String> { "E12" }));
                encounters.Add("E12", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.EASY, new List<String> { "E13" }));
                encounters.Add("E13", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.MEDIUM, new List<String> { "E14" }));
                encounters.Add("E14", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.MEDIUM, new List<String> { "E15", "E20" }));
                encounters.Add("E15", new Encounter(ENCOUNTER_TYPE.OPTIONAL, DIFFICULTY.EASY, new List<String> { "E16"}));
                encounters.Add("E16", new Encounter(ENCOUNTER_TYPE.OPTIONAL, DIFFICULTY.EASY, new List<String> { "E17" }));
                encounters.Add("E17", new Encounter(ENCOUNTER_TYPE.OPTIONAL, DIFFICULTY.MEDIUM, new List<String> { "E18" }));
                encounters.Add("E18", new Encounter(ENCOUNTER_TYPE.OPTIONAL, DIFFICULTY.MEDIUM, new List<String> { "E19" }));
                encounters.Add("E19", new Encounter(ENCOUNTER_TYPE.OPTIONAL, DIFFICULTY.HARD, new List<String> {  }));
                encounters.Add("E20", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.MEDIUM, new List<String> { "E21" }));
                encounters.Add("E21", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.EASY, new List<String> { "E22" }));
                encounters.Add("E22", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.EASY, new List<String> { "E23" }));
                encounters.Add("E23", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.EASY, new List<String> { "E24" })); //we cannot go back.
                encounters.Add("E24", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.MEDIUM, new List<String> { "E27", "E25" }));
                encounters.Add("E25", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.MEDIUM, new List<String> { "E26" }));
                encounters.Add("E26", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.MEDIUM, new List<String> { "E40" }));
                encounters.Add("E27", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.EASY, new List<String> { "E28", "E36" }));
                encounters.Add("E28", new Encounter(ENCOUNTER_TYPE.OPTIONAL, DIFFICULTY.EASY, new List<String> { "E29" }));
                encounters.Add("E29", new Encounter(ENCOUNTER_TYPE.OPTIONAL, DIFFICULTY.EASY, new List<String> { "E30" }));
                encounters.Add("E30", new Encounter(ENCOUNTER_TYPE.OPTIONAL, DIFFICULTY.MEDIUM, new List<String> { "E31" }));
                encounters.Add("E31", new Encounter(ENCOUNTER_TYPE.OPTIONAL, DIFFICULTY.MEDIUM, new List<String> { "E32" }));
                encounters.Add("E32", new Encounter(ENCOUNTER_TYPE.OPTIONAL, DIFFICULTY.MEDIUM, new List<String> { "E33" }));
                encounters.Add("E33", new Encounter(ENCOUNTER_TYPE.OPTIONAL, DIFFICULTY.MEDIUM, new List<String> { "E34" }));
                encounters.Add("E34", new Encounter(ENCOUNTER_TYPE.OPTIONAL, DIFFICULTY.MEDIUM, new List<String> { "E35" }));
                encounters.Add("E35", new Encounter(ENCOUNTER_TYPE.OPTIONAL, DIFFICULTY.HARD, new List<String> {  }));
                encounters.Add("E36", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.EASY, new List<String> { "E37" }));
                encounters.Add("E37", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.EASY, new List<String> { "E38" }));
                encounters.Add("E38", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.EASY, new List<String> { "E39" }));
                encounters.Add("E39", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.EASY, new List<String> { "E40" }));
                encounters.Add("E40", new Encounter(ENCOUNTER_TYPE.REGULAR, DIFFICULTY.HARD, new List<String> { "E41" }));
                encounters.Add("E41", new Encounter(ENCOUNTER_TYPE.BOSS, DIFFICULTY.MEDIUM, new List<String> {  }));
            }
            else
            {

            }
        }


    }
}
