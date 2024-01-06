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
using Bot_Invasion_A_D.code.entities.child_turrets;

namespace Bot_Invasion_A_D.code.world
{
    public class Encounter
    {
        ENCOUNTER_TYPE enType;
        DIFFICULTY encDiff;
        List<String> neigbours;
        ParentTile[,] tileGrid;
        Player player;
        Dictionary<Tuple<int,int>,Turret> turrets;
        double escapeDamage;

        public Encounter(ENCOUNTER_TYPE type, DIFFICULTY encDiff, List<String> neigbour)
        {
            this.enType = type;
            this.encDiff = encDiff;
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
        public ENCOUNTER_TYPE GetType()
        {
            return enType;
        }

        public ParentTile[,] GetGrid() { return tileGrid; }

        public Player GetPlayer() { return player; }

        public double GetEscapeDamage() { return escapeDamage; }

        // method to generate an encounter based on its type and difficulty
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
            FillGrid(tileGrid, player, turrets, enType);
            ShowGrid(tileGrid, enc.getDictionary());
            enc.UpdateEncounter(this);
            enc.UpdatePlayerHealth(player.GetInfo());
            enc.UpdateMedkitButton();
            this.escapeDamage = EscapeDamage();
            return enc;
        }

        // method to execute a single game move after an encounter button is clicked
        public RESULT UpdateEncounter(String name)
        {
            bool skipTurn = false;
            bool win = false;
            // player turn
            PlayerTurn(NameToLocation(name), ref skipTurn, ref win);
            // enemy turn, is skipped unless player clicked on an empty tile or a turret
            if (!skipTurn)
            {
                EnemyTurn();
            }
            this.escapeDamage = EscapeDamage();
            if (win) return RESULT.VICTORY;
            else if (player.IsDead()) return RESULT.DEATH;
            return RESULT.NOTHING;
        }

        // method to execute a player turn
        public void PlayerTurn(Tuple<int,int> position, ref bool skipTurn, ref bool win)
        {
            if (PositionNextToPlayer(position, player.GetPosition()))                           // turn is only executed if the clicked button was next to player
            {
                ParentTile tile = tileGrid[position.Item1, position.Item2];
                switch (tile.GetType()) {
                    case EMPTY:                                                         // player moves to another tile 
                        {
                            MoveEntity(tileGrid, player.GetPosition(), position);
                            player.SetPosition(position);
                            skipTurn = false;
                            break;
                        }
                    case TURRET:                                                        // player attacks a turret
                        {
                            Damage(this.player, tile.GetEntity());
                            if (tile.GetEntity().IsDead())                              // turret is removed and player can be awarded a medkit
                            {
                                if ((tile.GetEntity() as Turret).DropsMedkit()) player.GiveMedkit();
                                turrets.Remove(position);
                                tileGrid[position.Item1, position.Item2] = new EmptyTile();
                                tileGrid[position.Item1, position.Item2].SetSprite();
                            }
                            skipTurn = false;
                            break;
                        }
                    case BOSS:                                                                  // similiar to a turret, but boss has multiple stages
                        {
                            Damage(this.player, tile.GetEntity());
                            if (tile.GetEntity().IsDead() && (tile.GetEntity() as BossTurret).HasNextStage())           // upon death, next stage of the boss is spawned
                            {
                                (tile.GetEntity() as BossTurret).NextStage();
                                tileGrid[position.Item1, position.Item2].SetSprite();
                            }
                            else if (tile.GetEntity().IsDead())                                                 // after death in last stage, boss does its final attack and
                            {                                                                                   // is removed just as any other turret
                                (tile.GetEntity() as BossTurret).FinalAttack(tileGrid);
                                (tileGrid[position.Item1-1, position.Item2] as FinishTile).bossAlive = false;   // finish is now unlocked
                                tileGrid[position.Item1 - 1, position.Item2].SetSprite();
                                tileGrid[position.Item1, position.Item2] = new EmptyTile();
                                tileGrid[position.Item1, position.Item2].SetSprite();
                            }
                            break;
                        }
                    case FINISH:                                                        // endpoint of the encounter, usable if there is no boss or the boss is dead
                        {
                            if (!(tileGrid[position.Item1, position.Item2] as FinishTile).bossAlive) win = true;
                            skipTurn = true;
                            break;
                        }
                    default:                                                // any other option means a skip of turn
                        {
                            skipTurn = true;
                            break;
                        }
                }
                    
            }
            else skipTurn = true;
        }

        // every enemy turn is executed after eachother
        public void EnemyTurn()
        {
            foreach (var turret in turrets)
            {
                turret.Value.TurretTurn(turret.Key, player);
                tileGrid[turret.Key.Item1, turret.Key.Item2].SetSprite();
            }
        }

        // sets a fixed damage to be done to the player if they choose to escape, recalculated every time encounter is updated
        private double EscapeDamage()
        {
            double damage = 0;
            int timesAttacked;
            if (encDiff == DIFFICULTY.EASY) timesAttacked = 1;
            else if (encDiff == DIFFICULTY.MEDIUM) timesAttacked = 2;
            timesAttacked = 3;
            
            foreach(var turret in turrets)
            {
                for (int i = 0; i < timesAttacked; i++) damage += turret.Value.DealDamage();
            }
            return damage;
        }
    }
}
