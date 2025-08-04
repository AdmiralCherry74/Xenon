using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Buffs;
    public class Anger : ModBuff
{
    public override void Update(Player player, ref int buffIndex)
    {
        player.GetArmorPenetration(DamageClass.Generic) += 5;
    }
}