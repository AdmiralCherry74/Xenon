using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Buffs.Epibuffs.OreFruitBuffs
{
    public class CopperGrapefruitBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 1;
        }
    }
}