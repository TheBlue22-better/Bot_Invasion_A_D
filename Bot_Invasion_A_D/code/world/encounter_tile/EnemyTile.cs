using Bot_Invasion_A_D.code.entities.enemies;
using Bot_Invasion_A_D.Properties;
using static Bot_Invasion_A_D.code.helping_functions.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Invasion_A_D.code.world.encounter_tile
{
    public class EnemyTile : Tile
    {
        private Enemy enemy;
        public EnemyTile() 
        {
            randomEnemy();
            this.tileType = enums.TILE_TYPE.ENEMY;
        }

        public Enemy GetEnemy() {  return enemy; }
        public override bool isFull()
        {
            return true;
        }
        public override bool hasPlayer()
        {
            return false;
        }
        public override bool hasEnemy()
        {
            return true;
        }
        private void randomEnemy()
        {
            if (GetChance(50))
            {
                this.sprite = Resources.meleeSpider;
                this.enemy = new MeleeEnemy();
            }
            else
            {
                this.sprite = Resources.rangedGuy;
                this.enemy = new RangedEnemy();
            }
        }
    }
}
