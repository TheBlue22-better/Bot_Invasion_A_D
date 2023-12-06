using Bot_Invasion_A_D.code.enums;
using Bot_Invasion_A_D.code.helping_functions;
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

        public Encounter(ENCOUNTER_TYPES type, DIFFICULTIES difficulty, List<String> neigbour)
        {
            this.enType = type;
            this.diff = difficulty;
            this.neigbours = neigbour;
        }

        public void Generate()
        {
            Generated_Encounter_Parent enc = new Generated_Encounter_Parent();                      //TEMPORARY
            if (enType == ENCOUNTER_TYPES.BOSS)
            {
                enc = GenerateBossEncounter();
                this.tileGrid = Helper.FillGrid(tileGrid);
            }
            else
            {
                switch (diff)
                {
                    case DIFFICULTIES.EASY:
                        {
                            enc = GenerateEasyEncounter();
                            this.tileGrid = Helper.FillGrid(tileGrid);
                            break;
                        }
                    case DIFFICULTIES.MEDIUM:
                        {
                            enc = GenerateMediumEncounter();
                            this.tileGrid = Helper.FillGrid(tileGrid);
                            break;
                        }
                    case DIFFICULTIES.HARD:
                        {
                            enc = GenerateHardEncounter();
                            this.tileGrid = Helper.FillGrid(tileGrid);
                            break;
                        }
                    default:
                        {
                            break;      //literary impossible i think
                                        // TODO make an ERROR form to show up so i dont get a null exception here
                        }
                }
            }
            enc.SetGrid(tileGrid);
            Helper.ShowGrid(tileGrid, ref enc.getDictionary());
            enc.ShowDialog();
        }

        private  Generated_Encounter_Parent GenerateEasyEncounter()
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



    }
}
