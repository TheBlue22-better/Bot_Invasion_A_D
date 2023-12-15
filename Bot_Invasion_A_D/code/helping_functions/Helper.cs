using Bot_Invasion_A_D.code.enums;
using Bot_Invasion_A_D.code.world;
using Bot_Invasion_A_D.code.world.encounter_tile;
using Sem_Testing.code.world.encounter_tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Invasion_A_D.code.helping_functions
{
    public static class Helper
    {
        public static void OnClickChange(object sender, Dictionary<String, Encounter> encounters)
        {
            Color easy = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            Color medium = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            Color hard = System.Drawing.Color.Red;

            Button button = (sender as Button);
            if (!button.Enabled)
            {
                button.BackColor = Color.Gray;
            }
            else
            {
                if (encounters[button.Name.ToString()].GetType() == ENCOUNTER_TYPES.BOSS)      //Boss has a difficulty, but same color no matter what
                {
                    button.BackColor = Color.Black;
                }
                else if (encounters[button.Name.ToString()].GetDifficulty() == DIFFICULTIES.EASY)
                {
                    button.BackColor = easy;
                }
                else if (encounters[button.Name.ToString()].GetDifficulty() == DIFFICULTIES.MEDIUM)
                {
                    button.BackColor = medium;
                }
                else
                {
                    button.BackColor = hard;
                }
            }
        }

        public static bool GetChance(int percent)
        {
            Random rnd = new Random();
            if (percent >= rnd.Next(100)) return true; else return false;
        }
    }
}
