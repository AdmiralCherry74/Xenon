using Terraria;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonNPCGlobals;

namespace Xenon.Content.Buffs.Debuffs
{
    public class Sapped : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;  // Is it a debuff?
            Main.pvpBuff[Type] = true; // Players can give other players buffs, which are listed as pvpBuff
        }

        // Allows you to make this buff give certain effects to the given player
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense -= 5;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<XenonDebuffs>().Sapped = true;
        }
    }
}