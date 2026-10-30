using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Common.MasterModeGlobals.XenonMMNPCGlobals
{
    public class DamageAndDefenseRebalenceNPC : GlobalNPC
    {
        public override void SetDefaults(NPC entity)
        {
            if (ModContent.GetInstance<XenonConfig>().MasterModeChanges && Main.masterMode)
            {
                if (!entity.friendly)
                {
                    //Makes enemies hit like a truck but in exchange they barely get stronger themselves
                    //Mainly inspired by nightmare difficulty from Dying Light 2
                    entity.damage *= 4;
                    entity.defense /= 2;
                    entity.lifeMax /= 2;
                }
            }
        }
    }
}
