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
using Bot_Invasion_A_D.code.world.encounter_tile.child_tiles;

namespace Bot_Invasion_A_D.code.world
{
    public class Encounter
    {
        ENCOUNTER_TYPE enType;
        DIFFICULTY encDiff;
        DIFFICULTY wDiff;
        List<String> neigbours;
        ParentTile[,] tileGrid;
        Player player;
        Dictionary<Tuple<int,int>,Turret> turrets;

        public Encounter(ENCOUNTER_TYPE type, DIFFICULTY encDiff, DIFFICULTY wDiff, List<String> neigbour)
        {
            this.enType = type;
            this.encDiff = encDiff;
            this.wDiff = wDiff;
            this.neigbours = neigbour;
            this.turrets = new Dictionary<Tuple<int, int>, Turret>();
        }
        public List<String> GetNeigbours()
        {
            return neigbours;
        }
        public DIFFICULTY GetEncounterDifficulty()
        {
            return encDiff;
        }

        public DIFFICULTY GetWorldDifficulty()
        {
            return wDiff;
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
                switch (encDiff)
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
            tileGrid = InitializeGrid(tileGrid, dim);
            FillGrid(tileGrid, player, turrets);
            ShowGrid(tileGrid, enc.getDictionary());
            enc.UpdateEncounter(this);
            enc.UpdatePlayerHealth(player.GetInfo());
            enc.UpdateMedkitButton();
            return enc;
        }

        public RESULT UpdateEncounter(String name)
        {
            bool skipTurn = false;
            bool win = false;
            // player turn
            PlayerTurn(NameToLocation(name), ref skipTurn, ref win);
            // enemy turn
            if (!skipTurn)
            {
                EnemyTurn();
            }
            if (win) return RESULT.VICTORY;
            if (player.IsDead()) return RESULT.DEATH;
            return RESULT.NOTHING;
        }

        public void PlayerTurn(Tuple<int,int> position, ref bool skipTurn, ref bool win)
        {
            if (PositionNextToPlayer(position, player.GetPosition()))
            {
                switch (tileGrid[position.Item1, position.Item2].GetType()) {
                    case EMPTY:
                        {
                            MoveEntity(tileGrid, player.GetPosition(), position);
                            player.SetPosition(position);
                            skipTurn = false;
                            break;
                        }
                    case TURRET:
                        {
                            Damage(this.player, tileGrid[position.Item1, position.Item2].GetEntity());
                            if (tileGrid[position.Item1, position.Item2].GetEntity().IsDead())
                            {
                                if ((tileGrid[position.Item1, position.Item2].GetEntity() as Turret).DropsMedkit(wDiff)) player.GiveMedkit();
                                turrets.Remove(position);
                                tileGrid[position.Item1, position.Item2] = new EmptyTile();
                                tileGrid[position.Item1, position.Item2].SetSprite();
                            }
                            skipTurn = false;
                            break;
                        }
                    case FINISH:
                        {
                            win = true;
                            skipTurn = true;
                            break;
                        }
                    default:
                        {
                            skipTurn = true;
                            break;
                        }
                }
                    
            }
            else
            {
                skipTurn = true;
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
                else if (turret.Value.GetState() == STATE.FIRE && PositionNextToPlayer(turret.Key, player.GetPosition(), turret.Value.GetRange()))
                {
                    Damage(turret.Value, player);
                }
            }
        }

        public void Damage(Entity dealer, Entity receiver)
        {
            receiver.SetHealth(receiver.GetHealth() - dealer.DealDamage(this.wDiff));
        }

        public double EscapeDamage()
        {
            double damage = 0;
            foreach(var turret in turrets)
            {
                damage += turret.Value.DealDamage(this.wDiff);
            }
            return damage;
        }
    }
}
