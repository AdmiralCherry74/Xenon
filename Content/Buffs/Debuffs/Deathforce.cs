using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Buffs.Debuffs
{
    public class Deathforce : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;  // Is it a debuff?
            Main.pvpBuff[Type] = true; // Players can give other players buffs, which are listed as pvpBuff
        }

        // Allows you to make this buff give certain effects to the given player
        public override void Update(Player player, ref int buffIndex)
        {
            player.statLifeMax2 = (int)(player.statLifeMax2 * 0.8f);
        }
    }
}