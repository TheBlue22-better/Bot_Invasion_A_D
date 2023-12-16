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

namespace Bot_Invasion_A_D.code.world
{
    public class Encounter
    {
        ENCOUNTER_TYPE enType;
        DIFFICULTY diff;
        List<String> neigbours;
        ParentTile[,] tileGrid;
        Player player;
        List<ParentEnemy> enemies;

        public Encounter(ENCOUNTER_TYPE type, DIFFICULTY difficulty, List<String> neigbour)
        {
            this.enType = type;
            this.diff = difficulty;
            this.neigbours = neigbour;
            this.enemies = new List<ParentEnemy>();
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
            this.player = player;
            Generated_Encounter_Parent enc = new Generated_Encounter_Parent();
            int dim = 5;            // so its not unassigned
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
            TILE_TYPE tileType = tileGrid[location.Item1, location.Item2].GetType();
            // switch depending on the type (maybe a local enum)
            switch (tileType)
            {
                case TILE_TYPE.EMPTY:
                    {
                        // check if tile is next to player, if yes move to it, if not... uHHHHHHHH
                        if (PositionNextToPlayer(location, player.GetPosition()))
                        {
                            MovePlayer(ref tileGrid, player.GetPosition(), location);
                            player.SetPosition(location);
                            ShowGrid(tileGrid, ref buttonDictionary);
                        }
                        else
                        {

                        }
                        return RESULT.NOTHING;
                    }
                case TILE_TYPE.PLAYER:
                    {
                        // show stats
                        break;
                    }
                case TILE_TYPE.ENEMY:
                    {
                        // check if tile is next to player, if yes attack, if not show stats
                        break;
                    }
                case TILE_TYPE.MOUNTAIN:
                    {
                        // "You cant move there bruh"
                        break;
                    }
                case TILE_TYPE.BOSS:
                    {
                        // in retrospect, probably same as enemy.... so i dont really need this category...
                        break;
                    }
            }
            return RESULT.SURRENDER;
        }
        
    }
}
