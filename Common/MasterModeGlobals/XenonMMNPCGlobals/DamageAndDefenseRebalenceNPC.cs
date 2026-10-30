using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Common.MasterModeGlobals.XenonMMNPCGlobals
{
    public class DamageAndDefenseRebalenceNPC : GlobalNPC
    {
        public override void ApplyDifficultyAndPlayerScaling(NPC npc, int numPlayers, float balance, float bossAdjustment)
        {
            if (ModContent.GetInstance<XenonConfig>().MasterModeChanges && Main.masterMode)
            {
                if (!npc.friendly && !npc.boss)
                {
                    //Makes enemies hit like a truck but in exchange they barely get stronger themselves
                    //Mainly inspired by nightmare difficulty from Dying Light 2
                    npc.damage *= 2;
                    npc.lifeMax = (int)(npc.lifeMax * 0.87f);
                }
            }
        }
    }
}
