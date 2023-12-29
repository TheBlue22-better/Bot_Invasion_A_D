using Bot_Invasion_A_D.code.enums;
using static Bot_Invasion_A_D.code.helping_functions.GridHelper;
using static Bot_Invasion_A_D.code.helping_functions.Helper;
using Bot_Invasion_A_D.forms.encounters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot_Invasion_A_D.code.entities;
using Bot_Invasion_A_D.code.entities.enemies;
using Bot_Invasion_A_D.code.world.encounter_tile;
using System.Diagnostics;

namespace Bot_Invasion_A_D.code.world
{
    public class Encounter
    {
        ENCOUNTER_TYPE enType;
        DIFFICULTY diff;
        List<String> neigbours;
        ParentTile[,] tileGrid;
        Player player;
        Dictionary<Tuple<int,int>,Enemy> enemies;
        TURN_RESULT turnResult;

        public Encounter(ENCOUNTER_TYPE type, DIFFICULTY difficulty, List<String> neigbour)
        {
            this.enType = type;
            this.diff = difficulty;
            this.neigbours = neigbour;
            this.enemies = new Dictionary<Tuple<int, int>, Enemy>();
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

        public Player GetPlayer() { return player; }

        public Form Generate(Player player)
        {
            this.player = player;
            Generated_Encounter_Parent enc = new Generated_Encounter_Parent();
            int dim = 5;            // so its not unassigned
            if (enType == ENCOUNTER_TYPE.BOSS)
            {
                dim = 7;
            }
            else
            {
                switch (diff)
                {
                    case DIFFICULTY.EASY:
                        {
                            if (GetChance(75)) dim = 5; else dim = 6;
                            break;
                        }
                    case DIFFICULTY.MEDIUM:
                        {
                            if (GetChance(90)) dim = 6; else dim = 7;
                            break;
                        }
                    case DIFFICULTY.HARD:
                        {
                            if (GetChance(25)) dim = 6; else dim = 7;
                            break;
                        }
                }
            }
            enc = enc.DimEncounter(dim);
            InitializeGrid(ref tileGrid, dim);
            FillGrid(tileGrid, ref player, ref enemies);
            ShowGrid(tileGrid, ref enc.getDictionary());
            enc.UpdateEncounter(this);
            return enc;
        }

        public RESULT UpdateEncounter(String name, ref SortedDictionary<string, Button> buttonDictionary)
        {
            return RESULT.NOTHING;
        }

    }
}
