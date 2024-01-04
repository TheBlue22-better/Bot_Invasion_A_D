using Bot_Invasion_A_D.code.enums;
using static Bot_Invasion_A_D.code.helping_functions.GridHelper;
using static Bot_Invasion_A_D.code.helping_functions.Helper;
using static Bot_Invasion_A_D.code.enums.TILE_TYPE;
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
        Dictionary<Tuple<int,int>,Turret> turrets;

        public Encounter(ENCOUNTER_TYPE type, DIFFICULTY difficulty, List<String> neigbour)
        {
            this.enType = type;
            this.diff = difficulty;
            this.neigbours = neigbour;
            this.turrets = new Dictionary<Tuple<int, int>, Turret>();
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

        public ParentTile[,] GetGrid() { return tileGrid; }

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
            FillGrid(tileGrid, ref player, ref turrets);
            ShowGrid(tileGrid, ref enc.getDictionary());
            enc.UpdateEncounter(this);
            enc.UpdatePlayerHealth(player.GetInfo());
            return enc;
        }

        public RESULT UpdateEncounter(String name)
        {
            // player turn
            PlayerTurn(NameToLocation(name));
            // enemy turn
            EnemyTurn();
            
            return RESULT.NOTHING;
        }

        public void PlayerTurn(Tuple<int,int> position)
        {
            if (PositionNextToPlayer(position, player.GetPosition()))
            {
                switch (tileGrid[position.Item1, position.Item2].GetType()) {
                    case EMPTY:
                        {
                            MoveEntity(ref tileGrid, player.GetPosition(), position);
                            player.SetPosition(position);
                            break;
                        }
                    case MOUNTAIN:
                        {
                            break;
                        }
                    case TURRET:
                        {
                            break;
                        }
                    case PLAYER:
                        {
                            break;
                        }
                }
                    
            }
            else
            {
                // tooltip: too far
            }
        }

        public void EnemyTurn()
        {
            foreach (var turret in turrets)
            {
                if (turret.Value.GetState() == STATE.AIM && PositionNextToPlayer(turret.Key, player.GetPosition(), turret.Value.GetRange()))
                {
                    turret.Value.SetState(STATE.FIRE);
                    tileGrid[turret.Key.Item1, turret.Key.Item2].SetSprite();
                }
                else if (turret.Value.GetState() == STATE.FIRE && !PositionNextToPlayer(turret.Key, player.GetPosition(), turret.Value.GetRange()))
                {
                    turret.Value.SetState(STATE.AIM);
                    tileGrid[turret.Key.Item1, turret.Key.Item2].SetSprite();
                }
                
            }
        }
    }
}
