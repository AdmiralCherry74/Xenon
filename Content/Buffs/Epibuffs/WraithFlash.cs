using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Buffs.Epibuffs
{
    public class WraithFlash : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;  // Is it a debuff?
            Main.pvpBuff[Type] = false; // Players can give other players buffs, which are listed as pvpBuff
            Main.buffNoSave[Type] = true; // Causes this buff not to persist when exiting and rejoining the world
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed += 0.25f;
        }
    }
}