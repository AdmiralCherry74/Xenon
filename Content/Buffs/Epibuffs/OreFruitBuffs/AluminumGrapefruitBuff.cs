using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Buffs.Epibuffs.OreFruitBuffs
{
    public class AluminumGrapefruitBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.statLifeMax2 += 10;
        }
    }
}