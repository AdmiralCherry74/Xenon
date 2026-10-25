using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Buffs.Epibuffs.OreFruitBuffs
{
    public class GoldAppleBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 4;
            player.moveSpeed += 0.04f;
        }
    }
}