using Bot_Invasion_A_D.Properties;
using Sem_Testing.code.world.encounter_tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Invasion_A_D.code.world.encounter_tile
{
    public class EnemyTile : Tile
    {
        public EnemyTile() 
        {
            Random rnd = new Random();
            if (rnd.Next(0, 100) >= 50)
            {
                this.sprite = Resources.meleeSpider;
            }
            else this.sprite = Resources.rangedGuy;
        }
        public override bool isFull()
        {
            return true;
        }
        public override bool hasPlayer()
        {
            return false;
        }
    }
}
