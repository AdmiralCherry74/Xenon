using Terraria;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonPlayerGlobals;

namespace Xenon.Content.Buffs.Debuffs
{
    public class Boomed : ModBuff
    {
        public const float RateMultiplier = 1.1f; // Lower means more spawns as rate is the delay in time
        public const float SpawnMultiplier = 1.5f;
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;  // Is it a debuff?
            Main.pvpBuff[Type] = true; // Players can give other players buffs, which are listed as pvpBuff
        }

        // Allows you to make this buff give certain effects to the given player
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Generic) -= 10;
            player.aggro += 100;
            player.GetModPlayer<XenonPlayer>().Boomed = true;
        }
    }
}