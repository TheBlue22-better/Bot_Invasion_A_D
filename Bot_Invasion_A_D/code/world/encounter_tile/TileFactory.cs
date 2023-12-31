﻿using Bot_Invasion_A_D.code.entities;
using Bot_Invasion_A_D.code.entities.enemies;
using Bot_Invasion_A_D.code.enums;
using static Bot_Invasion_A_D.code.enums.TILE_TYPE;
using Bot_Invasion_A_D.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot_Invasion_A_D.code.world.encounter_tile.child_tiles;

namespace Bot_Invasion_A_D.code.world.encounter_tile
{
    // factory used for creating different tiles
    public class TileFactory
    {
        ParentTile tile;

        public TileFactory(TILE_TYPE type)
        {
            switch (type)
            {
                case EMPTY:
                    {
                        tile = new EmptyTile();
                        break;
                    }
                case TURRET:
                    {
                        tile = new TurretTile();
                        break;
                    }
                case MOUNTAIN:
                    {
                        tile = new MountainTile();
                        break;
                    }
                case PLAYER:
                    {
                        tile = new PlayerTile();
                        break;
                    }
                case FINISH: 
                    {
                        tile = new FinishTile();
                        break;
                    }
                case BOSS:
                    {
                        tile = new BossTile();
                        break;
                    }
            }

            tile.SetSprite();
            tile.SetType(type);
        }
        
        public ParentTile GetTile() { return this.tile; }





    }
}
