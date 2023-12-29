using Bot_Invasion_A_D.code.entities;
using Bot_Invasion_A_D.code.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Invasion_A_D.code.world.encounter_tile
{
    public abstract class ParentTile
    {
        TILE_TYPE tileType;
        protected Bitmap sprite;
        protected Entity? entity;
        public bool IsFull() { return tileType != TILE_TYPE.EMPTY; }
        public bool HasPlayer() { return tileType == TILE_TYPE.PLAYER; }
        public bool HasEnemy() { return tileType == TILE_TYPE.ENEMY; }

        public Bitmap GetSprite()
        {
            return sprite;
        }
        public TILE_TYPE GetType()
        {
            return tileType;
        }
        public Entity GetEntity()
        {
            return entity;
        }
        public void SetType(TILE_TYPE type) { tileType = type; } 
        public abstract void SetSprite();
    }
}
