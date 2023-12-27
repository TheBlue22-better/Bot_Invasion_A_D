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
        Dictionary<Tuple<int,int>,ParentEnemy> enemies;

        public Encounter(ENCOUNTER_TYPE type, DIFFICULTY difficulty, List<String> neigbour)
        {
            this.enType = type;
            this.diff = difficulty;
            this.neigbours = neigbour;
            this.enemies = new Dictionary<Tuple<int, int>, ParentEnemy>();
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
            // parse string to get a tuple of location
            Tuple<int, int> location = NameToLocation(name);
            // check what kind of tile the location is
            TILE_TYPE tileType = tileGrid[location.Item1, location.Item2].GetType();
            // player turn
            TURN_RESULT result = PlayerTurn(location, tileType);
            // enemy move
            // if (result == TURN_RESULT.SKIP) EnemyTurn();             currently broken fix needed
            ShowGrid(tileGrid, ref buttonDictionary);

            return RESULT.NOTHING;
        }
        
        private TURN_RESULT PlayerTurn(Tuple<int,int> location, TILE_TYPE tileType)
        {
            if (location == player.GetPosition())
            {
                // do something with tooltip
                return TURN_RESULT.STAY;
            }
            else if (PositionNextToPlayer(location, player.GetPosition()))
            {
                switch (tileType)
                {
                    case TILE_TYPE.EMPTY:
                        {
                            MoveEntity(ref tileGrid, player.GetPosition(), location);
                            player.SetPosition(location);
                            return TURN_RESULT.SKIP;
                        }
                    case TILE_TYPE.MOUNTAIN:
                        {
                            // do something with tooltip
                            return TURN_RESULT.STAY;
                        }
                    case TILE_TYPE.ENEMY:
                        {
                            // attack
                            return TURN_RESULT.SKIP;
                        }
                    default: return TURN_RESULT.STAY;
                }
            }
            else
            {
                return TURN_RESULT.STAY;
            }
        }

        private void EnemyTurn()
        {
            // traverse through the dictionary
            foreach (var enem in enemies)
            {
                if (PositionNextToPlayer(enem.Key, player.GetPosition(), enem.Value.GetRange()))
                {
                    // attack
                }
                else
                {
                    Tuple<int, int> newLocation = enem.Value.FindPath(player.GetPosition(), tileGrid);
                    MoveEntity(ref tileGrid, enem.Key, newLocation);
                    enem.Value.SetPosition(newLocation);
                }
            }

        }

    }
}
