using Bot_Invasion_A_D.code.entities;
using Bot_Invasion_A_D.code.entities.enemies;
using Bot_Invasion_A_D.code.enums;
using Bot_Invasion_A_D.code.world;

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
                if (encounters[button.Name.ToString()].GetType() == ENCOUNTER_TYPE.BOSS)      //Boss has a difficulty, but same color no matter what
                {
                    button.BackColor = Color.Black;
                }
                else if (encounters[button.Name.ToString()].GetEncounterDifficulty() == DIFFICULTY.EASY)
                {
                    button.BackColor = easy;
                }
                else if (encounters[button.Name.ToString()].GetEncounterDifficulty() == DIFFICULTY.MEDIUM)
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

        public static Tuple<int,int> NameToLocation(String name)
        {
            String[] locString = name.Split('_');
            return new Tuple<int, int>(int.Parse(locString[1]), int.Parse(locString[2]));
        }

        public static Turret RandomTurret()
        {
            if (GetChance(50)) return new MeleeTurret();
            else return new RangedTurret();
        }

        public static void Damage(Entity dealer, Entity receiver)
        {
            receiver.SetHealth(receiver.GetHealth() - dealer.DealDamage());
        }

    }
}
