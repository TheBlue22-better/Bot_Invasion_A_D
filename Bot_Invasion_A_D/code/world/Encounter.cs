using Bot_Invasion_A_D.code.enums;
using static Bot_Invasion_A_D.code.helping_functions.GridHelper;
using static Bot_Invasion_A_D.code.helping_functions.Helper;
using Bot_Invasion_A_D.forms.encounters;
using Bot_Invasion_A_D.code.world.encounter_tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot_Invasion_A_D.code.entities;
using Bot_Invasion_A_D.code.entities.enemies;

namespace Bot_Invasion_A_D.code.world
{
    public class Encounter
    {
        ENCOUNTER_TYPE enType;
        DIFFICULTY diff;
        List<String> neigbours;
        Tile[,] tileGrid;
        Player player;
        List<Enemy> enemies;

        public Encounter(ENCOUNTER_TYPE type, DIFFICULTY difficulty, List<String> neigbour)
        {
            this.enType = type;
            this.diff = difficulty;
            this.neigbours = neigbour;
            this.enemies = new List<Enemy>();
        }
        public List<String> GetNeigbours()
        {
            return neigbours;
        }
        public DIFFICULTY GetDifficulty()
        {
            return diff;
        }
        public ENCOUNTER_TYPE GetType()
        {
            return enType;
        }

        public Form Generate(Player player)
        {
            Generated_Encounter_Parent enc = new Generated_Encounter_Parent();
            int dim;
            if (enType == ENCOUNTER_TYPE.BOSS)
            {
                dim = 7;
                enc = enc.DimEncounter(dim);
            }
            else
            {
                switch (diff)
                {
                    case DIFFICULTY.EASY:
                        {
                            if (GetChance(75)) dim = 5; else dim = 6;
                            enc = enc.DimEncounter(dim);
                            break;
                        }
                    case DIFFICULTY.MEDIUM:
                        {
                            if (GetChance(90)) dim = 6; else dim = 7;
                            enc = enc.DimEncounter(dim);
                            break;
                        }
                    case DIFFICULTY.HARD:
                        {
                            if (GetChance(25)) dim = 6; else dim = 7;
                            enc = enc.DimEncounter(dim);
                            break;
                        }
                    default:
                        {
                            dim = 5;    //impossible
                            break;      // TODO make an ERROR form to show up in case it somehow gets here
                        }
                }
            }
            GenerateGrid(ref tileGrid, dim);
            FillGrid(tileGrid, ref player, ref enemies);
            ShowGrid(tileGrid, ref enc.getDictionary());
            enc.UpdateEncounter(this);
            return enc;
        }

        public RESULT UpdateEncounter(String name, ref SortedDictionary<string, Button> buttonDictionary)
        {
            // parse string to get a tuple of location
            Tuple<int, int> location = NameToLocation(name); 
            // check what kind of tile the location is

            // switch depending on the type (maybe a local enum)
            return RESULT.SURRENDER;
        }
        
    }
}
