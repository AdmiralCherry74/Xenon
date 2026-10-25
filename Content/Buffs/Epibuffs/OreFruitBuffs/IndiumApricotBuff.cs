using Terraria;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonPlayerGlobals;

namespace Xenon.Content.Buffs.Epibuffs.OreFruitBuffs
{
    public class IndiumApricotBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.statLifeMax2 += 30;
            player.GetModPlayer<XenonPlayer>().KnockbackBoostIndiumApricot = true;
        }
    }
}