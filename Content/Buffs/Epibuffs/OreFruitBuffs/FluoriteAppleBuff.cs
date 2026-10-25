using Terraria;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonPlayerGlobals;

namespace Xenon.Content.Buffs.Epibuffs.OreFruitBuffs
{
    public class FluoriteAppleBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.statLifeMax2 += 40;
            player.GetModPlayer<XenonPlayer>().KnockbackBoostFluoriteApple = true;
        }
    }
}