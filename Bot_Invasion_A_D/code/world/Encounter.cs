using Bot_Invasion_A_D.code.enums;
using static Bot_Invasion_A_D.code.helping_functions.GridHelper;
using static Bot_Invasion_A_D.code.helping_functions.Helper;
using Bot_Invasion_A_D.forms.encounters;
using Sem_Testing.code.world.encounter_tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Invasion_A_D.code.world
{
    public class Encounter
    {
        ENCOUNTER_TYPES enType;
        DIFFICULTIES diff;
        List<String> neigbours;
        Tile[,] tileGrid;
        Tuple<int, int> playerPos;

        public Encounter(ENCOUNTER_TYPES type, DIFFICULTIES difficulty, List<String> neigbour)
        {
            this.enType = type;
            this.diff = difficulty;
            this.neigbours = neigbour;
        }

        public Form Generate()
        {
            Generated_Encounter_Parent enc = new Generated_Encounter_Parent();
            int dim;
            if (enType == ENCOUNTER_TYPES.BOSS)
            {
                dim = 7;
            }
            else
            {
                switch (diff)
                {
                    case DIFFICULTIES.EASY:
                        {
                            if (GetChance(75)) dim = 5; else dim = 6;
                            enc = enc.DimEncounter(dim);
                            break;
                        }
                    case DIFFICULTIES.MEDIUM:
                        {
                            if (GetChance(90)) dim = 6; else dim = 7;
                            enc = enc.DimEncounter(dim);
                            break;
                        }
                    case DIFFICULTIES.HARD:
                        {
                            if (GetChance(25)) dim = 6; else dim = 7;
                            enc = enc.DimEncounter(dim);
                            break;
                        }
                    default:
                        {
                            dim = 5;    //impossible
                            break;      //literary impossible i think
                                        // TODO make an ERROR form to show up in case it somehow gets here
                        }
                }
            }
            GenerateGrid(ref this.tileGrid, dim);
            FillGrid(tileGrid);
            SetGrid(tileGrid);
            ShowGrid(tileGrid, ref enc.getDictionary());
            return enc;
        }

        private Generated_Encounter_Parent GenerateEasyEncounter()
        {
            Random rnd = new Random();
            if (rnd.Next(20) < 15)
            {
                tileGrid = new Tile[5, 5];
                Generated_Encounter_Parent enc = new Generated_Encounter_5x5();
                return enc;
            }
            else
            {
                tileGrid = new Tile[6, 6];
                Generated_Encounter_Parent enc = new Generated_Encounter_6x6();
                return enc;
            }
        }

        private Generated_Encounter_Parent GenerateMediumEncounter()
        {
            Random rnd = new Random();
            if (rnd.Next(50) < 45)
            {
                tileGrid = new Tile[6, 6];
                Generated_Encounter_Parent enc = new Generated_Encounter_6x6();
                return enc;
            }
            else
            {
                tileGrid = new Tile[7, 7];
                Generated_Encounter_Parent enc = new Generated_Encounter_7x7();
                return enc;
            }
        }
        private Generated_Encounter_Parent GenerateHardEncounter()
        {
            Random rnd = new Random();
            if (rnd.Next(20) < 5)
            {
                tileGrid = new Tile[6, 6];
                Generated_Encounter_Parent enc = new Generated_Encounter_6x6();
                return enc;
            }
            else
            {
                tileGrid = new Tile[7, 7];
                Generated_Encounter_Parent enc = new Generated_Encounter_7x7();
                return enc;
            }

        }
        private Generated_Encounter_Parent GenerateBossEncounter()
        {
            tileGrid = new Tile[7, 7];
            Generated_Encounter_Parent enc = new Generated_Encounter_7x7();
            return enc;
        }

        public List<String> Neigbours()
        {
            return neigbours;
        }

        public DIFFICULTIES Difficulty()
        {
            return diff;
        }

        public ENCOUNTER_TYPES Type()
        {
            return enType;
        }

        public void SetGrid(Tile[,] tileGrid)
        {
            this.tileGrid = tileGrid;
        }



    }
}
