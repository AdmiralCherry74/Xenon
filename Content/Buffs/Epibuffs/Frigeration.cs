using Terraria;
using Terraria.ModLoader;
using Xenon.Common.Globals;

namespace Xenon.Content.Buffs.Epibuffs;
public class Frigeration : ModBuff
{
    public override void Update(Player player, ref int buffIndex)
    {
        player.GetModPlayer<XenonPlayer>().HotDamageResist = true;
    }
}
