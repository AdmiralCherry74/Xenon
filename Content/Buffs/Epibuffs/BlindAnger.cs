using Terraria;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonPlayerGlobals;

namespace Xenon.Content.Buffs.Epibuffs;
    public class BlindAnger : ModBuff
{
    public override void Update(Player player, ref int buffIndex)
    {
        player.GetModPlayer<XenonPlayer>().KnockbackBoostBattleaxe = true;
    }
}