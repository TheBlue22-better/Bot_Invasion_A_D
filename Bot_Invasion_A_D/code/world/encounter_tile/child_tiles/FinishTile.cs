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
        // sprite is set based on if boss is alive, if it is, finish cannot be used and player cant escape
        public bool bossAlive = false;
        public override void SetSprite()
        {
            if (!bossAlive)
            {
                sprite = Resources.finish;
            }
            else
            {
                sprite = Resources.finishLocked;
            }
        }
    }
}
