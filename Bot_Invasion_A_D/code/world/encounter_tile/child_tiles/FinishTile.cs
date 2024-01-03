using Bot_Invasion_A_D.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Invasion_A_D.code.world.encounter_tile.child_tiles
{
    public class FinishTile : ParentTile
    {
        public override void SetSprite()
        {
            this.sprite = Resources.finish;
        }
    }
}
